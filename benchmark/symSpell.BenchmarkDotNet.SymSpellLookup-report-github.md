``` ini

BenchmarkDotNet=v0.11.3, OS=Windows 10.0.17134.523 (1803/April2018Update/Redstone4)
Intel Core i7-4770 CPU 3.40GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.2.200-preview-009748
  [Host]     : .NET Core 2.0.9 (CoreCLR 4.6.26614.01, CoreFX 4.6.26614.01), 64bit RyuJIT
  Job-IRAZHK : .NET Core 2.0.9 (CoreCLR 4.6.26614.01, CoreFX 4.6.26614.01), 64bit RyuJIT

Jit=RyuJit  Platform=X64  Server=True  
Toolchain=.NET Core 2.0  

```
|                      Method | Categories |             DictData |          Mean |       Error |      StdDev | Ratio | RatioSD | Gen 0/1k Op | Gen 1/1k Op | Gen 2/1k Op | Allocated Memory/Op |
|---------------------------- |----------- |--------------------- |--------------:|------------:|------------:|------:|--------:|------------:|------------:|------------:|--------------------:|
|             **SymSpell_Single** |     **Single** | **(C:\P(...)9159) [93]** |      **57.53 ns** |   **0.1703 ns** |   **0.1509 ns** |  **0.83** |    **0.00** |      **0.0014** |           **-** |           **-** |               **136 B** |
|          SymSpellV64_Single |     Single | (C:\P(...)9159) [93] |      69.72 ns |   0.3017 ns |   0.2355 ns |  1.00 |    0.00 |      0.0014 |           - |           - |               136 B |
|                             |            |                      |               |             |             |       |         |             |             |             |                     |
|    SymSpell_Single_NonExact |   NonExact | (C:\P(...)9159) [93] |   7,836.21 ns | 153.4979 ns | 176.7684 ns |  0.83 |    0.02 |      0.0458 |           - |           - |              5232 B |
| SymSpellV64_Single_NonExact |   NonExact | (C:\P(...)9159) [93] |   9,509.54 ns |  86.4272 ns |  80.8440 ns |  1.00 |    0.00 |      0.0610 |           - |           - |              5744 B |
|                             |            |                      |               |             |             |       |         |             |             |             |                     |
|                SymSpell_All |        All | (C:\P(...)9159) [93] |   9,525.48 ns | 188.3665 ns | 166.9820 ns |  0.84 |    0.02 |      0.0916 |           - |           - |              9336 B |
|             SymSpellV64_All |        All | (C:\P(...)9159) [93] |  11,297.74 ns |  43.8103 ns |  38.8367 ns |  1.00 |    0.00 |      0.0916 |           - |           - |              9704 B |
|                             |            |                      |               |             |             |       |         |             |             |             |                     |
|             **SymSpell_Single** |     **Single** | **(C:\P(...)0000) [95]** |      **57.92 ns** |   **0.2398 ns** |   **0.2002 ns** |  **0.83** |    **0.01** |      **0.0014** |           **-** |           **-** |               **136 B** |
|          SymSpellV64_Single |     Single | (C:\P(...)0000) [95] |      70.17 ns |   1.2458 ns |   1.0403 ns |  1.00 |    0.00 |      0.0015 |           - |           - |               136 B |
|                             |            |                      |               |             |             |       |         |             |             |             |                     |
|    SymSpell_Single_NonExact |   NonExact | (C:\P(...)0000) [95] |   3,868.06 ns |  20.0922 ns |  16.7779 ns |  0.79 |    0.02 |      0.0229 |           - |           - |              2304 B |
| SymSpellV64_Single_NonExact |   NonExact | (C:\P(...)0000) [95] |   4,942.25 ns |  95.7464 ns | 102.4475 ns |  1.00 |    0.00 |      0.0305 |           - |           - |              2464 B |
|                             |            |                      |               |             |             |       |         |             |             |             |                     |
|                SymSpell_All |        All | (C:\P(...)0000) [95] | 100,672.16 ns | 373.1306 ns | 330.7705 ns |  0.93 |    0.01 |      0.6104 |           - |           - |             58712 B |
|             SymSpellV64_All |        All | (C:\P(...)0000) [95] | 108,701.93 ns | 837.7839 ns | 783.6636 ns |  1.00 |    0.00 |      0.6104 |           - |           - |             60360 B |
|                             |            |                      |               |             |             |       |         |             |             |             |                     |

