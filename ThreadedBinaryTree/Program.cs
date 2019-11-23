using System;

namespace ThreadedBinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            treenode t1 = new treenode(1, "1");
            treenode t3 = new treenode(3, "3");
            treenode t6 = new treenode(6, "6");
            treenode t8 = new treenode(8, "8");
            treenode t10 = new treenode(10, "10");
            treenode t14 = new treenode(14, "14");
            t1.left = t3;
            t1.right = t6;
            t3.left = t8;
            t3.right = t10;
            t6.left = t14;
            InfixThreadedBinaryTree infixThreadedBinaryTree = new InfixThreadedBinaryTree(t1);
            infixThreadedBinaryTree.ThreadNode();
            //treenode aaa = t10.left;
            //treenode bbb = t10.right;
            infixThreadedBinaryTree.ThreadedList();
            Console.Read();
        }
    }

    public class treenode
    {
        public treenode(int id, string name)
        {
            this.id = id;
            this.name = id.ToString();
        }

        public int id;
        public string name;
        public treenode left;
        public treenode right;
        public int lefttype = 0;//0 子树 1 前驱
        public int righttype = 0;//0 子树 1 后继

        public override string ToString()
        {
            Console.WriteLine("id={0} name={1}", id, name);
            return base.ToString();
        }
    }

    public class InfixThreadedBinaryTree
    {
        treenode root;
        treenode pre = null;

        public InfixThreadedBinaryTree(treenode root)
        {
            this.root = root;
        }

        public void ThreadNode()
        {
            ThreadNode(root);
        }

        public void ThreadNode(treenode node)
        {
            if (node == null) return;

            ThreadNode(node.left);

            if (node.left == null)
            {
                node.left = pre;
                node.lefttype = 1;                
            }

            if (pre != null && pre.right == null)
            {
                pre.right = node;
                pre.righttype = 1;
            }
            pre = node;
            ThreadNode(node.right);           
        }


        public void ThreadedList()
        {
            treenode node = root;

            while (node != null)
            {
                while (node?.lefttype == 0)
                {
                    node = node.left;
                }               

                Console.WriteLine(node.id);

                while (node.righttype == 1)
                {
                    node = node.right;
                    Console.WriteLine(node.id);
                }

                node = node.right;
            }
        }
    }
}
