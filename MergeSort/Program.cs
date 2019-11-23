using System;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //int[] a1 = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            //int[] a2 = new int[] { 1, 3, 5, 7, 9, 2, 4, 6, 8, 10 };
            //int[] a3 = new int[] { 10, 8, 6, 4, 2, 9, 7, 5, 3, 1 };
            //int[] a4 = new int[] { 1, 2, 3, 4, 5, 10, 9, 8, 7, 6 };
            //int[] a5 = new int[] { 5, 6, 7, 8, 1, 2, 9, 3, 4, 10 };
            //int[] a6 = new int[] { 5, -6, 7, -8, -1, 2, 9, 3, -4, -10 };
            int[] t = new int[a.Length];
            //MergeSort(a, 0, a.Length - 1);
            //MergeSort(a1, 0, a1.Length - 1);
            //MergeSort(a2, 0, a2.Length - 1);
            //MergeSort(a3, 0, a3.Length - 1);
            //MergeSort(a4, 0, a4.Length - 1);
            //MergeSort(a5, 0, a5.Length - 1);
            //MergeSort(a6, 0, a6.Length - 1);

            Merge(a, 0, a.Length - 1,t);
            //Merge(a1, 0, a1.Length - 1, t);
            //Merge(a2, 0, a2.Length - 1, t);
            //Merge(a3, 0, a3.Length - 1, t);
            //Merge(a4, 0, a4.Length - 1, t);
            //Merge(a5, 0, a5.Length - 1, t);
            //Merge(a6, 0, a6.Length - 1, t);

            Console.WriteLine(string.Join(',', a));
            //Console.WriteLine(string.Join(',', a1));
            //Console.WriteLine(string.Join(',', a2));
            //Console.WriteLine(string.Join(',', a3));
            //Console.WriteLine(string.Join(',', a4));
            //Console.WriteLine(string.Join(',', a5));
            //Console.WriteLine(string.Join(',', a6));
            Console.ReadLine();
        }

        //no right
        static void MergeSort(int[] a, int left, int right)
        {
            if (left >= right) return;

            int m = (right - left) / 2;    
            MergeSort(a, left, left + m);
            MergeSort(a, left + m + 1, right);
            int value = 0;
            int index = 0;
            for (int i = left + m + 1; i <= right; i++)
            {
                value = a[i];
                index = i - 1;
                while (index >= left && a[index] > value)
                {
                    a[index + 1] = a[index];
                    index--;
                }
                a[index + 1] = value;
            }
        }

        static void MergeSort1(int[] a, int left, int mid, int right, int[] t)
        {
            //优化：如果left和right相差较小可以用插入排序
            Console.WriteLine("{0}-{1}-{2}", left, mid, right);
        }

        static void Merge(int[] a, int left, int right,int[] t)
        {            
            if (left < right)
            {
                Console.WriteLine("{0}-{1}", left, right);
                int mid = (left + right) / 2;
                Merge(a, left, mid,t);
                Merge(a, mid + 1, right,t);
                MergeSort1(a, left, mid, right, t);
            }
        }
    }
}
