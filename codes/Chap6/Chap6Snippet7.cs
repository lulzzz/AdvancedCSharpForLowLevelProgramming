public delegate void Test_dt();
public struct MyStruct
{
	[MarshalAs(UnmanagedType.FunctionPtr)]
	public Test_dt Test;
}