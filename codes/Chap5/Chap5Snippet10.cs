[StructLayout(LayoutKind.Explicit, Size=1, Pack=8)]
public struct A
{
  [FieldOffset(0)]
  public byte Var1;
  [FieldOffset(1)]
  public ushort Var2;
}
