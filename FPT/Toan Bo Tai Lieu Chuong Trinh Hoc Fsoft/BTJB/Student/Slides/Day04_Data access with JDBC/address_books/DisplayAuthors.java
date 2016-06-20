// DisplayAuthors.java
// Displaying the contents of the authors table.

import java.awt.*;
import java.sql.*;
import java.util.*;
import javax.swing.*;

public class DisplayAuthors extends JFrame
{

    // JDBC driver name and database URL
    static String JDBC_DRIVER = "com.mysql.jdbc.Driver";
    String DATABASE_URL = "jdbc:mysql://localhost:3306/test";

    // declare Connection and Statement for accessing
    // and querying database
    private Connection connection;
    private Statement statement;

    // constructor connects to database, queries database, processes
    // results and displays results in window
    public DisplayAuthors()
    {
        super( "Authors Table of Books Database" );
        // connect to database books and query database
        try
        {
            // load database driver class
            Class.forName( JDBC_DRIVER );

            // establish connection to database
            connection = DriverManager.getConnection( DATABASE_URL );

            // create Statement for querying database
            statement = connection.createStatement();

            // query database
            ResultSet resultSet = statement.executeQuery( "SELECT * FROM authors" );

            // process query results
            StringBuffer results = new StringBuffer();
            ResultSetMetaData metaData = resultSet.getMetaData();
            int numberOfColumns = metaData.getColumnCount();

            for ( int i = 1; i <= numberOfColumns; i++ )
                results.append( metaData.getColumnName( i ) + "\t" );

            results.append( "\n" );

            while ( resultSet.next() )
            {
                for ( int i = 1; i <= numberOfColumns; i++ )
                    results.append( resultSet.getObject( i ) + "\t" );
                results.append( "\n" );
            }

            // set up GUI and display window
            JTextArea textArea = new JTextArea( results.toString() );
            Container container = getContentPane();

            container.add( new JScrollPane( textArea ) );

            setSize( 300, 100 );  // set window size
            setVisible( true );   // display window

        }  // end try
        // detect problems interacting with the database
        catch ( SQLException sqlException )
        {
            JOptionPane.showMessageDialog( null, sqlException.getMessage(), "Database Error", JOptionPane.ERROR_MESSAGE );
            System.exit( 1 );
        }
        // detect problems loading database driver
        catch ( ClassNotFoundException classNotFound )
        {
            JOptionPane.showMessageDialog( null, classNotFound.getMessage(), "Driver Not Found", JOptionPane.ERROR_MESSAGE );
            System.exit( 1 );
        }
        // ensure statement and connection are closed properly
        finally
        {
            try
            {
                statement.close();
                connection.close();
            }
            // handle exceptions closing statement and connection
            catch ( SQLException sqlException )
            {
                JOptionPane.showMessageDialog( null,
                                               sqlException.getMessage(), "Database Error",
                                               JOptionPane.ERROR_MESSAGE );

                System.exit( 1 );
            }
        }

    }  // end DisplayAuthors constructor

    // launch the application
    public static void main( String args[] )
    {
        DisplayAuthors window = new DisplayAuthors();
        window.setDefaultCloseOperation( JFrame.EXIT_ON_CLOSE );
    }

}  // end class DisplayAuthors
