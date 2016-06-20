public class GrandParent
{
	GrandParent()
	{
		print("GrandParent()\n");
	}

	GrandParent(String strVal)
	{
		print("GrandParent(strVal) => " + strVal + "\n");
	}

	public void gpMethod1()
	{
		print("This is method 1 of the GrandParent class\n");
	}

	public void print(String strValue)
	{
		System.out.println(strValue);
	}
}