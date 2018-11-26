public void DoBufferAllocation()
{
	unsafe {
		int* MyIntegerPointer = (int*)Marshal
		.AllocHGlobal(Marshal.SizeOf<int>()).ToPointer();
		
		*MyIntegerPointer = 123;
	}
}