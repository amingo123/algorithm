using System;

namespace DynamicProgramming
{    
    class Program
    {
        static void Main(string[] args)
        {
            int i = Fibonacci.Calc(6);
            Console.WriteLine(i);

            int[] arr = { 2, 5, 9 };
            int amount = 15;
            i = ChooseCoins_Recursion(amount, arr);
            Console.WriteLine(i);

            i = ChooseCoins_DP(amount, arr);
            Console.WriteLine(i);
            Console.Read();
        }

        //给你 k 种面值的硬币，面值分别为 c1, c2 ... ck，每种硬币的数量无限，再给一个总金额 amount，
        //问你最少需要几枚硬币凑出这个金额，如果不可能凑出，算法返回 -1
        //【状态转移方程】 dp(n)
        //1. n=0时 等于 0
        //2. n<0时 等于 -1
        //3. n>0时 等于 [min{dp(n - coin) + 1|coin∈coins}]
        //【备忘录 DP table】
        //【重叠子问题】
        //【最优子结构】
        //base case，显然目标金额为 0 时，所需硬币数量为 0；当目标金额小于 0 时，无解，返回 -1
        static int ChooseCoins_Recursion(int amount, int[] arr)
        {
            if (amount == 0) return 0;
            if (amount < 0) return -1;
            //result = memo[n] 备忘录

            int result = -1;
            int temp = -1;
            for (int i = 0; i < arr.Length; i++)
            {
                temp = ChooseCoins_Recursion(amount - arr[i], arr);
                if (temp == -1)
                {
                    continue;
                }
                if (result == -1)
                {
                    result = temp;
                }
                else
                {
                    result = Math.Min(result, temp);
                }
                
            }
            return result == -1 ? -1 :result + 1;
        }

        static int ChooseCoins_DP(int amount, int[] arr)
        {
            int[] dp = new int[amount + 1];
            dp[0] = 0;
            for (int i = 1; i < dp.Length; i++)
            {
                foreach (int r in arr)
                {
                    if (i - r < 0) continue;
                    if (dp[i - r] == -1) continue;
                    if (dp[i] == 0)
                    {
                        dp[i] = dp[i - r] + 1;
                    }
                    else
                    {
                        dp[i] = Math.Min(dp[i], 1 + dp[i - r]);
                    }
                    //if (i - r < 0)
                    //{
                    //    if (dp[i] == 0)
                    //    {
                    //        dp[i] = -1;
                    //    }
                    //}
                    //else if (dp[i - r] == -1)
                    //{
                    //    dp[i] = -1;
                    //}
                    //else if (dp[i] == 0)
                    //{
                    //    dp[i] = dp[i - r] + 1;
                    //}
                    //else
                    //{
                    //    dp[i] = Math.Min(dp[i], 1 + dp[i - r]);
                    //}
                }
                if (dp[i] == 0)
                {
                    dp[i] = -1;
                }
            }
            return dp[amount];
        }
    }

    class Fibonacci
    {
        static int[] arr;

        public static int Calc(int n)
        {
            if (n <= 0) return 0;
            arr = new int[n + 1];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = -1;
            }
            return Fib_Recursion(n, arr);
        }

        /// <summary>
        /// recursion 递归
        /// </summary>
        /// <param name="n"></param>
        /// <param name="_arr"></param>
        /// <returns></returns>
        private static int Fib_Recursion(int n, int[] _arr)
        {
            if (n <= 2)
            {
                _arr[n] = 1;
            }

            if (_arr[n] == -1)
            {
                _arr[n] = Fib_Recursion(n - 1, _arr) + Fib_Recursion(n - 2, _arr);
            }

            return _arr[n];
        }

        //重叠子问题、最优子结构、状态转移方程就是动态规划三要素
        //状态转移方程:把Memo_i_2想做一个状态 n，这个状态 n 是由状态 Memo_i_1 和状态 Memo_i 相加转移而来，这就叫状态转移.
        //备忘录或者 DP table: 存储Memo_i, Memo_i_1, Memo_i_2的就是DP Table
        public static int Calc_DP(int n)
        {
            if (n <= 1) return n;

            int Memo_i_2 = 0;
            int Memo_i_1 = 1;
            int Memo_i = 1;
            for (int i = 2; i <= n; i++)
            {
                Memo_i = Memo_i_2 + Memo_i_1;
                Memo_i_2 = Memo_i_1;
                Memo_i_1 = Memo_i;
            }
            return Memo_i;
        }
    }
}
