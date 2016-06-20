/**
 * Title: FinalPlay
 * Description: demo of final field modifier
 *   also uses a Date object from java.util
 */

// we need the following to get at Date()
import java.util.*;

public class FinalPlay {
    // declare a final instance variable
    final int foo=13;

    // constructor
    FinalPlay() {
        // this assignment can't be here if we initialize foo above!
        foo = 15;
        System.out.println("New object created at " + new Date());
        System.out.println("foo is " + foo );
    }

    // main
    public static void main(String[] args) {

        FinalPlay f = new FinalPlay();
        f.setFoo(11);
    }

    // a method that changes foo
    // should not be able to compile with this uncommented!
    void setFoo( int x ) {
        //      foo = x;
    }
}



