using System;
using System.Reflection.Emit;

class Program
{
    public delegate void Example_dt();

    static void Main(string[] args)
    {
        var method = new DynamicMethod("Test", typeof(void), new Type[0]);
        method.InitLocals = true;
        var il = method.GetILGenerator();
        var index = il.DeclareLocal(typeof(int));
        var bodyLabel = il.DefineLabel();
        var conditionLabel = il.DefineLabel();
        il.Emit(OpCodes.Br, conditionLabel);
        il.MarkLabel(bodyLabel);
        il.EmitWriteLine(index);
        il.Emit(OpCodes.Ldloc_0);
        il.Emit(OpCodes.Ldc_I4_1);
        il.Emit(OpCodes.Add);
        il.Emit(OpCodes.Stloc_0);
        il.MarkLabel(conditionLabel);
        il.Emit(OpCodes.Ldloc_0);
        il.Emit(OpCodes.Ldc_I4, 10);
        il.Emit(OpCodes.Clt);
        il.Emit(OpCodes.Brtrue, bodyLabel);
        il.Emit(OpCodes.Ret);
        var example = (Example_dt) method.CreateDelegate(typeof(Example_dt));
        example();
    }
}