using System;

namespace Tree1
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree1 t1 = new Tree1(1, "1");
            Tree1 t2 = new Tree1(2, "2");
            Tree1 t3 = new Tree1(3, "3");
            Tree1 t4 = new Tree1(4, "4");
            Tree1 t5 = new Tree1(5, "5");
            Tree1 t6 = new Tree1(6, "6");
            t1.left = t2;
            t1.right = t3;
            t3.right = t4;
            //t1.PreOrder();
            //t1.InfixOrder();
            t1.PostOrder();
            Console.Read();
        }
    }

    public class Tree1
    {
        public int id;
        public string name;
        public Tree1 left;
        public Tree1 right;

        public Tree1(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public override string ToString()
        {
            Console.WriteLine("id={0} name={1}",id,name);
            return base.ToString();
        }

        public void PreOrder()
        {
            ToString();
            if (left != null)
            {
                left.PreOrder();
            }

            if (right != null)
            {
                right.PreOrder();
            }
        }

        public void InfixOrder()
        {
            if (left != null)
            {
                left.InfixOrder();
            }

            ToString();

            if (right != null)
            {
                right.InfixOrder();
            }
        }

        public void PostOrder()
        {
            if (left != null)
            {
                left.PostOrder();
            }

            if (right != null)
            {
                right.PostOrder();
            }
            ToString();
        }
    }
}
