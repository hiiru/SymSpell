``` ini

BenchmarkDotNet=v0.11.3, OS=Windows 10.0.17134.523 (1803/April2018Update/Redstone4)
Intel Core i7-4770 CPU 3.40GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.2.200-preview-009748
  [Host]     : .NET Core 2.0.9 (CoreCLR 4.6.26614.01, CoreFX 4.6.26614.01), 64bit RyuJIT
  Job-CKFALY : .NET Core 2.0.9 (CoreCLR 4.6.26614.01, CoreFX 4.6.26614.01), 64bit RyuJIT

Jit=RyuJit  Platform=X64  Server=True  
Toolchain=.NET Core 2.0  

```
|                            Method |         Mean |      Error |       StdDev |       Median |  Ratio | RatioSD | Gen 0/1k Op | Gen 1/1k Op | Gen 2/1k Op | Allocated Memory/Op |
|---------------------------------- |-------------:|-----------:|-------------:|-------------:|-------:|--------:|------------:|------------:|------------:|--------------------:|
|                   SymSpell_Single |     72.35 ns |   4.009 ns |     4.456 ns |     70.71 ns |   1.00 |    0.00 |      0.0014 |           - |           - |               136 B |
|          SymSpellOptimized_Single |     77.77 ns |   4.705 ns |    13.873 ns |     73.76 ns |   1.07 |    0.23 |      0.0008 |           - |           - |                88 B |
|          SymSpell_Single_NonExact | 10,794.99 ns | 799.829 ns | 2,345.759 ns |  9,400.54 ns | 200.11 |   21.69 |      0.0610 |           - |           - |              5744 B |
| SymSpellOptimized_Single_NonExact |  9,517.26 ns | 454.628 ns |   425.260 ns |  9,318.63 ns | 131.11 |   11.10 |      0.0610 |           - |           - |              5688 B |
|                      SymSpell_All | 11,487.11 ns |  39.019 ns |    32.583 ns | 11,485.61 ns | 159.41 |    8.08 |      0.1068 |           - |           - |              9704 B |
|             SymSpellOptimized_All | 11,374.97 ns |  56.430 ns |    50.024 ns | 11,362.48 ns | 156.17 |    9.76 |      0.1068 |           - |           - |              9792 B |
