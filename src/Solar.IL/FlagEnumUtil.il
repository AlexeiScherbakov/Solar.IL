#include "version.h"

.class public abstract sealed auto ansi beforefieldinit
    Solar.FlagEnumUtil
        extends [CORE_ASSEMBLY]System.Object
{
    .custom instance void [CORE_ASSEMBLY]System.Runtime.CompilerServices.ExtensionAttribute::.ctor()
     = (01 00 00 00 )

    .method public hidebysig static !!0/*TEnum*/
        Or<valuetype .ctor (class [CORE_ASSEMBLY]System.Enum, class [CORE_ASSEMBLY]System.ValueType) TEnum>(
            !!0/*TEnum*/ this,
            !!0/*TEnum*/ 'value'
        ) cil managed aggressiveinlining
    {
        .custom instance void [CORE_ASSEMBLY]System.Runtime.CompilerServices.ExtensionAttribute::.ctor()
         = (01 00 00 00 )
        .maxstack 2

        ldarg.0
        ldarg.1
        or
        ret
    }

    .method public hidebysig static !!0/*TEnum*/
        And<valuetype .ctor (class [CORE_ASSEMBLY]System.Enum, class [CORE_ASSEMBLY]System.ValueType) TEnum>(
            !!0/*TEnum*/ this,
            !!0/*TEnum*/ 'value'
        ) cil managed aggressiveinlining
    {
        .custom instance void [CORE_ASSEMBLY]System.Runtime.CompilerServices.ExtensionAttribute::.ctor()
         = (01 00 00 00 )
        .maxstack 2

        ldarg.0
        ldarg.1
        and
        ret
    }

    .method public hidebysig static !!0/*TEnum*/
        Xor<valuetype .ctor (class [CORE_ASSEMBLY]System.Enum, class [CORE_ASSEMBLY]System.ValueType) TEnum>(
            !!0/*TEnum*/ this,
            !!0/*TEnum*/ 'value'
        ) cil managed aggressiveinlining
    {
        .custom instance void [CORE_ASSEMBLY]System.Runtime.CompilerServices.ExtensionAttribute::.ctor()
         = (01 00 00 00 )
        .maxstack 2

        ldarg.0
        ldarg.1
        xor
        ret
    }

    .method public hidebysig static !!0/*TEnum*/
        Not<valuetype .ctor (class [CORE_ASSEMBLY]System.Enum, class [CORE_ASSEMBLY]System.ValueType) TEnum>(
            !!0/*TEnum*/ this
        ) cil managed aggressiveinlining
    {
        .custom instance void [CORE_ASSEMBLY]System.Runtime.CompilerServices.ExtensionAttribute::.ctor()
         = (01 00 00 00 )
        .maxstack 2

        ldarg.0
        not
        ret
    }

    .method public hidebysig static !!0/*TEnum*/
        ClearFlags<valuetype .ctor (class [CORE_ASSEMBLY]System.Enum, class [CORE_ASSEMBLY]System.ValueType) TEnum>(
            !!0/*TEnum*/ this,
            !!0/*TEnum*/ 'value'
        ) cil managed aggressiveinlining
    {
        .custom instance void [CORE_ASSEMBLY]System.Runtime.CompilerServices.ExtensionAttribute::.ctor()
         = (01 00 00 00 )
        .maxstack 2

        ldarg.0
        ldarg.1
        not
        and
        ret
    }

    .method public hidebysig static bool
        HasFlags<valuetype .ctor (class [CORE_ASSEMBLY]System.Enum, class [CORE_ASSEMBLY]System.ValueType) TEnum>(
            !!0/*TEnum*/ this,
            !!0/*TEnum*/ 'value'
        ) cil managed aggressiveinlining
    {
        .custom instance void [CORE_ASSEMBLY]System.Runtime.CompilerServices.ExtensionAttribute::.ctor()
         = (01 00 00 00 )
        .maxstack 2

        ldarg.0
        ldarg.1
        and
        ldarg.1
        ceq
        ret
    }
}