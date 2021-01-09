
//  Microsoft (R) .NET Framework IL Disassembler.  Version 4.8.3928.0




// Metadata version: v4.0.30319
.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 4:0:0:0
}
.assembly 'Lessons (рекурсия)'
{
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::.ctor() = ( 01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78   // ....T..WrapNonEx
                                                                                                             63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01 )       // ceptionThrows.

  // --- Следующий настраиваемый атрибут добавлен автоматически, не следует отменять преобразование в комментарий -------
  //  .custom instance void [mscorlib]System.Diagnostics.DebuggableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggableAttribute/DebuggingModes) = ( 01 00 02 00 00 00 00 00 ) 

  .custom instance void [mscorlib]System.Reflection.AssemblyTitleAttribute::.ctor(string) = ( 01 00 1A 4C 65 73 73 6F 6E 73 20 28 D1 80 D0 B5   // ...Lessons (....
                                                                                              D0 BA D1 83 D1 80 D1 81 D0 B8 D1 8F 29 00 00 )    // ............)..
  .custom instance void [mscorlib]System.Reflection.AssemblyDescriptionAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyConfigurationAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyCompanyAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyProductAttribute::.ctor(string) = ( 01 00 1A 4C 65 73 73 6F 6E 73 20 28 D1 80 D0 B5   // ...Lessons (....
                                                                                                D0 BA D1 83 D1 80 D1 81 D0 B8 D1 8F 29 00 00 )    // ............)..
  .custom instance void [mscorlib]System.Reflection.AssemblyCopyrightAttribute::.ctor(string) = ( 01 00 12 43 6F 70 79 72 69 67 68 74 20 C2 A9 20   // ...Copyright .. 
                                                                                                  20 32 30 32 30 00 00 )                            //  2020..
  .custom instance void [mscorlib]System.Reflection.AssemblyTrademarkAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComVisibleAttribute::.ctor(bool) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 36 31 32 37 65 36 35 38 2D 64 66 64 33   // ..$6127e658-dfd3
                                                                                                  2D 34 65 39 63 2D 38 64 62 36 2D 63 38 37 30 38   // -4e9c-8db6-c8708
                                                                                                  63 61 64 33 32 39 34 00 00 )                      // cad3294..
  .custom instance void [mscorlib]System.Reflection.AssemblyFileVersionAttribute::.ctor(string) = ( 01 00 07 31 2E 30 2E 30 2E 30 00 00 )             // ...1.0.0.0..
  .custom instance void [mscorlib]System.Runtime.Versioning.TargetFrameworkAttribute::.ctor(string) = ( 01 00 1C 2E 4E 45 54 46 72 61 6D 65 77 6F 72 6B   // ....NETFramework
                                                                                                        2C 56 65 72 73 69 6F 6E 3D 76 34 2E 37 2E 32 01   // ,Version=v4.7.2.
                                                                                                        00 54 0E 14 46 72 61 6D 65 77 6F 72 6B 44 69 73   // .T..FrameworkDis
                                                                                                        70 6C 61 79 4E 61 6D 65 14 2E 4E 45 54 20 46 72   // playName..NET Fr
                                                                                                        61 6D 65 77 6F 72 6B 20 34 2E 37 2E 32 )          // amework 4.7.2
  .hash algorithm 0x00008004
  .ver 1:0:0:0
}
.module 'Lessons (рекурсия).exe'
// MVID: {B8275EB6-AD94-41F3-BE84-61DB737C9AB0}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00020003    //  ILONLY 32BITPREFERRED
// Image base: 0x0BC40000


// =============== CLASS MEMBERS DECLARATION ===================

