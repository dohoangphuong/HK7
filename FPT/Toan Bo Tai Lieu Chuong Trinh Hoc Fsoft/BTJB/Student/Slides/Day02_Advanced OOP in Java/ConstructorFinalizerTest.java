 // ConstructorFinalizerTest.java
 // Display order in which superclass and subclass
 // constructors and finalizers are called.

 public class ConstructorFinalizerTest {

    public static void main( String args[] )
    {
       Point point;
      Circle circle1, circle2;

      point = new Point( 11, 22 );

      System.out.println();
      circle1 = new Circle( 72, 29, 4.5 );

      System.out.println();
      circle2 = new Circle( 5, 7, 10.67 );

      point = null;    // mark for garbage collection
      circle1 = null;  // mark for garbage collection
      circle2 = null;  // mark for garbage collection

      System.out.println();

      System.gc();  // call the garbage collector

   } // end main

} // end class ConstructorFinalizerTest
