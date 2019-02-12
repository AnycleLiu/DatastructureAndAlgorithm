using LY.Algorithm.Sort;
using System;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace LY.Tests.Algorithm
{
    public class QuickSortTest
    {
        private readonly ITestOutputHelper _output;
        private readonly ISortProvider<int> _intSortor;
        private readonly ISortProvider<double> _doubleSortor;

        public QuickSortTest(ITestOutputHelper output)
        {
            _output = output;
            _intSortor = new QuickSortProvider<int>();
            _doubleSortor = new QuickSortProvider<double>();
        }

        [Fact]
        public void IntSortTest()
        {
            Assert.Throws<ArgumentNullException>(() => _intSortor.Sort(null));
            Assert.Throws<ArgumentNullException>(() => _intSortor.Reverse(null));

            int[] arr = new[] { 4, 55, 2, 7, 6, 8, 9, 0, 10, 12, 57, 10, 9, 8, 3, 0 };
            int[] arrDest = new int[arr.Length];
            Array.Copy(arr, arrDest, arr.Length);

            Array.Sort(arrDest);
            _intSortor.Sort(arr);

            _output.WriteLine(string.Join(",", arrDest));
            Assert.Equal(arr, arrDest);

            Array.Reverse(arrDest);
            _intSortor.Reverse(arr);

            _output.WriteLine(string.Join(",", arrDest));
            Assert.Equal(arr, arrDest);
        }

        [Fact]
        public void DoubleSortTest()
        {
            var rnd = new Random();
            double[] arr = Enumerable.Range(0, 1000).Select(x => rnd.NextDouble()).ToArray();
            double[] arrDest = new double[arr.Length];
            Array.Copy(arr, arrDest, arr.Length);

            Array.Sort(arrDest);
            _doubleSortor.Sort(arr);

            _output.WriteLine(string.Join(",", arrDest));
            Assert.Equal(arr, arrDest);

            Array.Reverse(arrDest);
            _doubleSortor.Reverse(arr);

            _output.WriteLine(string.Join(",", arrDest));
            Assert.Equal(arr, arrDest);
        }
    }
}
