/**
 * Title: PCInherit
 * Description: Point and Circle via Inheritance
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

    public String toString() {
        return( "Center: " + super.toString() + " Radius: " + radius);
    }
}


// this class is for testing point and circle
public class PCInherit {

    public static void main(String[] args) {

        Circle c1 = new Circle(10,10,3);
        System.out.println(c1);

        c1.MoveTo(0,0);
        System.out.println(c1);
    }

}
