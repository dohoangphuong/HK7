/**
 * FooPrinter can print the strings "FOO" and "foo"
 * this class
 */

class FooPrinter {
    static final String UPPER = "FOO";
    static final String LOWER = "foo";

    // instance variable, do we print upper or lower?
    boolean PrintUpper = false;

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


public class SimpleClass{

    public static void main(String[] args) {
        FooPrinter f = new FooPrinter();
        f.Print();
        f.Upper();
        f.Print();
    }
}

