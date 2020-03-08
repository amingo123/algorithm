using System;

namespace GroupedDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new GroupedDictionary
            {
                { new GroupEntry { GroupId = 1, SomeValue = "1a" }, 0 },
                { new GroupEntry { GroupId = 1, SomeValue = "1b" }, 0 },
                { new GroupEntry { GroupId = 1, SomeValue = "1c" }, 0 },
                { new GroupEntry { GroupId = 1, SomeValue = "1d" }, 0 },
                { new GroupEntry { GroupId = 2, SomeValue = "2a" }, 0 },
                { new GroupEntry { GroupId = 2, SomeValue = "2b" }, 0 },
                { new GroupEntry { GroupId = 2, SomeValue = "2c" }, 0 },
                { new GroupEntry { GroupId = 3, SomeValue = "3a" }, 0 },
                { new GroupEntry { GroupId = 3, SomeValue = "3b" }, 0 }
            };
            Console.WriteLine("---------------------------------------------------");
            GroupedDictionary b = a.GetByGroupId(1);
            Console.Read();
        }
    }
}
