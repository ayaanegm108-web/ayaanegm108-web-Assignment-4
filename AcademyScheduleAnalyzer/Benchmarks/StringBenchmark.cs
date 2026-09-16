using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Attributes;

namespace Ass04.Benchmarks
{
    [MemoryDiagnoser]
    public class StringBenchmark
    {
        [Params(100, 1000, 10000, 100000)]
        public int Iterations;

        [Benchmark]
        public string StringConcatenation()
        {
            string result = "";
            for (int i = 0; i < Iterations; i++)
            {
                result += "Session " + i + " - ";
            }
            return result;
        }

        [Benchmark]
        public string StringBuilderConcatenation()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Iterations; i++)
            {
                sb.Append("Session " + i + " - ");
            }
            return sb.ToString();
        }
    }
}
