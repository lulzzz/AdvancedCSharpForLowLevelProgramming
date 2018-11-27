using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct Element
{
    public int A;
    public byte B;
}

[StructLayout(LayoutKind.Sequential, Pack = 0, Size = 5 * 128)]
public unsafe struct A
{
    public Element FirstElement;

    public ref Element this[int index]
    {
        get
        {
            if ((uint)(index) > 127)
                throw new IndexOutOfRangeException();
            fixed (Element* pElement = &FirstElement)
            {
                return ref Unsafe.AsRef<Element>(pElement + index);
            }
        }
    }
}

static class Program
{
    static void Main()
    {
        var a = new A();
        Console.WriteLine(a[1].A);
    }
}
