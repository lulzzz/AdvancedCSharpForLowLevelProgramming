using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

class Program
{
    public delegate int Add_dt(int a, int b);

    private static readonly IReadOnlyCollection<MetadataReference> _references = new[] {
        MetadataReference.CreateFromFile(typeof(object).GetTypeInfo().Assembly.Location)
    };
    static void Main(string[] args)
    {

        var syntaxTree = CSharpSyntaxTree.ParseText(@"
            public static class Math {
                public static int Add(int a, int b) => a + b;
            }
        ");
        var compilation = CSharpCompilation.Create("Example", new[] {syntaxTree}, 
            options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary)).AddReferences(_references);
        var assemblyPath = Path.Combine(Path.GetDirectoryName(typeof(Program).Assembly.Location), "Example.dll");
        compilation.Emit(assemblyPath);

        var assembly = Assembly.LoadFile(assemblyPath);
        var mathType = assembly.GetTypes().First(I => I.Name == "Math");
        var method = mathType.GetMethod("Add");
        var add = (Add_dt)method.CreateDelegate(typeof(Add_dt));
        Console.WriteLine("2 + 2 = {0}", add(2, 2));
    }
}