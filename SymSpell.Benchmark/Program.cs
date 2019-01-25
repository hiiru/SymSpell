using BenchmarkDotNet.Running;
using System;

namespace symSpell.Benchmark
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            BenchmarkRunner.Run<symSpell.Benchmark.BenchmarkDotNet>();
        }
    }
}