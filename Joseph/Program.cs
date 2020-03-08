using System;
using System.Linq;

namespace Joseph
{
    class Program
    {
        static void Main(string[] args)
        {
            Joseph_LinkedList j = new Joseph_LinkedList();
            j.Init(125);
            j.Count(10, 20);
            //j.ToString();

            Console.ReadLine();
        }
    }


    public class Joseph_LinkedList
    {
        public Boy first;
        public int Num;
        public void Init(int num = 10)
        {
            if (num <= 0) num = 10;
            Num = num;
            Boy temp = new Boy();

            for (int i = 1; i <= num; i++)
            {
                Boy b = new Boy
                {
                    no = i
                };
                if (i == 1)
                {
                    first = b;
                    temp = first;
                }
                else if (i == num)
                {
                    temp.next = b;
                    b.next = first;
                    temp = null;
                }
                else
                {
                    temp.next = b;
                    temp = b;
                }
            }
        }

        public override string ToString()
        {
            Boy temp = first;

            while (true)
            {
                temp.ToString();
                if (temp.next == first)
                {
                    break;
                }
                temp = temp.next;
            }
            return base.ToString();
        }

        public void Count(int start, int interval)
        {
            if (first == null)
            {
                Init();
            }

            if (start <= 0 || start > Num) return;

            Boy temp = first;
            while (temp.next != first)//temp point to last node
            {
                temp = temp.next;
            }

            for (int i = 1; i < start; i++)//move both temp and first, so first point to the starter temp point to the previous of the starter
            {
                temp = temp.next;
                first = first.next;
            }

            while (first != first.next)//only one boy left
            {
                //move both temp and first, so temp point to the previous of the deleted boy
                for (int i = 1; i < interval; i++)
                {
                    first = first.next;
                    temp = temp.next;
                }
                first.ToString();
                first = first.next;
                temp.next = first;
            }
            first.ToString();
        }

        int f(int n, int m)
        {
            return n == 1 ? n : (f(n - 1, m) + m - 1) % n + 1;
        }
    }

    

    public class Boy
    {
        public int no;
        public Boy next;

        public override string ToString()
        {
            Console.WriteLine(no);
            return base.ToString();
        }
    }
}
