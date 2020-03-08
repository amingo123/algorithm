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
            //var a = new GroupedDictionary
            //{
            //    { new GroupEntry { GroupId = 1, SomeValue = "1a" }, 0 },
            //    { new GroupEntry { GroupId = 1, SomeValue = "1b" }, 0 },
            //    { new GroupEntry { GroupId = 1, SomeValue = "1c" }, 0 },
            //    { new GroupEntry { GroupId = 1, SomeValue = "1d" }, 0 },
            //    { new GroupEntry { GroupId = 2, SomeValue = "2a" }, 0 },
            //    { new GroupEntry { GroupId = 2, SomeValue = "2b" }, 0 },
            //    { new GroupEntry { GroupId = 2, SomeValue = "2c" }, 0 },
            //    { new GroupEntry { GroupId = 3, SomeValue = "3a" }, 0 },
            //    { new GroupEntry { GroupId = 3, SomeValue = "3b" }, 0 }
            //};
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
            GroupedDictionary b = a.GetByGroupId(1);
            sw.Stop();
            Console.WriteLine(sw.ElapsedTicks);


            sw.Start();
            a.ContainsKey(new GroupEntry { GroupId = -1, SomeValue = -1 });
            sw.Stop();
            Console.WriteLine(sw.ElapsedTicks);

            sw.Start();
            a.ContainsKey(new GroupEntry { GroupId = 1 , SomeValue = 1 });
            sw.Stop();
            Console.WriteLine(sw.ElapsedTicks);

            sw.Start();
            a.ContainsKey(new GroupEntry { GroupId = 1, SomeValue = 1999 });
            sw.Stop();
            Console.WriteLine(sw.ElapsedTicks);


            sw.Start();
            a.ContainsKey(new GroupEntry { GroupId = 499, SomeValue = 1999 });
            sw.Stop();
            Console.WriteLine(sw.ElapsedTicks);

            sw.Start();
            a.ContainsKey(new GroupEntry { GroupId = 499, SomeValue = 1 });
            sw.Stop();
            Console.WriteLine(sw.ElapsedTicks);
            Console.Read();
        }
    }
}
