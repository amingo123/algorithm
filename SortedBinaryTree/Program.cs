using System;

namespace SortedBinaryTree
{
    class Program
    {
        //bst  binary search tree
        static void Main(string[] args)
        {
            int[] a = { 7, 3, -10, 12, -5, 0, 1, 9 };
            for (int i = 0; i < a.Length; i++)
            {
                SortedBinaryTree.add(new Node(a[i]));
            }
            SortedBinaryTree.InfixOrder();
            Console.Read();
        }
    }

    public class SortedBinaryTree
    {
        static Node root;

        public static void add(Node n)
        {
            if (root == null)
            {
                root = n;
            }
            else
            {
                root.add(n);
            }
        }

        public static void InfixOrder()
        {
            if (root != null) root.InfixOrder();
        }
    }

    public class Node
    {
        public int value;
        public Node left;
        public Node right;

        public Node(int v)
        {
            value = v;
        }
        public void add(Node n)
        {
            if (n == null) return;
            if (value > n.value)
            {
                if (left == null)
                {
                    left = n;
                }
                else
                {
                    left.add(n);
                }
            }
            else
            {
                if (right == null)
                {
                    right = n;
                }
                else
                {
                    right.add(n);
                }
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

        public override string ToString()
        {
            Console.WriteLine(value);
            return base.ToString();
        }
    }
}
