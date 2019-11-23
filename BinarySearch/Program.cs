using System;
using System.Collections.Generic;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Console.WriteLine(BinarySearch(a, 0, a.Length - 1, 33));
            Console.ReadLine();
        }

        static int BinarySearch(int[] a, int left, int right, int searchValue)
        {
            if (left > right) return -1;
            int mid = (left + right) / 2;
            if (a[mid] == searchValue)
            {
                return mid;
            }
            else if (a[mid] > searchValue)
            {
                return BinarySearch(a, left, mid, searchValue);
            }
            else
            {
                return BinarySearch(a, mid + 1, right, searchValue);
            }
        }
    }
}
