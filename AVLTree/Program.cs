using System;

namespace AVLTree
{
    class Program
    {
        //bst  binary search tree
        static void Main(string[] args)
        {
            int[] a = { 4, 3, 6, 5, 7, 8 };
            for (int i = 0; i < a.Length; i++)
            {
                AVLTree.add(new Node(a[i]));
            }
            AVLTree.InfixOrder();
            Console.WriteLine(AVLTree.root.Height);
            Console.WriteLine(AVLTree.root.LeftHeight);
            Console.WriteLine(AVLTree.root.RightHeight);
            Console.WriteLine("----------------------");
            AVLTree.clear();

            a = new int[] { 10, 12, 8, 9, 7, 6 };
            for (int i = 0; i < a.Length; i++)
            {
                AVLTree.add(new Node(a[i]));
            }
            AVLTree.InfixOrder();
            Console.WriteLine(AVLTree.root.Height);
            Console.WriteLine(AVLTree.root.LeftHeight);
            Console.WriteLine(AVLTree.root.RightHeight);
            Console.Read();
        }
    }

    public class AVLTree
    {
        public static Node root;

        public static void clear()
        {
            root = null;
        }

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

            if (RightHeight - LeftHeight > 1) LeftRotate();
            if (LeftHeight - RightHeight > 1) RightRotate();
            //左旋和右旋并不能使树达到平衡的状态，还需要使用双旋

        }

        public void RightRotate()
        {
            Node newNode = new Node(value)
            {
                right = right,
                left = left.right
            };
            value = left.value;
            left = left.left;
            right = newNode;
        }

        public void LeftRotate()
        {
            Node newNode = new Node(value)
            {
                left = left,
                right = right.left
            };
            value = right.value;
            right = right.right;
            left = newNode;
        }

        public int Height
        {
            get
            {
                return Math.Max(left == null ? 0 : left.Height, right == null ? 0 : right.Height) + 1;
            }
        }

        public int LeftHeight
        {
            get
            {
                if (left == null) return 0;
                return left.Height;
            }
        }

        public int RightHeight
        {
            get
            {
                if (right == null) return 0;
                return right.Height;
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
