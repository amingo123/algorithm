using System;

namespace PowerofTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            IsPowerofTwo(1);
            IsPowerofTwo(2);
            IsPowerofTwo(3);
            IsPowerofTwo(4);
            IsPowerofTwo(15);
            IsPowerofTwo(65536);
            Console.Read();
        }

        static bool IsPowerofTwo(int n)
        {
            if (n < 1) return false;
            bool result = (n & (n - 1)) == 0;
            if (result)
            {
                Console.WriteLine($"{n}是2的幂次方");
            }
            else
            {
                Console.WriteLine($"{n}不是2的幂次方");
            }
            return result;
        }
    }
}
