/* Description: demo of static fields and finalize
 */

public class ObjCount {
    // static fields keep track of the next id number
    //  and the total number of object that exist
    static int next_id=0;
    static int objcount;

    // id is an instance field, each object has it's own.
    int id;

    public static void main(String[] args) {

        int n = Integer.parseInt(args[0]);

        for (int i=0;i<n;i++) {
            ObjCount o = new ObjCount();
            System.out.println(o);
            System.out.println("There are " + objcount + " objects ");
            if (i % 5 == 0) {
                System.gc();
            }
        }

    }

    // constructor
    ObjCount() {
        id = next_id++;
        objcount++;
    }

    // finalize is called when an object is destroyed by the GC
    protected void finalize() {
        objcount--;
    }

    public String toString() {
        return("ID: " + id );
    }
}
