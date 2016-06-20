package vn.com.fsoft.java.lesson4.exception;

public class CustomerNotFoundException extends CustomerException {

	private static final long serialVersionUID = -7614885187545072080L;
	private static final String DEFAULT_MSG = "Could not found the customer in the database.";

	public CustomerNotFoundException(Long customerID) {
		super(customerID);
	}

	public CustomerNotFoundException(Long customerID, String customerName) {
		super(customerID, customerName);
	}

	public CustomerNotFoundException(String customerName) {
		super(customerName);
	}

	public String getMessage() {
		StringBuffer msg = new StringBuffer(DEFAULT_MSG);
		msg.append(super.getMessage());
		return msg.toString();
	}
}
