 // PointTest.java
 // Testing class Point.
 import javax.swing.JOptionPane;

 public class PointTest {

    public static void main( String[] args )
    {
       Point point = new Point( 72, 115 );  // create Point object

      // get point coordinates
      String output = "X coordinate is " + point.getX() +
         "\nY coordinate is " + point.getY();

      point.setX( 10 );  // set x-coordinate
      point.setY( 20 );  // set y-coordinate

      // get String representation of new point value
      output += "\n\nThe new location of point is " + point;

      JOptionPane.showMessageDialog( null, output ); // display output

      System.exit( 0 );

   } // end main

} // end class PointTest
