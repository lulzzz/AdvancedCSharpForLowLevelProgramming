using System;
using System.Reflection;
using System.Reflection.Emit;

class Program
{
    public delegate int Add_dt(int a, int b);

    static void Main(string[] args)
    {
        var assBuilder = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName("DynamicAss"), AssemblyBuilderAccess.RunAndCollect);
        var modBuilder = assBuilder.DefineDynamicModule("DynamicMod");
        var typeBuilder = modBuilder.DefineType("Math",
            TypeAttributes.Public | TypeAttributes.Class | TypeAttributes.Sealed | TypeAttributes.Abstract |
            TypeAttributes.AnsiClass);
        var method = typeBuilder.DefineMethod("Add", MethodAttributes.Public | MethodAttributes.Static, CallingConventions.Standard,
            typeof(int), new[] {typeof(int), typeof(int)});
        var il = method.GetILGenerator();
        il.Emit(OpCodes.Ldarg_0);
        il.Emit(OpCodes.Ldarg_1);
        il.Emit(OpCodes.Add_Ovf);
        il.Emit(OpCodes.Ret);
        var definedType = typeBuilder.CreateType();
        var add = (Add_dt)definedType.GetMethod("Add").CreateDelegate(typeof(Add_dt));
        Console.WriteLine("2 + 2 = {0}", add(2, 2));
    }
}