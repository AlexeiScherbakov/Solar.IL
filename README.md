# Solar.IL

Project for demonstration using Microsoft IL SDK ( aka Microsoft.NET.Sdk.IL)

CIL code files has 2 extensions for usability only!

*.il files are included by default

*.msil files are conditionaly included. 


Ilproj properties description:

* _FeaturePublicSign - set true for frameworks where public sign need to be enabled (.NETCore=true .NETFramework=false)
* _FeaturePopcount - set true for frameworks where Core Assemply contains System.Numerics.BitOperations::PopCount (.net6.0=true)

IL SDK properties can be found in - https://github.com/dotnet/runtime/blob/main/src/coreclr/.nuget/Microsoft.NET.Sdk.IL/targets/Microsoft.NET.Sdk.IL.targets