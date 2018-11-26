using System;
using System.Runtime.InteropServices;
namespace ChapterTwo
{
	class Program
	{
		[DllImport("ChapTwo")]
		static extern int Sum(int a, int b);
		static void Main(string[] args)
		{
		    Console.WriteLine("1 + 2 = {0}", Sum(1, 2));
		}
	}
}
