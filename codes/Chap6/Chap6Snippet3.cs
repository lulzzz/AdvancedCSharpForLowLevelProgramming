using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using AdvancedDLSupport;

[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Ansi, Size = 128, Pack = 1)]
public struct ByValCharArray
{
    [FieldOffset(0)] public byte FirstElement;

    public unsafe string StringVal => Encoding.ASCII.GetString((byte*)Unsafe.AsPointer(ref FirstElement), 128);
    public unsafe char this[int index]
    {
        get => StringVal[index];
        set => ((byte*)Unsafe.AsPointer(ref FirstElement))[index] = Encoding.ASCII.GetBytes(new [] {value})[0];
    }
}

public unsafe interface IChapSixLib
{
    void AnsiString(char* str);
    void AnsiString([MarshalAs(UnmanagedType.LPStr)] string str);
    void AnsiString(ref ByValCharArray val);
    IntPtr Initialize();
    void SetDefaultMessage(ref ByValCharArray val);
    void SetDefaultMessage2([MarshalAs(UnmanagedType.LPStr)] StringBuilder val);
}


public class Program
{
    static unsafe void Main()
    {
        var lib = NativeLibraryBuilder.Default.ActivateInterface<IChapSixLib>("ChapSix");
        var testVal = new StringBuilder(128);
        lib.SetDefaultMessage2(testVal);
        var example = new StringBuilder("Test\0Test");
        var result = Unsafe.AsRef<ByValCharArray>(lib.Initialize().ToPointer());
        lib.SetDefaultMessage(ref result);
        
        Console.WriteLine("testVal: {0}", testVal);
        Console.WriteLine("exmaple: {0}", example);
        Console.WriteLine("result.StringVal: {0}", result.StringVal);
        
        lib.AnsiString(ref result);
    }
}
