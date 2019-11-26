using System;

namespace QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[] { 8, 9, 1, 7, 2, 3, 5, 4, 6, 2, 2, 4, 5, 4, 2 };
            QuickSort(a,0,a.Length -1);
            Console.WriteLine(string.Join(',', a));
            Console.ReadLine();
        }

        //1.两个方向，左边的i下标一直往右走，当a[i] <= a[center_index]，其中center_index是中枢元素的数组下标，一般取为数组第0个元素。而右边的j下标一直往左走，当a[j] > a[center_index]
        //2.如果i和j都走不动了，i <= j, 交换a[i] 和a[j], 重复上面的过程，直到i>j
        //3.交换a[j] 和a[center_index]，完成一趟快速排序
        //4.在中枢元素和a[j] 交换的时候，很有可能把前面的元素的稳定性打乱，比如序列为 5 3 3 4 3 8 9 10 11， 现在中枢元素5和3(第5个元素，下标从1开始计)交换就会把元素3的稳定性打乱
        //5.不稳定发生在中枢元素和a[j] 交换的时刻
        //6.不稳定的排序算法。
        static void QuickSort(int[] a,int left,int right)
        {
            if (left >= right) return;

            int pivot = a[right];
            int l = left, r = right;
            while (l < r)
            {
                while (a[l] <= pivot && l < r)
                {
                    l++;
                }
                a[r] = a[l];

                while (a[r] >= pivot && l < r)
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
