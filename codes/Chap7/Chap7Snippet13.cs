using System;
using System.Reflection.Emit;

class Program
{
    public delegate void Test_dt();
    static unsafe void Main(string[] args)
    {
        var example = new DynamicMethod("Test", typeof(void), new Type[0]);
        var il = example.GetILGenerator();
        var val = il.DeclareLocal(typeof(int));
        il.DeclareLocal(typeof(OverflowException));
        
        il.Emit(OpCodes.Ldc_I4, int.MaxValue);
        il.Emit(OpCodes.Stloc_0);
        
        il.BeginExceptionBlock();
        il.Emit(OpCodes.Ldloc_0);
        il.Emit(OpCodes.Ldc_I4_1);
        il.Emit(OpCodes.Add_Ovf);
        il.Emit(OpCodes.Stloc_0);
        il.BeginCatchBlock(typeof(OverflowException));
        il.Emit(OpCodes.Stloc_1);
        il.Emit(OpCodes.Ldloc_1);
        il.Emit(OpCodes.Call, typeof(OverflowException).GetMethod("ToString"));
        il.Emit(OpCodes.Call, typeof(Console).GetMethod("WriteLine", new []{typeof(string)}));
        il.BeginFinallyBlock();
        il.EmitWriteLine(val);
        il.EndExceptionBlock();
        il.Emit(OpCodes.Ret);
        
        var test = (Test_dt)example.CreateDelegate(typeof(Test_dt));
        test();
    }
}