 // UsingAsList.java
 // Using method asList.
 import java.util.*;
 
 public class UsingAsList {
    private static final String values[] = { "red", "white", "blue" };
    private List list;
 
    // initialize List and set value at location 1
   public UsingAsList()
   {
      list = Arrays.asList( values );   // get List      
      list.set( 1, "green" );           // change a value
   }

   // output List and array
   public void printElements()
   {
      System.out.print( "List elements : " );

      for ( int count = 0; count < list.size(); count++ )
         System.out.print( list.get( count ) + " " );

      System.out.print( "\nArray elements: " );

      for ( int count = 0; count < values.length; count++ )
         System.out.print( values[ count ] + " " );

      System.out.println();
   }

   public static void main( String args[] )
   {
      new UsingAsList().printElements();
   }   
                                        
} // end class UsingAsList
