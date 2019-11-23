using System;

namespace Joseph
{
    class Program
    {
        static void Main(string[] args)
        {
            Joseph j = new Joseph();
            j.Init(125);
            j.Count(10, 20);
            //j.ToString();
            Console.ReadLine();
        }
    }


    public class Joseph
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
                    first.next = first;
                    temp = first;
                }
                else
                {
                    temp.next = b;
                    b.next = first;
                    temp = b;
                }
            }
        }

        public override string ToString()
        {
            Boy temp = first;
            //while (first != temp.next)
            //{
            //    temp.ToString();
            //    temp = temp.next;
            //}
            //temp.ToString();

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

            for (int i = 1; i < start; i++)
            {
                temp = temp.next;
                first = first.next;
            }

            while (first != first.next)
            {
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
