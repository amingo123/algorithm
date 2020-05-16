using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] s = new char[] { '1','2','3','4','5','6','7' };
            ReverseString(s);
            Console.Write(s);
            Console.Read();
        }

        public static void ReverseString(char[] s)
        {
            if (s?.Length < 2) return;
            char temp;
            for (int i = 0; i < s.Length / 2; i++)
            {
                temp = s[i];
                s[i] = s[s.Length - i - 1];
                s[s.Length - i - 1] = temp;
            }
        }
    }
} 