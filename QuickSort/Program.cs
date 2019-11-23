using System;

namespace QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[] { 999, 8, 9, 1, 7, 2, 3, 5, 4, 6,0};
            QuickSort(a,0,a.Length -1);
            Console.WriteLine(string.Join(',', a));
            Console.ReadLine();
        }

        static void QuickSort(int[] a,int left,int right)
        {
            if (left >= right) return;

            int pivot = a[right];
            int l = left, r = right;
            while (l < r)
            {
                while (a[l] < pivot && l < r)
                {
                    l++;
                }
                a[r] = a[l];

                while (a[r] > pivot && l < r)
                {
                    r--;
                }
                a[l] = a[r];
            }
            a[r] = pivot;

            QuickSort(a, 0, r-1);

            QuickSort(a, r + 1, right);
        }
    }
}
