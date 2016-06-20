package vn.com.fsoft.java.lesson4;

import java.io.FileWriter;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.EmptyStackException;
import java.util.List;

public class ThrowAnException {
	
    private List<Integer> list;
    private static final int SIZE = 10;

    public void writeList() {
        PrintWriter out = null;
        
        if (list == null || list.isEmpty()) {
        	throw new EmptyStackException();
        }

        try {
            System.out.println("Entering try statement");
            out = new PrintWriter(new FileWriter("OutFile.txt"));
            for (int i = 0; i < SIZE; i++)
                out.println("Value at: " + i + " = " + list.get(i));
        } catch (ArrayIndexOutOfBoundsException e) {
            System.err.println("Caught ArrayIndexOutOfBoundsException: " + e.getMessage());
        } catch (IOException e) {
            System.err.println("Caught IOException: " + e.getMessage());
        } finally {
            if (out != null) {
                System.out.println("Closing PrintWriter");
                out.close();
            } else {
                System.out.println("PrintWriter not open");
            }
        }
    }
    
    public static void main(String[] args) {
    	ThrowAnException sample = new ThrowAnException();
    	sample.writeList();
    }
}
