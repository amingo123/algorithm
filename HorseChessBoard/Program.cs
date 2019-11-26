using System;
using System.Collections.Generic;
using System.Drawing;

namespace HorseChessBoard
{
    class Program
    {
        static int X, Y;//x列数 y行数
        static bool[] Visited;
        static bool Finished;
        static void Main(string[] args)
        {
            X = 6;
            Y = 6;
            int[,] board = new int[X, Y];
            Visited = new bool[X * Y];
            HorseChessBoard(board, 0, 0, 1);
            Console.Read();
        }

        static void HorseChessBoard(int[,] board, int row, int column, int step)
        {
            if (Finished) return;

            board[row,column] = step;
            Visited[row * X + column] = true;
            List<Point> points = Next(new Point(row, column));
            while (points.Count > 0)
            {
                Point p = points[0];
                points.RemoveAt(0);
                if (!Visited[p.Y * X + p.X])
                {
                    HorseChessBoard(board, p.Y, p.X, step + 1);
                }
            }

            if (step < X * Y && !Finished)
            {
                board[row, column] = 0;
                Visited[row * X + column] = false;
            }
            else
            {
                Finished = true;
            }
        }

        static List<Point> Next(Point p)
        {
            List<Point> list = new List<Point>();
            if (p.X - 2 >= 0 && p.Y - 1 >= 0)
            {
                list.Add(new Point(p.X - 2, p.Y - 1));
            }

            if (p.X - 1 >= 0 && p.Y - 2 >= 0)
            {
                list.Add(new Point(p.X - 1, p.Y - 2));
            }

            if (p.X + 1 < X && p.Y - 2 >= 0)
            {
                list.Add(new Point(p.X + 1, p.Y - 2));
            }

            if (p.X + 2 < X && p.Y - 1 >= 0)
            {
                list.Add(new Point(p.X + 2, p.Y - 1));
            }

            if (p.X + 2 < X && p.Y + 1 < Y)
            {
                list.Add(new Point(p.X + 2, p.Y + 1));
            }

            if (p.X + 1 < X && p.Y + 2 < Y)
            {
                list.Add(new Point(p.X + 1, p.Y + 2));
            }

            if (p.X - 1 >= 0 && p.Y + 2 < Y)
            {
                list.Add(new Point(p.X - 1, p.Y + 2));
            }

            if (p.X - 2 >= 0 && p.Y + 1 < Y)
            {
                list.Add(new Point(p.X - 2, p.Y + 1));
            }
            return list;
        }
    }
}
