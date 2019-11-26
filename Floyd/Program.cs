using System;

namespace Floyd
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 65535;
            char[] Vetex = { 'A', 'B', 'C', 'D', 'E', 'F', 'G' };
            int[,] Matrix = new int[,]
            {
                { 0, 1, 7, N, N, N, 20 },
                { 1, 0, N, 1, N, N, 11 },
                { 7, N, 0, N, 8, N, N },
                { N, 1, N, 0, N, 1, N },
                { N, N, 8, N, 0, 5, 4 },
                { N, N, N, 1, 5, 0, 1 },
                { 20, 11, N, N, 4, 1, 0 }
            };
            //int[,] Matrix = new int[,]
            //{
            //    { 0, 5, 7, N, N, N, 2 },
            //    { 5, 0, N, 9, N, N, 3 },
            //    { 7, N, 0, N, 8, N, N },
            //    { N, 9, N, 0, N, 4, N },
            //    { N, N, 8, N, 0, 5, 4 },
            //    { N, N, N, 4, 5, 0, 6 },
            //    { 2, 3, N, N, 4, 6, 0 }
            //};
            Graph G = new Graph(Matrix, Vetex);
            G.ShowFloyd();
            Console.Read();
        }
    }

    class Graph
    {
        int[,] pre;
        int[,] dis;
        char[] vertex;
        int length;

        public Graph(int[,] Matrix, char[] vertex)
        {
            this.vertex = vertex;
            dis = Matrix;
            pre = new int[vertex.Length, vertex.Length];
            length = vertex.Length;
            for (int i = 0; i < pre.GetLength(0); i++)
            {
                for (int j = 0; j < pre.GetLength(1); j++)
                {
                    pre[i, j] = i;
                }
            }
        }

        public void Show()
        {
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    Console.Write(vertex[pre[i, j]]+"\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine();

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    Console.Write(vertex[i] + "到" + vertex[j] + "=" + dis[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        public void ShowFloyd()
        {
            int len = 0;
            //k中间点
            for (int k = 0; k < length; k++)
            {
                //i出发点
                for (int i = 0; i < length; i++)
                {
                    //j终点
                    for (int j = 0; j < length; j++)
                    {
                        len = dis[i, k] + dis[k, j];
                        if (len < dis[i, j])
                        {
                            dis[i, j] = len;
                            pre[i, j] = pre[k, j];
                        }
                    }
                }
            }
            Show();
        }       
    }
}
