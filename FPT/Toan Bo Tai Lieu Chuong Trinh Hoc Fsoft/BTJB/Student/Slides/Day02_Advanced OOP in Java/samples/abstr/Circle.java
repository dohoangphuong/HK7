package samples.abstr;

public class Circle extends Point {
    private double radius;  // Circle's radius

    // no-argument constructor; radius defaults to 0.0
    public Circle()
    {
      // implicit call to Point constructor occurs here
   }

   // constructor
   public Circle( int x, int y, double radiusValue )
   {
      super( x, y );  // call Point constructor
      setRadius( radiusValue );
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

   // override method getArea to return Circle area
   public double getArea()
   {
      return Math.PI * getRadius() * getRadius();
   }

   // override abstract method getName to return "Circle"
   public String getName()
   {
      return "Circle";
   }

   // override toString to return String representation of Circle
   public String toString()
   {
      return "Center = " + super.toString() + "; Radius = " + getRadius();
   }

} // end class Circle
