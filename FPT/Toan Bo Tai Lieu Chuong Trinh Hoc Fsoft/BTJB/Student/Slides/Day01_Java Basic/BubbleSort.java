 // Fig. 7.10: BubbleSort.java
 // Sort an array's values into ascending order.
 import java.awt.*;
 import javax.swing.*;

 public class BubbleSort extends JApplet {

   public static void main( String args[] )
   {
      int array[] = { 2, 6, 4, 8, 10, 12, 89, 68, 45, 37 };

      String output = "Data items in original order\n";

      // append original array values to String output
      for ( int counter = 0; counter < array.length; counter++ )
         output += "   " + array[ counter ];

      bubbleSort( array );  // sort array

      output += "\n\nData items in ascending order\n";

      // append sorted\ array values to String output
      for ( int counter = 0; counter < array.length; counter++ )
         output += "   " + array[ counter ];


     JTextArea outputArea = new JTextArea();
     outputArea.setText( output );
       JOptionPane.showMessageDialog( null, outputArea,
          "Bubble Sort Program", JOptionPane.INFORMATION_MESSAGE );

       System.exit( 0 );

   } // end method init

   // sort elements of array with bubble sort
   public static void bubbleSort( int array2[] )
   {
      // loop to control number of passes
      for ( int pass = 1; pass < array2.length; pass++ ) {

         // loop to control number of comparisons
         for ( int element = 0;
               element < array2.length - 1;
               element++ ) {

            // compare side-by-side elements and swap them if
            // first element is greater than second element
            if ( array2[ element ] > array2[ element + 1 ] )
               swap( array2, element, element + 1 );

         } // end loop to control comparisons

      } // end loop to control passes

   } // end method bubbleSort

   // swap two elements of an array
   public static void swap( int array3[], int first, int second )
   {
      int hold;  // temporary holding area for swap

      hold = array3[ first ];
      array3[ first ] = array3[ second ];
      array3[ second ] = hold;
   }

} // end class BubbleSort
