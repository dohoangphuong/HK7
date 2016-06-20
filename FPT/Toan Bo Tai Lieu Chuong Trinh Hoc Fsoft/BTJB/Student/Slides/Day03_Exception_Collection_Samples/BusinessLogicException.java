package vn.com.fsoft.java.lesson4.exception;

public class BusinessLogicException extends Exception {

	private static final long serialVersionUID = 7971053664370009011L;

	public BusinessLogicException() {
		super();
	}

	public BusinessLogicException(String message) {
		super(message);
	}

	public BusinessLogicException(Throwable cause) {
		super(cause);
	}

	public BusinessLogicException(String message, Throwable cause) {
		super(message, cause);
	}
}
