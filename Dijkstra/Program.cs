using System;

namespace Dijkstra
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 65535;
            char[] Vetex = { 'A', 'B', 'C', 'D', 'E', 'F', 'G' };
            int[,] Matrix = new int[,]
            {
                { N, 5, 7, N, N, N, 2 },
                { 5, N, N, 9, N, N, 3 },
                { 7, N, N, N, 8, N, N },
                { N, 9, N, N, N, 4, N },
                { N, N, 8, N, N, 5, 4 },
                { N, N, N, 4, 5, N, 6 },
                { 2, 3, N, N, 4, 6, N }
            };
            Graph G = new Graph(Vetex, Matrix,6);
            G.ShowDijkstra();
            Console.Read();
        }
    }

    class Graph
    {
        char[] Vetex;
        int[,] Matrix;
        VisitedVetex vv;
        readonly int StartIndex;

        public Graph(char[] Vetex, int[,] Matrix,int StartIndex)
        {
            this.Vetex = Vetex;
            this.Matrix = Matrix;
            this.StartIndex = StartIndex;
            vv = new VisitedVetex(Vetex.Length, StartIndex);
        }

        public void ShowDijkstra()
        {
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    Console.Write(Matrix[i, j] + "\t\t");
                }
                Console.WriteLine();
                Console.WriteLine();
            }

            int[] a = GetDistance(StartIndex);
            Console.WriteLine(string.Join(',', a));
        }

        /// <summary>
        /// 出发顶点对应下标
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private int[] GetDistance(int index)
        {
            UpdateDisAndPre(index);
            int i = GetNextVetex();
            if (i == -1)
            {
                return vv.dis;
            }
            else
            {
                return GetDistance(i);
            }
        }

        int GetNextVetex()
        {
            int max = 65535;
            int index = -1;
            for (int i = 0; i < Vetex.Length; i++)
            {
                if (!vv.AlreadyVisited(i) && vv.GetDis(i) < max && vv.GetDis(i) != 0)
                {
                    index = i;
                    max = vv.GetDis(i);
                }
            }
            return index;
        }

        /// <summary>
        /// 从出发顶点开始计算到v下标顶点的周围顶点的距离和周围顶点的前驱顶点
        /// </summary>
        public void UpdateDisAndPre(int v)
        {
            int len = 0;
            for (int i = 0; i < Vetex.Length; i++)
            {
                if (i == v) continue;
                len = Matrix[v, i] + vv.dis[v];// ab=5 ac =3, bc=1， 计算acb 3+1<5
                if (len < vv.dis[i] && !vv.AlreadyVisited(i))
                {
                    vv.UpdateDis(i,len);
                    vv.UpdatePre(v, i);
                }
            }
            vv.already_arr[v] = 1;
        }
    }

    class VisitedVetex
    {
        //记录各个顶点是否访问过
        public int[] already_arr;

        //记录前一个顶点下标的值
        public int[] pre_arr;

        public int[] dis;

        public VisitedVetex(int length, int index)
        {
            already_arr = new int[length];
            pre_arr = new int[length];
            dis = new int[length];
            Array.Fill(dis, 65535);
            dis[index] = 0;
        }

        /// <summary>
        /// 判断index顶点是否被访问过
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool AlreadyVisited(int index)
        {
            return already_arr[index] == 1;
        }

        /// <summary>
        /// 更新出发顶点到index顶点的dis
        /// </summary>
        /// <param name="index"></param>
        /// <param name="dis"></param>
        public void UpdateDis(int index, int distance)
        {
            dis[index] = distance;
        }

        /// <summary>
        /// 更新pre这个顶点的前驱顶点为index顶点
        /// </summary>
        /// <param name="pre"></param>
        /// <param name="index"></param>
        public void UpdatePre(int pre, int index)
        {
            pre_arr[index] = pre;
        }

        /// <summary>
        /// 返回出发顶点到index顶点的距离
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public int GetDis(int index)
        {
            return dis[index];
        }
    }
}
