 // Circle.java
 // Circle5 class declaration.

 public class Circle extends Point {

    private double radius;  // Circle's radius

    // no-argument constructor
    public Circle()
   {
      // implicit call to Point constructor occurs here
      System.out.println( "Circle no-argument constructor: " + this );
   }

   // constructor
   public Circle( int xValue, int yValue, double radiusValue )
   {
      super( xValue, yValue );  // call Point constructor
      setRadius( radiusValue );

      System.out.println( "Circle constructor: " + this );
   }

   // finalizer
   protected void finalize()
   {
      System.out.println( "Circle finalizer: " + this );

      super.finalize();  // call superclass finalize method
   }

   // set radius
   public void setRadius( double radiusValue )
   {
      radius = ( radiusValue < 0.0 ? 0.0 : radiusValue );
   }

   // return radius
   public double getRadius()
   {
      return radius;
   }

   // calculate and return diameter
   public double getDiameter()
   {
      return 2 * getRadius();
   }

   // calculate and return circumference
   public double getCircumference()
   {
      return Math.PI * getDiameter();
   }

   // calculate and return area
   public double getArea()
   {
      return Math.PI * getRadius() * getRadius();
   }

   // return String representation of Circle5 object
   public String toString()
   {
      return "Center = " + super.toString() + "; Radius = " + getRadius();
   }

} // end class Circle
