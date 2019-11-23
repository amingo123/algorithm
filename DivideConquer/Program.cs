using System;
using System.Collections.Generic;
using System.Linq;

namespace DivideConquer
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> a = new Stack<string>();
            Stack<string> b = new Stack<string>();
            Stack<string> c = new Stack<string>();
            a.Push("f");
            a.Push("e");
            a.Push("d");
            a.Push("c");
            a.Push("b");
            a.Push("a");
            HanNoTa(a.Count, 'a', 'b', 'c', a, b, c);
            Console.WriteLine(string.Join(',', c.ToArray()));
            Console.Read();
        }

        public static void HanNoTa(int num, char a, char b, char c, Stack<string> aa, Stack<string> bb, Stack<string> cc)
        {
            if (num == 1)
            {
                Console.WriteLine("第1个从{0}移动到{1}", a,c);
                cc.Push(aa.Pop());
            }
            else
            {
                HanNoTa(num - 1, a, c, b, aa, cc, bb);
                Console.WriteLine("第{2}个从{0}移动到{1}", a, c, num);
                cc.Push(aa.Pop());
                HanNoTa(num - 1, b, a, c, bb, aa, cc);
            }
        }
    }
}
