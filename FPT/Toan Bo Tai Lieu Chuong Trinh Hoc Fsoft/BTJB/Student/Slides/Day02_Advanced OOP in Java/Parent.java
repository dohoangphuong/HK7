public class Parent extends GrandParent
{
	Parent()
	{
		print("Parent()\n");
	}

	Parent(int intVal)
	{
		print("Parent(intVal) => " + intVal + "\n");
	}

	public void pMethod1()
	{
		print("This is method 1 of the Parent class\n");
	}

	public String toString()
	{
		return "This is Parent class";
	}
}
