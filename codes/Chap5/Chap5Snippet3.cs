[StructLayout(LayoutKind.Explicit)]
public struct MyStruct
{
  [FieldOffset(0)]
  public sbyte SignedByteVal1;
  [FieldOffset(0)]
  public byte UnsignedByteVal1;
}
