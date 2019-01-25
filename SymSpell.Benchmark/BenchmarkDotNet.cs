using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Toolchains.CsProj;
using System;

namespace symSpell.Benchmark
{
    [Config(typeof(symSpell.Benchmark.BenchmarkDotNet.Config))]
    public class BenchmarkDotNet
    {
        public class Config : ManualConfig
        {
            public Config()
            {
                Add(MemoryDiagnoser.Default);
                //Add(new InliningDiagnoser());
                //Add(new EtwProfiler());

                Add(Job.Default.With(CsProjCoreToolchain.NetCoreApp20).WithGcServer(true).With(Platform.X64).With(Jit.RyuJit));
                //Add(Job.Default.With(CsProjClassicNetToolchain.Net461).WithGcServer(true).With(Platform.X64).With(Jit.RyuJit));
                //Add(Job.Default.With(CsProjClassicNetToolchain.Net47).WithGcServer(true).With(Platform.X64).With(Jit.RyuJit));
            }
        }

        private static readonly string Path = AppDomain.CurrentDomain.BaseDirectory;

        public static (string path, int size)[] DictionaryData => new (string path, int size)[]
        {
            //(@"C:\Projects\SymSpell\SymSpell.Benchmark\test_data\frequency_dictionary_en_30_000.txt", 29159),
            //(Path+"../../../../SymSpell/frequency_dictionary_en_82_765.txt", 82765),
            (@"C:\Projects\SymSpell\SymSpell.Benchmark\test_data\frequency_dictionary_en_500_000.txt", 500000)
        };

        //[ParamsSource(nameof(DictionaryData))]
        public (string Path, int Size) Dict;

        //[Params(1, 2, 3)]
        public int MaxDistance = 2;

        //[Params(5,6,7)]
        public int PrefixLength = 7;

        //[ParamsAllValues]
        public SymSpell.Verbosity SymVerbosity = SymSpell.Verbosity.Closest;

        //[GlobalSetup]
        //public void GlobalSetup()
        //{
        //    _symSpell = new SymSpell(Dict.Size, MaxDistance, PrefixLength);
        //    _symSpell.LoadDictionary(Dict.Path, 0, 1);

        //    //_origSymSpell = new Original.SymSpell(MaxDistance, PrefixLength);
        //    //_origSymSpell.LoadDictionary(Dict.Path, "", 0, 1);

        //    _symSpellOptimized = new Optimized.SymSpell(Dict.Size, MaxDistance, PrefixLength);
        //    _symSpellOptimized.LoadDictionary(Dict.Path, 0, 1);
        //}

        private SymSpell _symSpell;

        private Original.SymSpell _origSymSpell;

        private Optimized.SymSpell _symSpellOptimized;

        //[Benchmark(Baseline = true)]
        //public int SymSpellExact()
        //{
        //    return _symSpell.Lookup("different", SymVerbosity, MaxDistance).Count;
        //}

        //[Benchmark]
        //public int SymSpellOptimizedExact()
        //{
        //    return _symSpellOptimized.Lookup("different", SymVerbosity, MaxDistance).Count;
        //}

        //[Benchmark]
        //public void OriginalExact()
        //{
        //    _origSymSpell.Lookup("different", "", MaxDistance, (int)SymVerbosity);
        //}

        //[Benchmark]
        //public void SymSpellNonExact()
        //{
        //    _symSpell.Lookup("hockie", SymVerbosity, MaxDistance);
        //}

        //[Benchmark]
        //public void OriginalNonExact()
        //{
        //    _origSymSpell.Lookup("hockie", "", MaxDistance, (int)SymVerbosity);
        //}

        private SymSpell _emptySymSpell;
        private Optimized.SymSpell _emptySymSpellOptimized;

        [GlobalSetup]
        public void GlobalSetup()
        {
            //_emptySymSpell = new SymSpell(DictionaryData[0].size, 2, 7);
            //_emptySymSpell.LoadDictionary("", 0, 1);
            //_emptySymSpellOptimized = new Optimized.SymSpell(DictionaryData[0].size, 2, 7);
            //_emptySymSpellOptimized.LoadDictionary("", 0, 1);

            _symSpell = new SymSpell(DictionaryData[0].size, 2, 7);
            _symSpell.LoadDictionary(DictionaryData[0].path, 0, 1);

            //_origSymSpell = new Original.SymSpell(MaxDistance, PrefixLength);
            //_origSymSpell.LoadDictionary(Dict.Path, "", 0, 1);

            _symSpellOptimized = new Optimized.SymSpell(DictionaryData[0].size, 2, 7);
            _symSpellOptimized.LoadDictionary(DictionaryData[0].path, 0, 1);
        }

        //[Benchmark]
        //public int SymSpell_Empty()
        //{
        //    var count = _emptySymSpellOptimized.Lookup("different", SymSpell.Verbosity.Closest, 2)?.Count ?? 0;
        //    if (count != 0)
        //        throw new InvalidOperationException();
        //    return count;
        //}

        //[Benchmark]
        //public int SymSpellOptimized_Empty()
        //{
        //    var count = _emptySymSpellOptimized.Lookup("different", SymSpell.Verbosity.Closest, 2)?.Count ?? 0;
        //    if (count != 0)
        //        throw new InvalidOperationException();
        //    return count;
        //}

        [Benchmark(Baseline = true)]
        public int SymSpell_Single()
        {
            return _symSpell.Lookup("different", SymSpell.Verbosity.Closest, 2).Count;
        }

        [Benchmark]
        public int SymSpellOptimized_Single()
        {
            return _symSpellOptimized.Lookup("different", SymSpell.Verbosity.Closest, 2).Count;
        }

        [Benchmark]
        public int SymSpell_Single_NonExact()
        {
            return _symSpell.Lookup("hockie", SymSpell.Verbosity.Closest, 2).Count;
        }

        [Benchmark]
        public int SymSpellOptimized_Single_NonExact()
        {
            return _symSpellOptimized.Lookup("hockie", SymSpell.Verbosity.Closest, 2).Count;
        }

        [Benchmark]
        public int SymSpell_All()
        {
            return _symSpell.Lookup("different", SymSpell.Verbosity.All, 2).Count;
        }

        [Benchmark]
        public int SymSpellOptimized_All()
        {
            return _symSpellOptimized.Lookup("different", SymSpell.Verbosity.All, 2).Count;
        }
    }
}