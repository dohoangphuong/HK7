/**
 * Title: ShapeIntergace
 * Description: Interface inheritence with Shape interface
 * @author hollingd@cs.rpi.edu
 */


// declare the interface
interface Shape {
    // every shape needs a draw methods
    void Draw();
    // every shape needs a print method
    void Print();
}


class Square implements Shape {
    Point lowerleft;
    int sidelen;

    // default constructor
    Square() {
        this(0,0,0);
    }

    Square(int x, int y, int size) {
        lowerleft = new Point(x,y);
        sidelen = size;
    }

    public void Draw() {
        System.out.println("Drawing a Square of size " + sidelen + " from " + lowerleft);
    }

    public void Print() {
        System.out.println("Square(" + lowerleft + "," + sidelen+")");
    }
}


class Circle implements Shape {
    Point center;
    int radius;

    // default constructor
    Circle() {
        this(0,0,0);
    }

    Circle(int x, int y, int size) {
        center = new Point(x,y);
        radius = size;
    }

    public void Draw() {
        System.out.println("Drawing a Circle of radius " + radius  + " at " + center);
    }

    public void Print() {
        System.out.println("Circle(" + center + "," + radius+")");
    }
}


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




// this class is for testing
public class ShapeInterface {

    public static void main(String[] args) {
        // create some point and circle objects
        // we can create and array of Shape objects and put them there

        Shape [] s = new Shape[6];

        int i;

        for (i=0;i<3;i++)
            s[i]= new Circle(i,i,i);

        for (;i<6;i++)
            s[i]= new Square(2*i,i,3*i);

        // print out the list of shapes

        for (i=0;i<6;i++)
            s[i].Print();
    }

}
