using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct Element
{
    public int A;
    public byte B;
}
public unsafe struct A
{
    public fixed byte Data[640]; // 128 elements * 5 bytes (Size of Element)
}

public class Program
{
    static unsafe void Main()
    {
         A a = new A();
        var ptrToByValueArrayOfStructs = (Element*)a.Data;
        Console.WriteLine(ptrToByValueArrayOfStructs[0].A);
    }
}
