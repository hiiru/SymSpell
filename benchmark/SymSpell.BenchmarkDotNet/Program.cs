using BenchmarkDotNet.Running;

namespace symSpell.BenchmarkDotNet
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            BenchmarkRunner.Run<SymSpellLookup>();
        }
    }
}