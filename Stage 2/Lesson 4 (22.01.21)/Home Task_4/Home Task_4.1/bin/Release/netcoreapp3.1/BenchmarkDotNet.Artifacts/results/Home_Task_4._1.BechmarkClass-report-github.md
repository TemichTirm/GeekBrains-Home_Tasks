``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i5-8265U CPU 1.60GHz (Whiskey Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.102
  [Host]     : .NET Core 3.1.11 (CoreCLR 4.700.20.56602, CoreFX 4.700.20.56604), X64 RyuJIT
  DefaultJob : .NET Core 3.1.11 (CoreCLR 4.700.20.56602, CoreFX 4.700.20.56604), X64 RyuJIT


```
|                   Method |      Mean |     Error |    StdDev |
|------------------------- |----------:|----------:|----------:|
| &#39;Поиск строки в массиве&#39; | 55.286 μs | 0.9243 μs | 0.8193 μs |
| &#39;Поиск строки в HashSet&#39; |  2.189 μs | 0.0221 μs | 0.0196 μs |
