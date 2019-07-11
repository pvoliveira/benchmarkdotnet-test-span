``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18932
Intel Core i7-8550U CPU 1.80GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.2.300
  [Host]     : .NET Core 2.2.5 (CoreCLR 4.6.27617.05, CoreFX 4.6.27618.01), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.5 (CoreCLR 4.6.27617.05, CoreFX 4.6.27618.01), 64bit RyuJIT


```
|            Method |      initialSentence |      Mean |     Error |    StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------ |--------------------- |----------:|----------:|----------:|-------:|------:|------:|----------:|
| **SimpleSearchIndex** | **word1(...)word4 [23]** |  **34.30 ns** | **0.1958 ns** | **0.1831 ns** | **0.0305** |     **-** |     **-** |     **128 B** |
|             Split | word1(...)word4 [23] | 108.73 ns | 1.0080 ns | 0.9429 ns | 0.0514 |     - |     - |     216 B |
|   SpanSearchIndex | word1(...)word4 [23] |  10.52 ns | 0.0511 ns | 0.0478 ns |      - |     - |     - |         - |
| **SimpleSearchIndex** | **word1(...)word4 [71]** |  **43.44 ns** | **0.3352 ns** | **0.3136 ns** | **0.0762** |     **-** |     **-** |     **320 B** |
|             Split | word1(...)word4 [71] | 283.01 ns | 1.7010 ns | 1.5911 ns | 0.1426 |     - |     - |     600 B |
|   SpanSearchIndex | word1(...)word4 [71] |  12.47 ns | 0.1237 ns | 0.1157 ns |      - |     - |     - |         - |
