 // InitArray.java
 // Creating an array.
 import javax.swing.*;

 public class InitArray {

    public static void main( String args[] )
    {
       /*int array[];            // declare reference to an array

       array = new int[ 10 ];  // create array*/
       /*int array[] = { 32, 27, 64, 18, 95, 14, 90, 70, 60, 37 };*/

		final int ARRAY_LENGTH = 10;    // constant
		int array[];                    // reference to int array

		array = new int[ ARRAY_LENGTH ];  // create array

		// calculate value for each array element
		for ( int counter = 0; counter < array.length; counter++ )
		array[ counter ] = 2 + 2 * counter;



       String output = "Index\tValue\n";

       // append each array element's value to String output
       for ( int counter = 0; counter < array.length; counter++ )
          output += counter + "\t" + array[ counter ] + "\n";

       JTextArea outputArea = new JTextArea();
       outputArea.setText( output );

       JOptionPane.showMessageDialog( null, outputArea,
          "Initializing an Array of int Values",
          JOptionPane.INFORMATION_MESSAGE );

       System.exit( 0 );

   } // end main

} // end class InitArray
