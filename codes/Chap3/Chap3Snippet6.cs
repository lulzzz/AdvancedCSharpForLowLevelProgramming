public unsafe void DoBufferAllocation()
{
	int* MyIntegerPointer = (int*)Marshal
	.AllocHGlobal(Marshal.SizeOf<int>()).ToPointer();
	
	// You can use it in a similar fashion as you would in C.
	*MyIntegerPointer = 123;
}