using System;
using System.Reflection;
using System.Reflection.Emit;

public class Program
{
   public delegate int DoAdd_dt(int a);
   public static void Main()
   {
      var myTypeBuilder = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName("DynamicAss"), 
         AssemblyBuilderAccess.Run).DefineDynamicModule("AdderExceptionMod").DefineType("Adder");
      var myMethodBuilder = myTypeBuilder.DefineMethod("DoAdd",MethodAttributes.Public |
                                                               MethodAttributes.Static,typeof(int),new Type[]{typeof(int)});
      var il = myMethodBuilder.GetILGenerator();
      var end = il.DefineLabel();
      il.DeclareLocal(typeof(int));
      il.BeginExceptionBlock();
      il.Emit(OpCodes.Ldarg_0);
      il.Emit(OpCodes.Ldc_I4, int.MaxValue);
      il.Emit(OpCodes.Add_Ovf);
      il.Emit(OpCodes.Stloc_0);
      il.Emit(OpCodes.Leave_S, end);
      il.BeginFaultBlock();
      il.EmitWriteLine("Fault block called.");
      il.EndExceptionBlock();
      il.MarkLabel(end);
      il.Emit(OpCodes.Ldloc_0);
      il.Emit(OpCodes.Ret);

      var add = (DoAdd_dt)myTypeBuilder.CreateType().GetMethod("DoAdd").CreateDelegate(typeof(DoAdd_dt));
      Console.WriteLine(add(1));
   }
}