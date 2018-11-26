using System;
using AdvancedDLSupport;
public interface IChapFourLib
{
    int GlobalVariable { get; set; }
    void IncrementTheGlobalVariable();
}
static class Program
{
    static void Main()
    {
        var lib = NativeLibraryBuilder.Default.ActivateInterface<IChapFourLib>("ChapFour");
        Console.WriteLine("Current Global Variable Value is: {0}", lib.GlobalVariable);
        chapFourLib.IncrementTheGlobalVariable();
        Console.WriteLine("Incremented Global Variable Value is: {0}", lib.GlobalVariable);
        Console.ReadLine();
    }
}
