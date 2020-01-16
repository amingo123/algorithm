using System;
using System.Collections.Generic;
using System.Diagnostics;
using Parallel_Sort;
namespace SortParallel
{
    class Program
    {
        static void Main(string[] args)
        {
            // generate some random source data
            Random rnd = new Random();
            int[] sourceData = new int[5000000];
            for (int i = 0; i < sourceData.Length; i++)
            {
                sourceData[i] = rnd.Next(1, 100);
            }
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            // perform the parallel sort
            Parallel_Sort<int>.ParallelQuickSort(sourceData, new IntComparer());
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
        }

        public class IntComparer : IComparer<int>
        {
            public int Compare(int first, int second)
            {
                return first.CompareTo(second);
            }
        }
    }
}
