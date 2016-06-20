 // ForCounter.java
 // Counter-controlled repetition with the for statement.
 import java.awt.Graphics;
 
 import javax.swing.JApplet;
 
 public class ForCounter extends JApplet {
 
    // draw lines on applet’s background
   public void paint( Graphics g )
   {
      super.paint( g );  // call paint method inherited from JApplet

      // for statement header includes initialization,  
      // repetition condition and increment
      for ( int counter = 1; counter <= 10; counter++ ) 
         g.drawLine( 10, 10, 250, counter * 10 );

   } // end method paint

} // end class ForCounter
