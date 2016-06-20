  // WordTypeCount.java
  // Program counts the number of occurrences of each word in a string
  import java.awt.*;
  import java.awt.event.*;
  import java.util.*;
  import javax.swing.*;

  public class WordTypeCount extends JFrame {
    private JTextArea inputField;
    private JLabel prompt;
    private JTextArea display;
    private JButton goButton;

    private Map map;

    public WordTypeCount()
    {
       super( "Word Type Count" );
       inputField = new JTextArea( 3, 20 );

       map = new HashMap();

       goButton = new JButton( "Go" );
       goButton.addActionListener(

          new ActionListener() { // inner class

             public void actionPerformed( ActionEvent event )
             {
                createMap();
                display.setText( createOutput() );
             }

          } // end inner class

       ); // end call to addActionListener

       prompt = new JLabel( "Enter a string:" );
       display = new JTextArea( 15, 20 );
       display.setEditable( false );

       JScrollPane displayScrollPane = new JScrollPane( display );

       // add components to GUI
       Container container = getContentPane();
       container.setLayout( new FlowLayout() );
       container.add( prompt );
       container.add( inputField );
       container.add( goButton );
       container.add( displayScrollPane );

       setSize( 400, 400 );
       show();

    } // end constructor

    // create map from user input
    private void createMap()
    {
       String input = inputField.getText();
       StringTokenizer tokenizer = new StringTokenizer( input );

        while ( tokenizer.hasMoreTokens() ) {
          String word = tokenizer.nextToken().toLowerCase(); // get word

          // if the map contains the word
          if ( map.containsKey( word ) ) {

             Integer count = (Integer) map.get( word ); // get value

             // increment value
             map.put( word, new Integer( count.intValue() + 1 ) );
          }
          else // otherwise add word with a value of 1 to map
             map.put( word, new Integer( 1 ) );

        } // end while

    } // end method createMap

    // create string containing map values
    private String createOutput() {
       StringBuffer output = new StringBuffer( "" );
       Iterator keys = map.keySet().iterator();

       // iterate through the keys
       while ( keys.hasNext() ) {
          Object currentKey = keys.next();

          // output the key-value pairs
          output.append( currentKey + "\t" +
                         map.get( currentKey ) + "\n" );
       }

       output.append( "size: " + map.size() + "\n" );
       output.append( "isEmpty: " + map.isEmpty() + "\n" );

       return output.toString();

   } // end method createOutput

   public static void main( String args[] )
   {
      WordTypeCount application = new WordTypeCount();
      application.setDefaultCloseOperation( JFrame.EXIT_ON_CLOSE );
   }

} // end class WordTypeCount
