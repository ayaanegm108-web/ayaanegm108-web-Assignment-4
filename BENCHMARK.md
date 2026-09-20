# Benchmark Results — String vs StringBuilder

## Results Table
| Method                     | Iterations | Mean              | Error           | StdDev          | Median            | Gen0          | Gen1          | Gen2          | Allocated       |
|--------------------------- |----------- |------------------:|----------------:|----------------:|------------------:|--------------:|--------------:|--------------:|----------------:|
| StringConcatenation        | 100        |          8.585 us |       0.5799 us |       1.6452 us |          8.194 us |       21.0114 |        0.1221 |             - |       128.79 KB |
| StringBuilderConcatenation | 100        |          1.422 us |       0.0273 us |       0.0696 us |          1.416 us |        1.9245 |        0.0324 |             - |         11.8 KB |
| StringConcatenation        | 1000       |        648.953 us |      12.8984 us |      28.5820 us |        645.274 us |     2204.1016 |      147.4609 |             - |     13527.62 KB |
| StringBuilderConcatenation | 1000       |         16.923 us |       0.3349 us |       0.7209 us |         17.016 us |       22.0337 |        2.4414 |             - |       135.34 KB |
| StringConcatenation        | 10000      |    139,477.772 us |   2,781.8560 us |   5,745.0154 us |    139,319.475 us |   437000.0000 |   421000.0000 |   418000.0000 |    1444981.1 KB |
| StringBuilderConcatenation | 10000      |        411.076 us |      10.1622 us |      28.9932 us |        402.386 us |      204.5898 |      136.2305 |       90.8203 |       1439.3 KB |
| StringConcatenation        | 100000     | 36,783,086.908 us | 667,108.1103 us | 557,065.4857 us | 36,805,126.500 us | 24347000.0000 | 24273000.0000 | 24270000.0000 | 154204871.53 KB |
| StringBuilderConcatenation | 100000     |      4,728.318 us |      94.5345 us |     105.0748 us |      4,724.915 us |     1906.2500 |     1390.6250 |      992.1875 |     14811.62 KB |


**Which approach was faster with 100 iterations?**
StringBuilder was faster (1.422 us vs 8.585 us),
though the difference is small in absolute terms.

**Which approach was faster with 100,000 iterations?**
StringBuilder was dramatically faster — about 4.7 ms 
compared to ~36.8 seconds for string concatenation, 
a difference of roughly 7,780x.

**Which approach allocated more memory?**
String concatenation allocated far more memory at
every scale, and the gap grows enormously with size 
— at 100,000 iterations it allocated ~154 GB total 
(transient allocations) versus ~14.8 MB for StringBuilder.

**What happened to string concatenation performance as the loop size increased?**
Performance degraded much faster than linearly — closer to quadratic. Going from
10,000 to 100,000 iterations (10x more work) increased the time by roughly 260x,
not 10x.

**Why does repeated string concatenation create additional allocations?**
Strings in C# are immutable. Each += creates an entirely new string containing
the old content plus the new content, leaving the previous string as garbage to
be collected. Every concatenation copies all the previously accumulated text again.

**Why does StringBuilder usually perform better when text is repeatedly appended?**
StringBuilder maintains an internal resizable buffer. Appending writes into existing 
free space in that buffer instead of copying everything each time, so most Append 
calls don't require a new allocation — the buffer only needs to grow occasionally.

**Is StringBuilder always better than normal string operations? Explain.**
No. For a small, fixed number of concatenations (as seen with 100 iterations
, where the difference was small), the overhead of creating a StringBuilder
object may not be worth it, and plain string concatenation is simpler and
clearer to read. StringBuilder's advantage only becomes significant when
many concatenations happen in a loop or dynamically.