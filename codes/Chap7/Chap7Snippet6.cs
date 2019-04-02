public class MyClass
{
	public int DoStuff(int a, int b)
	{
		return a + b;
		// This is a class method, the this parameter is supplied,
		// we need to use ldarg.1 instead of ldarg.0 for loading first parameter
		// ldarg.1
		// ldarg.2
		// add
		// ret
	}

	public static int DoStuff(int a, int b)
	{
		return a + b;

		// This is a static method, the this parameter is not supplied:
		// ldarg.0
		// ldarg.1
		// add
		// ret
	}
}