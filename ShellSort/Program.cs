using System;

namespace ShellSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[] { 999,8,9,1,7,2,3,5,4,6,0 };
            ShellSort1(a);
            Console.WriteLine(string.Join(',', a));
            Console.ReadLine();
        }

        //交换法
        static void ShellSort(int[] a)
        {
            if (a.Length <= 1) throw new Exception("invalid a");
            int gap = a.Length;
            int value = 0;
            int index = 0;
            int length = a.Length;
            while (true)
            {
                gap = Convert.ToInt32(Math.Ceiling((double)gap / 2));
               
                for (int i = 0; i < length; i++)
                {
                    index = i + gap;
                    while (index <length)
                    {
                        if (a[index] < a[i])
                        {
                            value = a[index];
                            a[index] = a[i];
                            a[i] = value;
                        }
                        index = index + gap;
                    }
                }

                if (gap == 1) break;                
            }
        }

        //插入法
        static void ShellSort1(int[] a)
        {
            if (a.Length <= 1) throw new Exception("invalid a");
            int gap = a.Length;
            int value = 0;
            int index = 0;
            int length = a.Length;
            while (true)
            {
                gap = Convert.ToInt32(Math.Ceiling((double)gap / 2));

                for (int i = length - 1; i >= gap; i--) //分组之后，不同组中相同的数的相对位置可能发生改变，因此为不稳定的排序 
                {
                    index = i;
                    value = a[i];
                    while (index - gap >= 0 && a[index] < a[index - gap])
                    {
                        a[index] = a[index - gap];
                        index = index - gap;
                    }
                    a[index] = value;
                }

                if (gap == 1) break;
            }
        }
    }
}
