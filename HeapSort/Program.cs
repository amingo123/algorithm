using System;

namespace HeapSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 4, 6, 8, 5, 9 };
            HeapSort(a);
            Console.WriteLine(string.Join(',', a));
            Console.ReadLine();
        }

        static void HeapSort(int[] a)
        {
            //1.构建大顶堆
            for (int i = a.Length / 2 - 1; i >= 0; i--)
            {
                //从第一个非叶子结点从下至上，从右至左调整结构
                AdjustHeap(a, i, a.Length);
            }
            //2.调整堆结构+交换堆顶元素与末尾元素
            for (int j = a.Length - 1; j > 0; j--)
            {
                Swap(a, 0, j);//将堆顶元素与末尾元素进行交换
                AdjustHeap(a, 0, j);//重新对堆进行调整
            }
        }

        static void AdjustHeap(int[] a, int i, int length)
        {
            if (i >= a.Length || i < 0) return;
            if (length > a.Length || length < 1) return;
            int temp = a[i];//先取出当前元素

            for (int k = i * 2 + 1; k < length; k = k * 2 + 1)
            {//从i结点的左子结点开始，也就是2i+1处开始
                if (k + 1 < length && a[k] < a[k + 1])
                {//如果左子结点小于右子结点，k指向右子结点
                    k++;
                }
                if (a[k] > temp)
                {//如果子节点大于父节点，将子节点值赋给父节点（不用进行交换）
                    a[i] = a[k];
                    i = k;
                }
                else
                {
                    break;
                }
            }
            a[i] = temp;//将temp值放到最终的位置
        }

        public static void Swap(int[] a, int m, int n)
        {
            int temp = a[m];
            a[m] = a[n];
            a[n] = temp;
        }
    }
}