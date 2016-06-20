public class TestClass
{
	public static void main(String[] args)
	{
		Child oChild = new Child();
		Parent oParent = new Parent();
		oParent = oChild;
		System.out.println(oParent);
	}
}