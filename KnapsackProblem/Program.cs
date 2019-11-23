using System;
using System.Collections.Generic;

namespace KnapsackProblem
{
    public class KnapsackProblem
    {
        static void Main(string[] args)
        {
            char[,] matrix = new char[4, 4]{ { '0', '1', '1', '1' },
                                             { '0', '1', '1', '1' },
                                             { '0', '1', '1', '1' },
                                             { '0', '1', '0', '0' } };
            int i = MaximalSquare(matrix);
            Console.WriteLine(i);
            //GetMostPrice();
            Console.Read();
        }

        private static void GetMostPrice()
        {
            Dictionary<int, int> dict = new Dictionary<int, int>()
            {
                {1,1500 }, //1重量 1500价值
                {4,3000 },
                {3,2000 }
            };

            int[] pound = { 1, 4, 3 };
            int[] price = { 1500, 3000, 2000 };
            int capacity = 4;//背包容量
            int num = pound.Length;//物品个数   每种物品只能装一个

            //创建二维数组，v[i,j]表示前i个物品中，能够装入容量为j的背包中的最大价值
            int[,] v = new int[num + 1, capacity + 1];

            //初始化第一行和第一列为0
            for (int i = 0; i < num + 1; i++)
            {
                v[i, 0] = 0;
            }
            for (int i = 0; i < capacity + 1; i++)
            {
                v[0, i] = 0;
            }

            //初始化第一行为price 第一列为pound
            for (int i = 1; i <= capacity; i++)
            {
                v[0, i] = i;
            }
            for (int i = 1; i <= pound.Length; i++)
            {
                v[i, 0] = pound[i - 1];
            }

            for (int i = 1; i < v.GetLength(0); i++)
            {
                for (int j = 1; j < v.GetLength(1); j++)
                {
                    if (v[i, 0] > v[0, j]) //待加入的物品比当前背包大
                    {
                        v[i, j] = v[i - 1, j];
                    }
                    else
                    {
                        int c = v[i, 0];//待加入的容量

                        v[i, j] = Math.Max(dict[c] + v[i - 1, v[0, j] - c], v[i - 1, j]);
                    }
                }
            }

            //show
            for (int i = 0; i < v.GetLength(0); i++)
            {
                for (int j = 0; j < v.GetLength(1); j++)
                {
                    Console.Write(v[i, j] + "\t");
                }
                Console.WriteLine("");
            }
        }

        public static int MaximalSquare(char[,] matrix)
        {
            if (matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0)
            {
                return 0;
            }

            int m = matrix.GetLength(0), n = matrix.GetLength(1);

            int[,] dp = new int[m, n];

            int maxLength = 0;

            for (int i = 0; i < m; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (matrix[i,j] == '1')
                    {
                        if (i == 0 || j == 0)
                        {
                            dp[i,j] = matrix[i,j] == '1' ? 1 : 0;
                        }
                        else
                        {
                            dp[i,j] = Math.Min(dp[i - 1,j],
                                                Math.Min(dp[i,j - 1], dp[i - 1,j - 1])) + 1;
                        }

                        maxLength = Math.Max(dp[i,j], maxLength);
                    }
                }
            }

            return maxLength * maxLength;
        }
    }
}
