using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Ansi)]
public struct A
{
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
    public  string Val1;
}

public class Program
{
    static unsafe void Main()
    {
        Console.WriteLine("Marshal.SizeOf = {0} vs Unsafe.SizeOf = {1}",Marshal.SizeOf<A>(),  Unsafe.SizeOf<A>());
    }
}