.class private auto ansi beforefieldinit 'Lessons__рекурсия_'.Program
       extends [mscorlib]System.Object
{
  .method private hidebysig static void  PrintArray(int32[] 'array',
                                                    [opt] int32 i) cil managed
  {
    .param [2] = int32(0x00000000)
    // Размер кода:       42 (0x2a)
    .maxstack  8
    IL_0000:  ldarg.1
    IL_0001:  ldarg.0
    IL_0002:  ldlen
    IL_0003:  conv.i4
    IL_0004:  bge.s      IL_0029

    IL_0006:  ldstr      "{0} "
    IL_000b:  ldarg.0
    IL_000c:  ldarg.1
    IL_000d:  ldelem.i4
    IL_000e:  box        [mscorlib]System.Int32
    IL_0013:  call       string [mscorlib]System.String::Format(string,
                                                                object)
    IL_0018:  call       void [mscorlib]System.Console::Write(string)
    IL_001d:  ldarg.0
    IL_001e:  ldarg.1
    IL_001f:  ldc.i4.1
    IL_0020:  add
    IL_0021:  dup
    IL_0022:  starg.s    i
    IL_0024:  call       void 'Lessons__рекурсия_'.Program::PrintArray(int32[],
                                                                               int32)
    IL_0029:  ret
  } // end of method Program::PrintArray

  .method private hidebysig static int32 
          SumArray(int32[] 'array',
                   [opt] int32 i) cil managed
  {
    .param [2] = int32(0x00000000)
    // Размер кода:       25 (0x19)
    .maxstack  8
    IL_0000:  ldarg.1
    IL_0001:  ldarg.0
    IL_0002:  ldlen
    IL_0003:  conv.i4
    IL_0004:  blt.s      IL_0008

    IL_0006:  ldc.i4.0
    IL_0007:  ret

    IL_0008:  ldarg.0
    IL_0009:  ldarg.1
    IL_000a:  ldelem.i4
    IL_000b:  ldarg.0
    IL_000c:  ldarg.1
    IL_000d:  ldc.i4.1
    IL_000e:  add
    IL_000f:  dup
    IL_0010:  starg.s    i
    IL_0012:  call       int32 'Lessons__рекурсия_'.Program::SumArray(int32[],
                                                                              int32)
    IL_0017:  add
    IL_0018:  ret
  } // end of method Program::SumArray

  .method private hidebysig static int64 
          SumDigits(int64 num) cil managed
  {
    // Размер кода:       30 (0x1e)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldc.i4.s   10
    IL_0003:  conv.i8
    IL_0004:  div
    IL_0005:  brtrue.s   IL_000d

    IL_0007:  ldarg.0
    IL_0008:  ldc.i4.s   10
    IL_000a:  conv.i8
    IL_000b:  rem
    IL_000c:  ret

    IL_000d:  ldarg.0
    IL_000e:  ldc.i4.s   10
    IL_0010:  conv.i8
    IL_0011:  rem
    IL_0012:  ldarg.0
    IL_0013:  ldc.i4.s   10
    IL_0015:  conv.i8
    IL_0016:  div
    IL_0017:  call       int64 'Lessons__рекурсия_'.Program::SumDigits(int64)
    IL_001c:  add
    IL_001d:  ret
  } // end of method Program::SumDigits

  .method private hidebysig static void  Main(string[] args) cil managed
  {
    .entrypoint
    // Размер кода:       104 (0x68)
    .maxstack  3
    .locals init ([0] int64 str)
    IL_0000:  ldc.i4.8
    IL_0001:  newarr     [mscorlib]System.Int32
    IL_0006:  dup
    IL_0007:  ldtoken    field valuetype '<PrivateImplementationDetails>'/'__StaticArrayInitTypeSize=32' '<PrivateImplementationDetails>'::B450D8C5C327CC1DF1EF6CF186BD7E14663772872FEE77CF78574EC8316834BE
    IL_000c:  call       void [mscorlib]System.Runtime.CompilerServices.RuntimeHelpers::InitializeArray(class [mscorlib]System.Array,
                                                                                                        valuetype [mscorlib]System.RuntimeFieldHandle)
    IL_0011:  ldc.i8     0x3ade68b1
    IL_001a:  stloc.0
    IL_001b:  ldstr      bytearray (1C 04 30 04 41 04 41 04 38 04 32 04 3A 00 20 00 ) // ..0.A.A.8.2.:. .
    IL_0020:  call       void [mscorlib]System.Console::Write(string)
    IL_0025:  dup
    IL_0026:  ldc.i4.0
    IL_0027:  call       void 'Lessons__рекурсия_'.Program::PrintArray(int32[],
                                                                               int32)
    IL_002c:  ldstr      bytearray (0A 00 21 04 43 04 3C 04 3C 04 30 04 20 00 32 04   // ..!.C.<.<.0. .2.
                                    41 04 35 04 45 04 20 00 47 04 38 04 41 04 35 04   // A.5.E. .G.8.A.5.
                                    3B 04 20 00 32 04 20 00 3C 04 30 04 41 04 41 04   // ;. .2. .<.0.A.A.
                                    38 04 32 04 35 04 20 00 40 04 30 04 32 04 3D 04   // 8.2.5. .@.0.2.=.
                                    30 04 20 00 3D 00 20 00 )                         // 0. .=. .
    IL_0031:  call       void [mscorlib]System.Console::Write(string)
    IL_0036:  ldc.i4.0
    IL_0037:  call       int32 'Lessons__рекурсия_'.Program::SumArray(int32[],
                                                                              int32)
    IL_003c:  call       void [mscorlib]System.Console::WriteLine(int32)
    IL_0041:  ldstr      bytearray (0A 00 21 04 43 04 3C 04 3C 04 30 04 20 00 32 04   // ..!.C.<.<.0. .2.
                                    41 04 35 04 45 04 20 00 46 04 38 04 44 04 40 04   // A.5.E. .F.8.D.@.
                                    20 00 32 04 20 00 47 04 38 04 41 04 3B 04 35 04   //  .2. .G.8.A.;.5.
                                    20 00 22 00 7B 00 30 00 7D 00 22 00 20 00 40 04   //  .".{.0.}.". .@.
                                    30 04 32 04 3D 04 30 04 20 00 3D 00 20 00 )       // 0.2.=.0. .=. .
    IL_0046:  ldloc.0
    IL_0047:  box        [mscorlib]System.Int64
    IL_004c:  call       string [mscorlib]System.String::Format(string,
                                                                object)
    IL_0051:  call       void [mscorlib]System.Console::Write(string)
    IL_0056:  ldloc.0
    IL_0057:  call       int64 'Lessons__рекурсия_'.Program::SumDigits(int64)
    IL_005c:  call       void [mscorlib]System.Console::WriteLine(int64)
    IL_0061:  call       string [mscorlib]System.Console::ReadLine()
    IL_0066:  pop
    IL_0067:  ret
  } // end of method Program::Main

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Размер кода:       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ret
  } // end of method Program::.ctor

} // end of class 'Lessons__рекурсия_'.Program

