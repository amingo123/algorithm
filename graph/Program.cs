using System;
using System.Collections.Generic;

namespace graph
{
    class Program
    {        
        static void Main(string[] args)
        {
            string[] a = { "A","B","C","D","E"};
            Grahp g = new Grahp(a.Length);
            foreach (var item in a)
            {
                g.InsertVetex(item);
            }
            g.InsertEdge(0, 1, 1);
            g.InsertEdge(0, 2, 1);
            g.InsertEdge(1, 2, 1);
            g.InsertEdge(1, 3, 1);
            g.InsertEdge(1, 4, 1);
            g.Show();
            g.DepthFirstSearch();
            Console.Read();
        }
    }

    class Grahp
    {
        List<string> vetexList;
        int[,] edges;
        bool[] isVisited;
        public int numOfEdges;
        public Grahp(int n)
        {
            vetexList = new List<string>(n);
            edges = new int[n, n];
            numOfEdges = 0;
            isVisited = new bool[5];
        }

        /// <summary>
        /// 添加顶点
        /// </summary>
        /// <param name="vetex"></param>
        public void InsertVetex(string vetex)
        {
            vetexList.Add(vetex);
        }

        public string GetValueByIndex(int i)
        {
            return vetexList[i];
        }

        public int GetNumOfVetex()
        {
            return vetexList.Count;
        }

        public string Getweight(int v1, int v2)
        {
            if (v1 >= edges.Length || v2 >= edges.Length) return string.Empty;
            return edges[v1, v2].ToString(); 
        }

        public void InsertEdge(int v1,int v2, int weight)
        {
            if (v1 >= edges.Length || v2 >= edges.Length) return;
            edges[v1, v2] = weight;
            edges[v2, v1] = weight;
            numOfEdges++;
        }

        public void Show()
        {
            for (int i = 0; i < edges.GetLength(0); i++)
            {
                for (int j = 0; j < edges.GetLength(1); j++)
                {
                    Console.Write(edges[i, j] + "\t");
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        public int GetNextNeighbor(int v1,int v2)
        {
            for (int i = v2 + 1; i < vetexList.Count; i++)
            {
                if (edges[v1, i] > 0) return i;
            }
            return -1;
        }

        public void DepthFirstSearch()
        {
            DepthFirstSearch(0, 0);
        }

        public void BoardFirstSearch()
        {

        }

        public void DepthFirstSearch(int m,int n)
        {
            if (!isVisited[m])
            {
                Console.Write(GetValueByIndex(m) + "->");
            }

            isVisited[m] = true;
            
            int k = GetNextNeighbor(m,n);
            int j = k;
            while (k != -1 && j < vetexList.Count)
            {
                DepthFirstSearch(k, j);
                j++;
            }
        }
    }
}
