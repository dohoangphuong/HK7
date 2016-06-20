public class StringTest
{
	public static void main(String[] args)
	{
		String me = "Roger";

		if (me == "Roger")
			System.out.println("Yes, I am me");
		else
			System.out.println("No, I am not me");

		String shortName = me.substring(0,3);
		System.out.println(shortName);

		if (shortName == "Rog")
			System.out.println("Very good");
		else
			System.out.println("Trouble here");

		if(shortName.equals("Rog"))
			System.out.println("Do it this way");
	}
}
