/**
 * Title: PCCompositsion
 * Description: Point and Circle via Composition example
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


// A circle class is composed of a point (the center) and radius.
class Circle {
    Point center;
    int radius;

    // constructor
    Circle( int x, int y, int r) {
        center = new Point(x,y);
        radius = r;
    }

    // move the center of the circle
    // we need to call the point method.
    void MoveTo( int newx, int newy) {
        center.MoveTo(newx,newy);
    }

    // convert to a string
    public String toString() {
        return( "Center: " + center + " Radius: " + radius);
    }
}


// this class is for testing point and circle
public class PCComposition {

    public static void main(String[] args) {

        Circle c1 = new Circle(10,10,3);
        System.out.println(c1);

        c1.MoveTo(0,0);
        System.out.println(c1);
    }

}