.class private auto ansi sealed '<PrivateImplementationDetails>'
       extends [mscorlib]System.Object
{
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .class explicit ansi sealed nested private '__StaticArrayInitTypeSize=32'
         extends [mscorlib]System.ValueType
  {
    .pack 1
    .size 32
  } // end of class '__StaticArrayInitTypeSize=32'

  .field static assembly initonly valuetype '<PrivateImplementationDetails>'/'__StaticArrayInitTypeSize=32' B450D8C5C327CC1DF1EF6CF186BD7E14663772872FEE77CF78574EC8316834BE at I_00002BA8
} // end of class '<PrivateImplementationDetails>'


// =============================================================

.data cil I_00002BA8 = bytearray (
                 05 00 00 00 0C 00 00 00 40 00 00 00 4E 00 00 00  // ........@...N...
                 03 00 00 00 09 00 00 00 12 00 00 00 33 00 00 00) // ............3...
// *********** ДИЗАССЕМБЛИРОВАНИЕ ЗАВЕРШЕНО ***********************
// ВНИМАНИЕ: создан файл ресурсов Win32 C:\Users\Temich\Desktop\Программирование\Geekbrains\GeekBrains-Home_Tasks\Lesson 7 (28.12.20)\Lessons (рекурсия)_ILdasm\ILdasm dump.res
