.assembly extern System.Runtime
{
  .publickeytoken = (B0 3F 5F 7F 11 D5 0A 3A )                         // .?_....:
  .ver 6:0:0:0
}

.assembly helper
{
    .ver 1:0:0:0
    .hash algorithm 0x00008004
}

.module extern libnatural

.module helper.dll

.class public auto ansi beforefieldinit Helper.Helpr extends [System.Runtime]System.Object
{
    .method public hidebysig specialname rtspecialname instance void .ctor() cil managed
    {
	ret
    }

    .method public hidebysig static pinvokeimpl("libnatural" cdecl)
       unmanaged cdecl  uint8*  natural_getter() cil managed preservesig
    {
    }
}
