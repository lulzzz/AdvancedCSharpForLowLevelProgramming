[StructLayout(LayoutKind.Explicit)]
public struct Example
{
  [FieldOffset(0)]
  public byte Val1;
  [FieldOffset(2)]
  public ushort Val2;
  [FieldOffset(4)]
  public int Val3;
  [FieldOffset(1)]
  public byte Val4;
}
