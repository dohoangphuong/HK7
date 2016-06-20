/**
 * Title: ObjBase
 * Description: Every object is an Object 
 * @author hollingd@cs.rpi.edu
 */

class Point {
	int x,y;
	// constructor - notice we can use this to get past
	//   the (silly) field name shadowing.
	Point( int x, int y) {
		this.x = x;
		this.y = y;
	}

	// a method that allows moving the point
	void MoveTo(int newx, int newy) {
		x = newx; y = newy;
	}

	// this is called by System.out.println
	//  (or anything that treats it as a String)
	public String toString() {
		return(x + "," + y );
	}
}


// A circle is a special kind of point (inheritance)

class Circle extends Point{
	int radius;

	// constructor
	Circle( int x, int y, int r) {
		// call superclass constructor
		super(x,y);
		radius = r;
	}

	// move the center of the circle we do nothing, since we 
	// inherited the MoveTo method

	// convert to a string
	// we can use super().toString() to get at the Point toString
	public String toString() {
		return( "Center: " + super.toString() + " Radius: " + radius);
	}
}


// this class is for testing 
public class ObjBase {

	public static void main(String[] args) {
		// create some point and circle objects
		Circle c1 = new Circle(10,10,3);
		Point p1 = new Point(3,4);

		Class x = c1.getClass();
		System.out.println("c1 is a " + x.getName() );

		System.out.println("p1 is a " + p1.getClass().getName());

		// here comes the tricky part - what will this print?
		Point c2 = (Point) c1;
		System.out.println("c2 is a " + c2.getClass().getName());
		
	}	

}
