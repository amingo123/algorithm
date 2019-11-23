using System;
using System.Collections.Generic;

namespace EightQueen
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[8];
            ////Eightqueen.validate(a);
            //Console.WriteLine(string.Join(',',a));

            Eightqueen.setqueen(a);
            Console.WriteLine(Eightqueen.count);
            Console.ReadLine();
        }
    }

    public class Eightqueen
    {
        public static int count = 0;
        static int max = 8;

        public static void setqueen(int[] a)
        {
            if (a?.Length < 8)
            {
                throw new Exception("a less than 8");
            }

            if (a[max - 1] != 0)
            {
                Console.WriteLine(string.Join(',',a));
                count++;
                return;
            }

            int i = 0;
            for (i = 0; i < max; i++)
            {
                if (a[i] == 0)
                {
                    break;
                }
            }

            for (int m = 0; m < max; m++)
            {
                a[i] = m + 1;
                bool b = validate(a);
                if (b)
                {
                    setqueen(a);
                }
            }

            a[i] = 0;
        }

        //public static bool validate(int[] a)
        //{
        //    if (a?.Length != 8)
        //    {
        //        throw new Exception("a less than 8");
        //    }

        //    if (a[0] == 0)
        //    {
        //        throw new Exception("blank a");
        //    }
        //    if (isrepeat(a)) return false;
        //    //for (int i = 0; i < a.Length; i++)
        //    //{
        //    //    if (a[i] == 0) break;

        //    //    if (i == 0) // head
        //    //    {
        //    //        if (a[i] + 1 == a[i + 1] || a[i] - 1 == a[i + 1])
        //    //        {
        //    //            return false;
        //    //        }
        //    //    }
        //    //    else if (i == a.Length - 1 || a[i+1] == 0) //end
        //    //    {
        //    //        if (a[i] + 1 == a[i - 1] || a[i] - 1 == a[i - 1])
        //    //        {
        //    //            return false;
        //    //        }
        //    //    }
        //    //    else
        //    //    {
        //    //        if (a[i] + 1 == a[i - 1] || a[i] - 1 == a[i - 1] || a[i] + 1 == a[i + 1] || a[i] - 1 == a[i + 1])
        //    //        {
        //    //            return false;
        //    //        }
        //    //    }
        //    //}
        //    return true;
        //}

        public static bool validate(int[] a)
        {
            if (a?.Length != 8)
            {
                throw new Exception("a less than 8");
            }

            if (a[0] == 0)
            {
                throw new Exception("blank a");
            }

            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a.Length; j++)
                {
                    if (j <= i)
                    {
                        continue;
                    }
                    if (a[i] == a[j] && a[j] != 0)
                    {
                        return false;
                    }
                }
            }

            for (int i = 0; i < max; i++)
            {
                if (a[i] == 0) break;
                for (int j = 0; j < max; j++)
                {
                    if (a[j] == 0) break;
                    if (j <= i)
                    {
                        continue;
                    }
                    if ((a[i] + i == a[j] + j) || (Math.Abs(j-i) == Math.Abs(a[j] - a[i])))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}