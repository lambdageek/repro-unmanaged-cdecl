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

    public static void Main()
    {
	var x = new Helper.Helpr();

	Console.WriteLine ($"{x.GetType()}");
	bool isMono = typeof(object).Assembly.GetType("Mono.RuntimeStructs") != null;
	Console.WriteLine($"Hello World {(isMono ? "from Mono!" : "from CoreCLR!")}");
	var d = new Driv();
	MainFunc m = CalledFromNative;
	natural_capture (Marshal.GetFunctionPointerForDelegate(m));
	(new Thread((o)=> {
	    Console.WriteLine ("thread started");
	    natural_invoke ();
	    (o as Driv)?.sema?.Release ();
	})).Start(d);
	d.sema.Wait();
	Console.WriteLine ("done");

    }

    public static void CalledFromNative()
    {
	Console.WriteLine ("CalledFromNative");

	unsafe {
	    byte* p = ((delegate* unmanaged[Cdecl]<byte*>)&Helper.Helpr.natural_getter)();
	    string? s = Marshal.PtrToStringUTF8((IntPtr)p);
	    Console.WriteLine (s);
	}
    }


}

