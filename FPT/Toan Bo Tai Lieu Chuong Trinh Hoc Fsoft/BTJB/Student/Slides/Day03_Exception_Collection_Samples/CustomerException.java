package vn.com.fsoft.java.lesson4.exception;

public class CustomerException extends BusinessLogicException {

	private static final long serialVersionUID = 3547726187661762104L;
	private static final String ID = "Customer ID: ";
	private static final String NAME = "Customer Name: ";
	private Long customerID;
	private String customerName;

	public CustomerException(Long customerID, String customerName) {
		this.customerID = customerID;
		this.customerName = customerName;
	}
	
	public CustomerException(Long customerID) {
		this(customerID, null);
	}

	public CustomerException(String customerName) {
		this(null, customerName);
	}

	public String getMessage() {
		StringBuffer msg = new StringBuffer();
		if (customerID != null) {
			msg.append(ID).append(customerID);
		}
		if (customerName != null) {
			msg.append(NAME).append(customerName);
		}
		return msg.toString();
	}
}
