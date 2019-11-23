using System;

namespace RadixSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[] { 11, 2, 31, 42, 25, 36, 47, 58, 69, 710 };
            int[] a1 = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            int[] a2 = new int[] { 1, 3, 5, 7, 9, 2, 4, 6, 8, 10 };
            int[] a3 = new int[] { 10, 8, 6, 4, 2, 9, 7, 5, 3, 12,34,1111 };
            int[] a4 = new int[] { 1, 2, 3, 4, 5, 10, 9, 8, 7, 6 };
            int[] a5 = new int[] { 5, 6, 7, 8, 1, 2, 9, 3 };
            RadixSort(a);
            RadixSort(a1);
            RadixSort(a2);
            RadixSort(a3);
            RadixSort(a4);
            RadixSort(a5);
            Console.WriteLine(string.Join(',', a));
            Console.WriteLine(string.Join(',', a1));
            Console.WriteLine(string.Join(',', a2));
            Console.WriteLine(string.Join(',', a3));
            Console.WriteLine(string.Join(',', a4));
            Console.WriteLine(string.Join(',', a5));
            Console.ReadLine();
        }

        static void RadixSort(int[] a)
        {
            int[,] b = new int[10,a.Length];

            int maxlength = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (maxlength < a[i].ToString().Length)
                {
                    maxlength = a[i].ToString().Length;
                }
            }
            int[] ElementCount = new int[10];
            for (int i = 1; i <= maxlength; i++)
            {
                for (int j = 0; j < a.Length; j++)
                {
                    int mod =  Convert.ToInt32(a[j] / Math.Pow(10, i-1)) % 10;
                    b[mod,ElementCount[mod]] = a[j];
                    ElementCount[mod]++;
                }
                int index = 0;
                for (int m = 0; m < ElementCount.Length; m++)
                {
                    if (ElementCount[m] == 0) continue;
                    for (int n = 0; n < ElementCount[m]; n++)
                    {
                        a[index++] = b[m,n] ;
                    }
                }
                b = new int[10, a.Length];
                ElementCount = new int[10];
            }
        }
    }
}