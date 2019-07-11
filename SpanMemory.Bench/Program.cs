namespace SpanMemory.Bench
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Running;

    [MemoryDiagnoser]
    public class TestBench
    {
        [Params(
            "word1 word2 word3 word4",
            "word1 word2 word3 word4 word1 word2 word3 word4 word1 word2 word3 word4"
        )]
        public string initialSentence;

        public TestBench() {}



        [Benchmark]
        public void Simple()
        {
            if (string.IsNullOrWhiteSpace(initialSentence)) return;

            int index = initialSentence.IndexOf(' ');
            
            // print
            var word = initialSentence.Substring(0, initialSentence.Length - index);
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
        public void Span()
        {
            ReadOnlySpan<char> spanRef = initialSentence.AsSpan();

            if (spanRef.IsWhiteSpace()) return;

            int index = spanRef.IndexOf(' ');
            
            // print
            var word = spanRef.Slice(0, spanRef.Length - (index + 1));
            var sentence = spanRef.Slice(index);

            while (sentence.IndexOf(' ') > 0)
            { 
                index = sentence.IndexOf(' ');
            
                // print
                word = sentence.Slice(0, sentence.Length - (index + 1));
                sentence = sentence.Slice(index);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<TestBench>();
        }
    }
}
