using System;

namespace InsertSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[] { 9,1,8,2,7,3,6,4,5};
            InsertSort(a);
            Console.WriteLine(string.Join(',', a));
            Console.ReadLine();
        }

        static void InsertSort(int[] a)
        {
            int value = 0;
            int index = 0;
            for (int i = 1; i < a.Length; i++)
            {
                value = a[i];
                index = i - 1;
                while (index >= 0 && a[index] > value)
                {
                    a[index +1] = a[index];
                    index--;
                }
                a[index+1] = value;
            }
        }
    }
}