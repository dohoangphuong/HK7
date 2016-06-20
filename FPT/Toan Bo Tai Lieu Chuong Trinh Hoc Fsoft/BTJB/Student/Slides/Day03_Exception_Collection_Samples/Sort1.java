// Sort1.java
// Using algorithm sort.
import java.util.*;

public class Sort1 {
   private static final String suits[] =  { "Hearts", "Diamonds", "Clubs", "Spades" };

   // display array elements
  public void printElements()
  {
     // create ArrayList
     List list = new ArrayList( Arrays.asList( suits ) );

     // output list
     System.out.println( "Unsorted array elements:\n" + list );

     Collections.sort( list ); // sort ArrayList

     // output list
     System.out.println( "Sorted array elements:\n" + list );
  }

   public static void main( String args[] )
   {
      new Sort1().printElements();
   }

} // end class Sort1