using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenchmarkExample
{
    [MemoryDiagnoser]
    public class Benchmark
    {
        // Benchmark .net example and K6 HTTP loadtesting
        // Benchmarkes methods, just use the [Benchmark] annotation on a method.
        // Always run as Release mode
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Benchmark>();

        }

        public class MyClass
        {
            static readonly System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();

            public static System.Net.Http.HttpClient InstantiateHttpClient()
            {
                return client;
            }

        }
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        [Benchmark]
        public async Task OldList()
        {
            List<string> @default = new List<string>();

            for (int i = 0; i < 300; i++)
            {
                @default.Add(RandomString(30));
            }

            var newList = new List<string>();
            foreach (var element in @default)
            {
                newList.Add(element);
            }

        }

        [Benchmark]
        public async Task<List<string>> NewList()
        {
            List<string> @default = new List<string>();

            for (int i = 0; i < 300; i++)
            {
                @default.Add(RandomString(30));
            }

            return @default;

        }
    }
}
