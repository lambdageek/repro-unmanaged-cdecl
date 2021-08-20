
# Repro

## Requirements

.NET 6 (preview 7 or RC1 is good)

## Building


```console
make -C natural
dotnet build driv/driv.csproj -r osx-x64 -p:UseMonoRuntime=true --self-contained
```

## Runnning

```console
driv/bin/onmono/Debug/net6.0/osx-x64/driv
```

Should crash with something like

```
mono_threads_enter_gc_safe_region_unbalanced Cannot transition thread 0x700005ce3000 from STATE_BLOCKING with DO_BLOCKING

=================================================================
	Native Crash Reporting
=================================================================
Got a SIGABRT while executing native code. This usually indicates
a fatal error in the mono runtime or one of the native libraries
used by your application.
=================================================================

=================================================================
	Native stacktrace:
=================================================================
	0x1090915e6 - .../driv/bin/onmono/Debug/net6.0/osx-x64/libcoreclr.dylib : mono_dump_native_crash_info
	0x109030e7e - .../driv/bin/onmono/Debug/net6.0/osx-x64/libcoreclr.dylib : mono_handle_native_crash
	0x109090ee2 - .../driv/bin/onmono/Debug/net6.0/osx-x64/libcoreclr.dylib : sigabrt_signal_handler
	0x7fff203cbd7d - /usr/lib/system/libsystem_platform.dylib : _sigtramp
	0x112c5054b - Unknown
	0x7fff202db406 - /usr/lib/system/libsystem_c.dylib : abort
	0x1090de908 - .../driv/bin/onmono/Debug/net6.0/osx-x64/libcoreclr.dylib : monoeg_assert_abort
	0x108f0ce08 - .../driv/bin/onmono/Debug/net6.0/osx-x64/libcoreclr.dylib : mono_log_write_logfile
	0x1090ded78 - .../driv/bin/onmono/Debug/net6.0/osx-x64/libcoreclr.dylib : monoeg_g_logv
	0x1090def12 - .../driv/bin/onmono/Debug/net6.0/osx-x64/libcoreclr.dylib : monoeg_g_log
	0x108f2452c - .../driv/bin/onmono/Debug/net6.0/osx-x64/libcoreclr.dylib : mono_threads_transition_do_blocking
	0x108f25c01 - .../driv/bin/onmono/Debug/net6.0/osx-x64/libcoreclr.dylib : mono_threads_enter_gc_safe_region_unbalanced_with_info
	0x108f25c88 - .../driv/bin/onmono/Debug/net6.0/osx-x64/libcoreclr.dylib : mono_threads_enter_gc_safe_region_unbalanced
	0x10ab992c3 - Unknown
	0x10ab98f00 - Unknown
```

# Running on CoreCLR

Build without `-p:UseMonoRuntime=true`

```
dotnet build driv/driv.csproj -r osx-x64 --self-contained
```

Run as

```
driv/bin/onclr/Debug/net6.0/osx-x64/driv
```

Output:
```
Unhandled exception. System.TypeLoadException: The signature is incorrect.
Abort trap: 6
```
