 // Sum.java
 // Summing integers with the for statement.
 import javax.swing.JOptionPane;

 public class Sum {

    public static void main( String args[] )
    {
       int total = 0;  // initialize sum

      // total even integers from 2 through 100
      for ( int number = 2; number <= 100; number += 2 )
         total += number;

      // display results
      JOptionPane.showMessageDialog( null, "The sum is " + total,
         "Total Even Integers from 2 to 100",
         JOptionPane.INFORMATION_MESSAGE );

      System.exit( 0 );   // terminate application

   } // end main

} // end class Sum
