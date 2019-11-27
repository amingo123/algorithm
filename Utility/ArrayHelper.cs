using System;

namespace Utility
{
    public static class ArrayHelper
    {
        public static void Show<T>(T[,] t)
        {
            for (int i = 0; i < t.GetLength(0); i++)
            {
                for (int j = 0; j < t.GetLength(1); j++)
                {
                    Console.Write(t[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
