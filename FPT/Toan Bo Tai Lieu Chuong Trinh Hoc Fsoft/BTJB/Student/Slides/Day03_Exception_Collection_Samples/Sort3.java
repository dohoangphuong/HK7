 // Sort3.java
 // Creating a custom Comparator class.
 import java.util.*;

 public class Sort3 {

    public void printElements()
    {
       List list = new ArrayList(); // create List

      list.add( new Time2(  6, 24, 34 ) );
      list.add( new Time2( 18, 14, 05 ) );
      list.add( new Time2(  8, 05, 00 ) );
      list.add( new Time2( 12, 07, 58 ) );
      list.add( new Time2(  6, 14, 22 ) );

      // output List elements
      System.out.println( "Unsorted array elements:\n" + list );

      // sort in order using a comparator
      Collections.sort( list, new TimeComparator() );

      // output List elements
      System.out.println( "Sorted list elements:\n" + list );
   }

   public static void main( String args[] )
   {
      new Sort3().printElements();
   }

   private class TimeComparator implements Comparator {
      int hourCompare, minuteCompare, secondCompare;
      Time2 time1, time2;

      public int compare(Object object1, Object object2)
      {
         // cast the objects
         time1 = (Time2)object1;
         time2 = (Time2)object2;

         hourCompare = new Integer( time1.getHour() ).compareTo(
                       new Integer( time2.getHour() ) );

         // test the hour first
         if ( hourCompare != 0 )
            return hourCompare;

         minuteCompare = new Integer( time1.getMinute() ).compareTo(
                         new Integer( time2.getMinute() ) );

         // then test the minute
         if ( minuteCompare != 0 )
            return minuteCompare;

         secondCompare = new Integer( time1.getSecond() ).compareTo(
                         new Integer( time2.getSecond() ) );

         return secondCompare; // return result of comparing seconds
      }

   } // end class TimeComparator

} // end class Sort3

class Time2
{
	private int m_iHour;
	private int m_iMinute;
	private int m_iSecond;

	Time2(int hour, int minute, int second)
	{
		m_iHour = hour;
		m_iMinute = minute;
		m_iSecond = second;
	}

	public void setHour(int iValue)
	{
		m_iHour = iValue;
	}

	public int getHour()
	{
		return m_iHour;
	}

	public void setMinute(int iValue)
	{
		m_iMinute = iValue;
	}

	public int getMinute()
	{
		return m_iMinute;
	}

	public void setSecond(int iValue)
	{
		m_iSecond = iValue;
	}

	public int getSecond()
	{
		return m_iSecond;
	}

	public String toString()
	{
		return m_iHour + ":" + m_iMinute + ":" + m_iSecond;
	}
}
