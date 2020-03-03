using System;

namespace ShellSort
{
    /// <summary>
    /// 插入排序的改进，希尔排序没有快速排序算法快，希尔算法在最坏的情况下和平均情况下执行效率相差不是很多，与此同时快速排序在最坏的情况下执行的效率会非常差
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[] { 8, 9, 1, 7, 2, 3, 5, 4, 6, 2, 2, 4, 5, 4, 2 };
            a = new int[] { 8, 9, 1, 7, 2, 3, 5, 4, 6, 0 };
            ShellSort(a);
            //Console.WriteLine(string.Join(',', a));
            Console.ReadLine();
        }

        /// <summary>
        /// 基于交换法法
        /// </summary>
        /// <param name="a"></param>
        static void ShellSort(int[] a)
        {
            if (a?.Length < 1) throw new Exception("invalid a");
            int temp = 0;
            for (int gap = a.Length / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < a.Length; i++)
                {
                    //遍历各组中所有的元素(共gap组,每组有个元素)，步长gap
                    for (int j = i - gap; j >= 0; j -= gap)
                    {
                        //如果当前元素大于加.上步长后的那个元素，说明交换
                        if (a[j] > a[j + gap])
                        {
                            temp = a[j];
                            a[j] = a[j + gap];
                            a[j + gap] = temp;
                            //Console.WriteLine(gap.ToString() + " -- " + string.Join(',', a) + " -- i = " + i.ToString() + " j = " + j.ToString());
                        }
                        Console.WriteLine(gap.ToString() + " -- i = " + i.ToString() + " j = " + j.ToString());
                    }
                }
            }
        }

        /// <summary>
        /// 基于移动法(插入法)
        /// </summary>
        /// <param name="a"></param>
        static void ShellSort1(int[] a)
        {
            if (a?.Length < 1) throw new Exception("invalid a");
            for (int gap = a.Length / 2; gap > 0; gap /= 2)
            {
                //从笫gap个元素,逐个对其所在的组进行直接插入排序
                for (int i = gap; i < a.Length; i++)
                {
                    int j = i;
                    int temp = a[j];
                    if (a[j] < a[j - gap])
                    {
                        while (j - gap >= 0 & temp < a[j - gap])
                        {
                            //移动
                            a[j] = a[j - gap];
                            j -= gap;
                        }
                        //当退出while后,就给temp找到插入的位置
                        a[j] = temp;
                    }
                }

            }
        }
    }
}
