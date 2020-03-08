using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace GroupedDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new GroupedDictionary();

            for (int i = 0; i < 500; i++)
            {
                for (int j = 0; j < 2000; j++)
                {
                    a.Add(new GroupEntry { GroupId = i, SomeValue = j }, 0);
                }
                Console.WriteLine(i);
            }

            Console.WriteLine("---------------------------------------------------");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            GroupedDictionary b = a.GetByGroupId(new GroupEntry { GroupId = 1, SomeValue =1 });
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);


            sw.Start();
            a.ContainsKey(new GroupEntry { GroupId = -1, SomeValue = -1 });
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);

            sw.Start();
            a.ContainsKey(new GroupEntry { GroupId = 1 , SomeValue = 1 });
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);

            sw.Start();
            a.ContainsKey(new GroupEntry { GroupId = 1, SomeValue = 1999 });
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);


            sw.Start();
            a.ContainsKey(new GroupEntry { GroupId = 499, SomeValue = 1999 });
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);

            sw.Start();
            a.ContainsKey(new GroupEntry { GroupId = 499, SomeValue = 1 });
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
            Console.Read();
        }
    }
}
