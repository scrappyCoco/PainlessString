using BenchmarkDotNet.Attributes;
using Coding4fun.PainlessUtils;

namespace StringBenchmark
{
    [MemoryDiagnoser]
    public class ResultBenchmark
    {
        private const string SampleText = "SampleText";
        private const string Separator = "_";
        private readonly TextRange[] _textRanges = SampleText.SplitWordRanges();

        [Benchmark(Baseline = true)]
        public string SubStringAndStringBuilder() =>
            StringExperiment.SubStringAndStringBuilder(_textRanges, SampleText, CaseRules.ToUpperCase, Separator);
        
        [Benchmark]
        public string SpanAndStringBuilder() =>
            StringExperiment.SpanAndStringBuilder(_textRanges, SampleText, CaseRules.ToUpperCase, Separator);

        [Benchmark]
        public string SpanAndCharArray() =>
            StringExperiment.SpanAndCharArray(_textRanges, SampleText, CaseRules.ToUpperCase, Separator);
    }
}