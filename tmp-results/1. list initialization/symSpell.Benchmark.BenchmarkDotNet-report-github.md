``` ini

BenchmarkDotNet=v0.11.3, OS=Windows 10.0.17134.523 (1803/April2018Update/Redstone4)
Intel Core i7-4770 CPU 3.40GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.2.200-preview-009748
  [Host]     : .NET Core 2.0.9 (CoreCLR 4.6.26614.01, CoreFX 4.6.26614.01), 64bit RyuJIT
  Job-SOMZRJ : .NET Core 2.0.9 (CoreCLR 4.6.26614.01, CoreFX 4.6.26614.01), 64bit RyuJIT

Jit=RyuJit  Platform=X64  Server=True  
Toolchain=.NET Core 2.0  

```
|                   Method |      Mean |     Error |    StdDev | Ratio | Gen 0/1k Op | Gen 1/1k Op | Gen 2/1k Op | Allocated Memory/Op |
|------------------------- |----------:|----------:|----------:|------:|------------:|------------:|------------:|--------------------:|
|          SymSpell_Single | 70.702 ns | 0.3084 ns | 0.2575 ns |  1.00 |      0.0015 |           - |           - |               136 B |
| SymSpellOptimized_Single | 58.493 ns | 0.6441 ns | 0.5029 ns |  0.83 |      0.0012 |           - |           - |               112 B |
|           SymSpell_Empty |  4.875 ns | 0.0495 ns | 0.0463 ns |  0.07 |           - |           - |           - |                   - |
|  SymSpellOptimized_Empty |  4.829 ns | 0.0178 ns | 0.0158 ns |  0.07 |           - |           - |           - |                   - |
