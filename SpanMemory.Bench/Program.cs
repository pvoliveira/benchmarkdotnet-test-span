namespace SpanMemory.Bench
{
    using System;
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Running;

    [BenchmarkCategory("Span")]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [MemoryDiagnoser]
    public class TestBench
    {
        [Params(
            "word1 word2 word3 word4",
            "word1 word2 word3 word4 word1 word2 word3 word4 word1 word2 word3 word4"
        )]
        public string initialSentence;

        [Benchmark]
        public void SimpleSearchIndex()
        {
            if (string.IsNullOrWhiteSpace(initialSentence)) return;

            int index = initialSentence.IndexOf(' ');
            
            // print
            var word = initialSentence.Substring(0, initialSentence.Length - (index + 1));
            var sentence = initialSentence.Substring(index);

            while (sentence.IndexOf(' ') > 0)
            { 
                index = sentence.IndexOf(' ');
            
                // print
                word = sentence.Substring(0, sentence.Length - (index + 1));
                sentence = sentence.Substring(index);
            }
        }

        [Benchmark]
        public void Split()
        {
            if (string.IsNullOrWhiteSpace(initialSentence)) return;

            var words = initialSentence.Split(' ', StringSplitOptions.None);

            foreach (var word in words)
            {
                // print word
            }
        }

        [Benchmark]
        public void SpanSearchIndex()
        {
            ReadOnlySpan<char> refSentence = initialSentence.AsSpan();

            if (refSentence.IsWhiteSpace()) return;

            int index = refSentence.IndexOf(' ');
            
            // print word
            var word = refSentence.Slice(0, refSentence.Length - (index + 1));
            var sentence = refSentence.Slice(index);

            while (sentence.IndexOf(' ') > 0)
            { 
                index = sentence.IndexOf(' ');
            
                // print word
                word = sentence.Slice(0, sentence.Length - (index + 1));
                sentence = sentence.Slice(index);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            _ = BenchmarkRunner.Run<TestBench>();
        }
    }
}
