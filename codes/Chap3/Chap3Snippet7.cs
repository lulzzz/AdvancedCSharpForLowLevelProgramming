public unsafe class Demo {
	public void DoBufferAllocation()
	{
		int* MyIntegerPointer = (int*)Marshal
		.AllocHGlobal(Marshal.SizeOf<int>()).ToPointer();
		
		*MyIntegerPointer = 123;
	}
}