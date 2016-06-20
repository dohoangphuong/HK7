public class Child extends Parent
{
	Child()
	{
		print("Child()\n");
	}

	Child(long lngVal)
	{
		//super(4);
		//super.pMethod1();
		print("Child(lngVal) => " + lngVal);
	}

	public void cMethod1()
	{
		print("This is method 1 of the Child class\n");
	}

	public String toString()
	{
		return "This is Child class";
	}
}
