using System;
using System.Threading;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

public class Driv
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void MainFunc();
    
    public SemaphoreSlim sema;

    Driv () {
	sema = new (0,1);
    }

    [DllImport("libnatural", EntryPoint="natural_capture")]
    public static extern int natural_capture(IntPtr p);

    [DllImport("libnatural", EntryPoint="natural_invoke")]
    public static extern void natural_invoke();

    [DllImport("libnatural", EntryPoint="natural_getter", CallingConvention=CallingConvention.Cdecl)]
    public static unsafe extern byte* natural_getter();

    public static void Main()
    {
#if false
	var x = new Helper.Helpr();

	Console.WriteLine ($"{x.GetType()}");
#endif
	bool isMono = typeof(object).Assembly.GetType("Mono.RuntimeStructs") != null;
	Console.WriteLine($"!Hello World {(isMono ? "from Mono!" : "from CoreCLR!")}");
	var d = new Driv();
	//MainFunc m = CalledFromNative;
	//natural_capture (Marshal.GetFunctionPointerForDelegate(m));
	//natural_invoke ();
	CalledFromNative();
	Console.WriteLine ("done");

    }

    public static void CalledFromNative()
    {
	Console.WriteLine ("CalledFromNative");

	unsafe {
	    delegate *managed<byte*> f0 = &natural_getter;
	    IntPtr f1 = (IntPtr)f0;
	    var f2 = (delegate* unmanaged[Cdecl]<byte*>)f1;
	    byte* p = f2();
	    string? s = Marshal.PtrToStringUTF8((IntPtr)p);
	    Console.WriteLine (s);
	}
    }


}

