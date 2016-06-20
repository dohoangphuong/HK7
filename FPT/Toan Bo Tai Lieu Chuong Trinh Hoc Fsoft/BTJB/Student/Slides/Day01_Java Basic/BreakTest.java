 // BreakTest.java
 // Terminating a loop with break.
 import javax.swing.JOptionPane;

 public class BreakTest {

    public static void main( String args[] )
    {
       String output = "";
      int count;

      for ( count = 1; count <= 10; count++ ) {  // loop 10 times

         if ( count == 5 )  // if count is 5,
            break;          // terminate loop

         output += count + " ";

      } // end for

      output += "\nBroke out of loop at count = " + count;
      JOptionPane.showMessageDialog( null, output );

      System.exit( 0 );  // terminate application

   } // end main

} // end class BreakTest
