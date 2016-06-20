 // UsingToArray.java
 // Using method toArray.
 import java.util.*;
 
 public class UsingToArray {
                      
    // create LinkedList, add elements and convert to array
    public UsingToArray()
    {
      String colors[] = { "black", "blue", "yellow" };

      LinkedList links = new LinkedList( Arrays.asList( colors ) );

      links.addLast( "red" );   // add as last item 
      links.add( "pink" );      // add to the end   
      links.add( 3, "green" );  // add at 3rd index 
      links.addFirst( "cyan" ); // add as first item      

      // get LinkedList elements as an array     
      colors = ( String [] ) links.toArray( new String[ links.size() ] );

      System.out.println( "colors: " );

      for ( int count = 0; count < colors.length; count++ )
         System.out.println( colors[ count ] );
   }

   public static void main( String args[] )
   {
      new UsingToArray();
   }  
                                         
} // end class UsingToArray
