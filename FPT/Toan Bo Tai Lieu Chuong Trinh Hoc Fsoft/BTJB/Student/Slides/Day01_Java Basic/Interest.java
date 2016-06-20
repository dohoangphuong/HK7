// Interest.java
// Calculating compound interest.
import java.text.NumberFormat;  // class for numeric formatting
import java.util.Locale;  // class for country-specific information

import javax.swing.JOptionPane;
import javax.swing.JTextArea;

public class Interest {

  public static void main( String args[] )
  {
     double amount;       // amount on deposit at end of each year
     double principal = 1000.0;  // initial amount before interest
     double rate = 0.05;         // interest rate

     // create NumberFormat for currency in US dollar format
     NumberFormat moneyFormat =
        NumberFormat.getCurrencyInstance( Locale.US );

     // create JTextArea to display output
     JTextArea outputTextArea = new JTextArea();

     // set first line of text in outputTextArea
     outputTextArea.setText( "Year\tAmount on deposit\n" );
       // calculate amount on deposit for each of ten years
       for ( int year = 1; year <= 10; year++ ) {

          // calculate new amount for specified year
          amount = principal * Math.pow( 1.0 + rate, year );

          // append one line of text to outputTextArea
          outputTextArea.append( year + "\t" +
             moneyFormat.format( amount ) + "\n" );

       } // end for

       // display results
       JOptionPane.showMessageDialog( null, outputTextArea,
          "Compound Interest", JOptionPane.INFORMATION_MESSAGE );

       System.exit( 0 );  // terminate the application

    } // end main

 } // end class Interest

