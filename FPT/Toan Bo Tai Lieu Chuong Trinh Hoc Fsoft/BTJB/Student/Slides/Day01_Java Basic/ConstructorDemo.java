//Description: demonstration of multiple constructors and using this.

public class ConstructorDemo {
    String objName;
    int objNum;

    // A constructor that allows the name and num to be set
    ConstructorDemo(String s, int i) {
        objName = s;
        objNum = i;
        System.out.println("ConstructorDemo(\"" + s + "\"," + i + ") called");
    }

    // Default Constructor initializes fields to something
    ConstructorDemo() {
        this("Default Name", 0);
        System.out.println("ConstructorDemo() called");
    }

    public static void main(String[] args) {
        try {
            ConstructorDemo d2 = new ConstructorDemo();
            ConstructorDemo d1 = new ConstructorDemo(args[0],Integer.parseInt(args[1]));
        } catch (Exception e) {
            System.out.println("Error: " + e);
        }
    }
}



