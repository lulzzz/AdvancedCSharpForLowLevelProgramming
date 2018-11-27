using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Explicit, Size=16, Pack=8)]
public struct A
{
    [FieldOffset(0)]
    public byte Var1;
}

[StructLayout(LayoutKind.Explicit, Size=1, Pack=8)]
public struct B
{
    [FieldOffset(0)]
    public byte Var1;
    [FieldOffset(1)]
    public ushort Var2;
}

[StructLayout(LayoutKind.Explicit, Pack=8)]
public struct C {
    [FieldOffset(0)]
    public ulong Val1;

    [FieldOffset((8))]
    public byte Val2;
}

[StructLayout(LayoutKind.Explicit, Pack=8)]
public struct D
{
    [FieldOffset(0)]
    public byte Val1;
    [FieldOffset(1)]
    public int Val2;
}

[StructLayout(LayoutKind.Explicit, Pack=2)]
public struct E
{
    [FieldOffset(0)]
    public byte Val1;
    [FieldOffset(1)]
    public int Val2;
}

public class Program
{
    static void Main()
    {
        Console.WriteLine("Struct A Size: {0}", Marshal.SizeOf<A>());
        Console.WriteLine("Struct B Size: {0}", Marshal.SizeOf<B>());
        Console.WriteLine("Struct C Size: {0}", Marshal.SizeOf<C>());
        Console.WriteLine("Struct D Size: {0}", Marshal.SizeOf<D>());
        Console.WriteLine("Struct E Size: {0}", Marshal.SizeOf<E>());
    }
}
