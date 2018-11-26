[StructLayout(LayoutKind.Explicit)]
public struct MyUnion
{
  [FieldOffset(0)]
  public sbyte SignedByteVal1;
  [FieldOffset(0)]
  public byte UnsignedByteVal1;
}

[StructLayout(LayoutKind.Sequential)]
public struct MyStruct
{
  public MyUnion Union;
  public uint A;
}
