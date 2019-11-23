using System;

namespace KMP
{
    class Program
    {
        static void Main(string[] args)
        {
            string source = "bbc abcdab abcdabcdabde";
            string s = "abcdabd";
            int[] a = GetPartialMatchTable(s);
            Console.WriteLine(string.Join(' ', a));

            int index = KMPSearch(source, s, a);
            Console.Read();
        }


        public static int KMPSearch(string source, string s, int[] next)
        {
            for (int i = 0,j = 0; i < source.Length; i++)
            {
                while (j > 0 && source[i] != s[j])
                {
                    j = next[j - 1];
                }

                if (source[i] == s[j])
                {
                    j++;
                }

                if (j == s.Length)
                {
                    return i - j + 1;
                }
            }
            return -1;
        }

        static int[] GetPartialMatchTable(string s)
        {
            int[] a = new int[s.Length];
            a[0] = 0;
            for (int i = 1, j = 0; i < s.Length; i++)
            {
                while (j > 0 && s[i] != s[j])
                {
                    j = a[j - 1];
                }

                if (s[i] == s[j])
                {
                    j++;
                }
                a[i] = j;
            }

            //for (int i = 1, j = 0; i < s.Length; i++)
            //{
            //    if (s[i] == s[j])
            //    {
            //        j++;
            //    }
            //    else
            //    {
            //        j = 0;
            //    }
            //    a[i] = j;
            //}

            // 第一位设为-1，方便判断当前位置是否为搜索词的最开始
            //a[0] = -1;
            //int i = 0;
            //int j = -1;

            //while (i < s.Length - 1)
            //{
            //    if (j == -1 || s[i] == s[j])
            //    {
            //        i++;
            //        j++;
            //        a[i] = j;
            //    }
            //    else
            //    {
            //        j = a[j];
            //    }
            //}

            return a;
        }
    }
}
