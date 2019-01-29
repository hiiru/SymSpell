using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Toolchains.CsProj;
using System;
using System.IO;

namespace symSpell.BenchmarkDotNet
{
    [Config(typeof(Config))]
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    //[DisassemblyDiagnoser(printAsm:false, printIL:true, printSource:true, recursiveDepth:10, printPrologAndEpilog:true)]
    public class SymSpellLookup
    {
        private class Config : ManualConfig
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

        private static string GetBaseDirectory()
        {
            var di = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            while (di.Parent != null)
            {
                var solutionFile = di.GetFiles("SymSpell.sln");
                if (solutionFile != null && solutionFile.Length == 1)
                    return di.FullName;
                di = di.Parent;
            }
            throw new Exception("Can't find SymSpell solution directory!");
        }

        private static readonly string SolutionDirectory = GetBaseDirectory();

        public static (string Path, int Size)[] DictionaryData => new (string Path, int Size)[]
        {
            (Path.Combine(SolutionDirectory, "SymSpell.Benchmark/test_data/frequency_dictionary_en_30_000.txt"), 29159),
            //(Path.Combine(SolutionDirectory, "SymSpell.Benchmark/test_data/frequency_dictionary_en_82_765.txt"), 82765),
            (Path.Combine(SolutionDirectory, "SymSpell.Benchmark/test_data/frequency_dictionary_en_500_000.txt"), 500000),
        };

        private SymSpell _currentSymSpell;
        private V6dot4.SymSpell _v64SymSpell;

        [ParamsSource(nameof(DictionaryData))]
        public (string Path, int Size) DictData;

        [GlobalSetup]
        public void GlobalSetup()
        {
            if (!File.Exists(DictData.Path))
                throw new Exception("Error: dictionary file does not exist!");
            _currentSymSpell = new SymSpell(DictData.Size, 2, 7);
            _currentSymSpell.LoadDictionary(DictData.Path, 0, 1);

            _v64SymSpell = new V6dot4.SymSpell(DictData.Size, 2, 7);
            _v64SymSpell.LoadDictionary(DictData.Path, 0, 1);
        }

        [BenchmarkCategory("Single"), Benchmark]
        public int SymSpell_Single()
        {
            return _currentSymSpell.Lookup("different", SymSpell.Verbosity.Closest, 2, false).Count;
        }

        [BenchmarkCategory("Single"), Benchmark(Baseline = true)]
        public int SymSpellV64_Single()
        {
            return _v64SymSpell.Lookup("different", V6dot4.SymSpell.Verbosity.Closest, 2, false).Count;
        }

        [BenchmarkCategory("NonExact"), Benchmark]
        public int SymSpell_Single_NonExact()
        {
            return _currentSymSpell.Lookup("hockie", SymSpell.Verbosity.Closest, 2, false).Count;
        }

        [BenchmarkCategory("NonExact"), Benchmark(Baseline = true)]
        public int SymSpellV64_Single_NonExact()
        {
            return _v64SymSpell.Lookup("hockie", V6dot4.SymSpell.Verbosity.Closest, 2, false).Count;
        }

        [BenchmarkCategory("All"), Benchmark]
        public int SymSpell_All()
        {
            return _currentSymSpell.Lookup("different", SymSpell.Verbosity.All, 2, false).Count;
        }

        [BenchmarkCategory("All"), Benchmark(Baseline = true)]
        public int SymSpellV64_All()
        {
            return _v64SymSpell.Lookup("different", V6dot4.SymSpell.Verbosity.All, 2, false).Count;
        }
    }
}