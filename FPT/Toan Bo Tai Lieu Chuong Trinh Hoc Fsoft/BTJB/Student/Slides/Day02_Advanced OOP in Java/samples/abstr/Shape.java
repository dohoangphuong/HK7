package samples.abstr;

public abstract class Shape extends Object {

    // return area of shape; 0.0 by default
    public double getArea()
    {
       return 0.0;
   }

   // return volume of shape; 0.0 by default
   public double getVolume()
   {
      return 0.0;
   }

   // abstract method, overridden by subclasses
   public abstract String getName();

} // end abstract class Shape
