package vn.com.fsoft.java.lesson4.exception;

public class DuplicatedCustomerException extends CustomerException {

	private static final long serialVersionUID = 8274208538372674023L;
	private static final String DEFAULT_MSG = "This customer is already exists.";

	public DuplicatedCustomerException(Long customerID, String customerName) {
		super(customerID, customerName);
	}

	public DuplicatedCustomerException(Long customerID) {
		super(customerID);
	}

	public DuplicatedCustomerException(String customerName) {
		super(customerName);
	}

	public String getMessage() {
		StringBuffer msg = new StringBuffer(DEFAULT_MSG);
		msg.append(super.getMessage());
		return msg.toString();
	}
}
