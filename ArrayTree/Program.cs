using System;

namespace ArrayTree
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            ArrayTree t1 = new ArrayTree(a);
            //t1.PreOrder();
            //t1.InfixOrder();
            t1.PostOrder();
            Console.Read();
        }
    }

    public class ArrayTree
    {
        int[] a;
        public ArrayTree(int[] a)
        {
            this.a = a;
        }
        public void PreOrder(int i = 0)
        {
            if (a?.Length == 0) throw new Exception("invalid a");
            if (i > a.Length - 1) return;
            Console.WriteLine(a[i]);
            if (i * 2 + 1 <= a.Length - 1)
            {
                PreOrder(i * 2 + 1);
            }

            if (i * 2 + 2 <= a.Length - 1)
            {
                PreOrder(i * 2 + 2);
            }
        }

        public void InfixOrder(int i = 0)
        {
            if (a?.Length == 0) throw new Exception("invalid a");
            if (i > a.Length - 1) return;

            if (i * 2 + 1 <= a.Length - 1)
            {
                InfixOrder(i * 2 + 1);
            }

            Console.WriteLine(a[i]);

            if (i * 2 + 2 <= a.Length - 1)
            {
                InfixOrder(i * 2 + 2);
            }
        }

        public void PostOrder(int i = 0)
        {
            if (a?.Length == 0) throw new Exception("invalid a");
            if (i > a.Length - 1) return;

            if (i * 2 + 1 <= a.Length - 1)
            {
                PostOrder(i * 2 + 1);
            }

            if (i * 2 + 2 <= a.Length - 1)
            {
                PostOrder(i * 2 + 2);
            }

            Console.WriteLine(a[i]);
        }
    }
}
