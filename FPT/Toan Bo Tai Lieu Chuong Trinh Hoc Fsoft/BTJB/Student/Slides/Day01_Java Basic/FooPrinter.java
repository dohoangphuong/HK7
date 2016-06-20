/**
 * Title: FooPrinter
 * Description: Simple class definition and object creation.
 *    The class includes a main, but we need to create and object to
 *    do anything interesting.
 * @author hollingd@cs.rpi.edu
 */


/**
 * FooPrinter can print the strings "FOO" and "foo"
 */

class FooPrinter {
	static final String UPPER = "FOO";
	static final String LOWER = "foo";

	// instance variable, do we print upper or lower?
	boolean PrintUpper = false;

	public static void main(String[] args) {
		//	FooPrinter f = new FooPrinter();
		f.Print();
		f.Upper();
		f.Print();
	}

	  
	void Upper() {
		PrintUpper=true;
	}

	void Lower() {
		PrintUpper=false;
	}

	void Print() {
		if (PrintUpper)
			System.out.println(UPPER);
		else
			System.out.println(LOWER);
	}
}
		
