public class MethodTest {
  static public void main( String args[] ){
     MethodTest anInstance = new MethodTest ();
     anInstance.test(1, 2);
  }
  void test(int i, long j) {
     System.out.println("int = 1, long = 2");
  }
  void test(long i, int j) {
     System.out.println("long = 1, int = 2");
  }
 }
