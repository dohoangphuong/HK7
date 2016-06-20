 // Sort2.java
 // Using a Comparator object with algorithm sort.
 import java.util.*;
 
 public class Sort2 {
    private static final String suits[] = 
       { "Hearts", "Diamonds", "Clubs", "Spades" };
 
    // output List elements
   public void printElements()
   {
      List list = Arrays.asList( suits ); // create List

      // output List elements
      System.out.println( "Unsorted array elements:\n" + list );

      // sort in descending order using a comparator
      Collections.sort( list, Collections.reverseOrder() ); 

      // output List elements
      System.out.println( "Sorted list elements:\n" + list );
   }
 
   public static void main( String args[] )
   {
      new Sort2().printElements();
   } 
                                          
} // end class Sort2
