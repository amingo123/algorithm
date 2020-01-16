using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parallel_Sort {

    class Parallel_Sort<T> {

        public static void ParallelQuickSort(T[] data, IComparer<T> comparer, int maxDepth = 16, int minBlockSize = 10000)
        {
            // call the internal method
            DoSort(data, 0, data.Length - 1, comparer, 0, maxDepth, minBlockSize);
        }

        internal static void DoSort(T[] data, int startIndex, int endIndex, IComparer<T> comparer, int depth, int maxDepth, int minBlockSize)
        {
            if (startIndex < endIndex)
            {
                // if we have exceeded the depth threshold or there are
                // fewer items than we would like, then use sequential sort
                if (depth > maxDepth || endIndex - startIndex < minBlockSize)
                {
                    Array.Sort(data, startIndex, endIndex - startIndex + 1, comparer);
                }
                else
                {
                    // we need to parallelize
                    int pivotIndex = PartitionBlock1(data, startIndex, endIndex, comparer);
                    // recurse on the left and right blocks
                    Task leftTask = Task.Factory.StartNew(() =>
                    {
                        DoSort(data, startIndex, pivotIndex - 1, comparer, depth + 1, maxDepth, minBlockSize);
                    });
                    Task rightTask = Task.Factory.StartNew(() =>
                    {
                        DoSort(data, pivotIndex + 1, endIndex, comparer, depth + 1, maxDepth, minBlockSize);
                    });
                    // wait for the tasks to complete
                    Task.WaitAll(leftTask, rightTask);
                }
            }
        }

        internal static int PartitionBlock(T[] data, int startIndex, int endIndex,IComparer<T> comparer)
        {
            // get the pivot value - we will be comparing all 
            // of the other items against this value
            T pivot = data[startIndex];
            // put the pivot value at the end of block
            SwapValues(data, startIndex, endIndex);
            // index used to store values smaller than the pivot
            int storeIndex = startIndex;
            // iterate through the items in the block
            for (int i = startIndex; i < endIndex; i++)
            {
                // look for items that are smaller or equal to the pivot
                if (comparer.Compare(data[i], pivot) <= 0)
                {
                    // move the value and increment the index
                    SwapValues(data, i, storeIndex);
                    storeIndex++;
                }
            }
            SwapValues(data, storeIndex, endIndex);
            return storeIndex;
        }

        internal static int PartitionBlock1(T[] a, int left, int right, IComparer<T> comparer)
        {
            T pivot = a[right];
            int l = left, r = right;
            while (l < r)
            {
                while (comparer.Compare(a[l], pivot) <= 0 && l < r)
                {
                    l++;
                }
                a[r] = a[l];

                while (comparer.Compare(a[r], pivot) > 0 && l < r)
                {
                    r--;
                }
                a[l] = a[r];
            }
            a[r] = pivot;
            return r;
        }

        internal static void SwapValues(T[] data, int firstIndex, int secondIndex)
        {
            T holder = data[firstIndex];
            data[firstIndex] = data[secondIndex];
            data[secondIndex] = holder;
        }
    }
}
