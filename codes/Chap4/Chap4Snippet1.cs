using System;
using System.Runtime.InteropServices;

public static class DL {
  [DllImport("dl")]
  public static extern IntPtr dlopen(string library, int flags);
  [DllImport("dl")]
  public static extern IntPtr dlsym(IntPtr libraryHandle, string symbol);
  [DllImport("dl")]
  public static extern int dlclose(IntPtr libraryHandle);
}

public static class MySpecialLibrary {
  internal static IntPtr libraryHandle;
  static MySpecialLibrary()
  {
    libraryHandle = DL.dlopen("MySpecialLibrary.so", 1);
    Sum = Marshal.GetDelegateForFunctionPointer<Sum_dt>(DL.dlsym(libraryHandle, "Sum"));
  }
  public delegate int Sum_dt(int A, int B);
  public static Sum_dt Sum;

  public static void Main()
  {
    Console.WriteLine("1 + 2 = {0}", Sum(1, 2));
  }
}
