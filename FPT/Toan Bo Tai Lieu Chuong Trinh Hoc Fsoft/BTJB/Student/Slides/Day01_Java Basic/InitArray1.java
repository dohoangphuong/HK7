// Fig. 7.14: InitArray.java
// Initializing two-dimensional arrays.
import java.awt.Container;
import javax.swing.*;

public class InitArray1 extends JApplet {
   JTextArea outputArea;

  public static void main( String args[] )
  {
     int array1[][] = { { 1, 2, 3 }, { 4, 5, 6 } };
     int array2[][] = { { 1, 2 }, { 3 }, { 4, 5, 6 } };

     outputArea.setText( "Values in array1 by row are\n" );
     buildOutput( array1 );

     outputArea.append( "\nValues in array2 by row are\n" );
     buildOutput( array2 );

  } // end method init

