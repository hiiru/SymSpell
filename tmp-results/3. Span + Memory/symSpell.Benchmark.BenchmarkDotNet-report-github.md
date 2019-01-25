``` ini

BenchmarkDotNet=v0.11.3, OS=Windows 10.0.17134.523 (1803/April2018Update/Redstone4)
Intel Core i7-4770 CPU 3.40GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.2.200-preview-009748
  [Host]     : .NET Core 2.0.9 (CoreCLR 4.6.26614.01, CoreFX 4.6.26614.01), 64bit RyuJIT
  Job-SDLVBK : .NET Core 2.0.9 (CoreCLR 4.6.26614.01, CoreFX 4.6.26614.01), 64bit RyuJIT

Jit=RyuJit  Platform=X64  Server=True  
Toolchain=.NET Core 2.0  

```
|                            Method |         Mean |      Error |     StdDev |  Ratio | RatioSD | Gen 0/1k Op | Gen 1/1k Op | Gen 2/1k Op | Allocated Memory/Op |
|---------------------------------- |-------------:|-----------:|-----------:|-------:|--------:|------------:|------------:|------------:|--------------------:|
|                   SymSpell_Single |     70.17 ns |  0.1490 ns |  0.1321 ns |   1.00 |    0.00 |      0.0017 |           - |           - |               136 B |
|          SymSpellOptimized_Single |     78.25 ns |  0.6087 ns |  0.5083 ns |   1.12 |    0.01 |      0.0011 |           - |           - |                88 B |
|          SymSpell_Single_NonExact |  9,226.22 ns | 51.8082 ns | 48.4614 ns | 131.48 |    0.74 |      0.0610 |           - |           - |              5744 B |
| SymSpellOptimized_Single_NonExact |    648.14 ns |  1.9465 ns |  1.5197 ns |   9.24 |    0.03 |      0.0095 |           - |           - |               936 B |
|                      SymSpell_All | 11,479.19 ns | 42.4265 ns | 37.6100 ns | 163.60 |    0.46 |      0.1068 |           - |           - |              9704 B |
|             SymSpellOptimized_All |  1,509.21 ns |  9.0761 ns |  8.0457 ns |  21.51 |    0.10 |      0.0153 |           - |           - |              1368 B |
