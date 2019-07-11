``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18932
Intel Core i7-8550U CPU 1.80GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.2.300
  [Host]     : .NET Core 2.2.5 (CoreCLR 4.6.27617.05, CoreFX 4.6.27618.01), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.5 (CoreCLR 4.6.27617.05, CoreFX 4.6.27618.01), 64bit RyuJIT


```
| Method |      initialSentence |     Mean |     Error |    StdDev |   Median |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------- |--------------------- |---------:|----------:|----------:|---------:|-------:|------:|------:|----------:|
| **Simple** | **word1(...)word4 [23]** | **40.67 ns** | **0.3987 ns** | **0.3330 ns** | **40.69 ns** | **0.0305** |     **-** |     **-** |     **128 B** |
|   Span | word1(...)word4 [23] | 13.03 ns | 0.2953 ns | 0.6165 ns | 13.08 ns |      - |     - |     - |         - |
| **Simple** | **word1(...)word4 [71]** | **58.12 ns** | **0.7418 ns** | **0.6576 ns** | **57.82 ns** | **0.0762** |     **-** |     **-** |     **320 B** |
|   Span | word1(...)word4 [71] | 17.75 ns | 0.8900 ns | 2.5248 ns | 16.86 ns |      - |     - |     - |         - |
