#include "version.h"

.assembly Solar.IL
{
  .ver ASSEMBLY_VERSION
}

.module Solar.IL.dll
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
