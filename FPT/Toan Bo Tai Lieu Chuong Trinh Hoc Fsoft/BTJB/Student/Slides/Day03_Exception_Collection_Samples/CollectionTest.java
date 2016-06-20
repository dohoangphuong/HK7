 // CollectionTest.java
 // Using the Collection interface.
 import java.awt.Color;
 import java.util.*;
 
 public class CollectionTest {
    private static final String colors[] = { "red", "white", "blue" };
 
    // create ArrayList, add objects to it and manipulate it
   public CollectionTest()
   {
      List list = new ArrayList();                        

      // add objects to list
      list.add( Color.MAGENTA );     // add a color object

      for ( int count = 0; count < colors.length; count++ )
         list.add( colors[ count ] );         

      list.add( Color.CYAN );        // add a color object

      // output list contents
      System.out.println( "\nArrayList: " );

      for ( int count = 0; count < list.size(); count++ )
         System.out.print( list.get( count ) + " " );

      // remove all String objects
      removeStrings( list );

      // output list contents
      System.out.println( "\n\nArrayList after calling removeStrings: " );

      for ( int count = 0; count < list.size(); count++ )
         System.out.print( list.get( count ) + " " );

   } // end constructor CollectionTest

   // remove String objects from Collection
   private void removeStrings( Collection collection )
   {
      Iterator iterator = collection.iterator(); // get iterator
                                                                
      // loop while collection has items                        
      while ( iterator.hasNext() )                              
                                                                
         if ( iterator.next() instanceof String )               
            iterator.remove();  // remove String object         
   }

   public static void main( String args[] )
   {
      new CollectionTest();
   } 

} // end class CollectionTest
