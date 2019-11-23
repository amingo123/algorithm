using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TwoWayLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            TwoWayLinkedList twoWayLinkedList = new TwoWayLinkedList();            
            Node2 n1 = new Node2(1, "1");
            Node2 n2 = new Node2(2, "2");
            Node2 n3 = new Node2(3, "3");
            Node2 n4 = new Node2(4, "4");
            Node2 n5 = new Node2(5, "5");
            Node2 n14 = new Node2(1, "14");
            twoWayLinkedList.Add(n1);
            twoWayLinkedList.Add(n3);
            twoWayLinkedList.Add(n2);
            twoWayLinkedList.Add(n5);
            twoWayLinkedList.Add(n4);
            twoWayLinkedList.ToString();
            twoWayLinkedList.Update(n14);
            twoWayLinkedList.ToString();

            twoWayLinkedList.Delete(3);
            twoWayLinkedList.ToString();
            Console.Read();
        }
    }

    public class TwoWayLinkedList
    {
        private Node2 head;

        public void Add(Node2 node)
        {
            if (head == null)
            {
                head = node;
            }
            else
            {
                Node2 temp = head;
                while (temp != null)
                {
                    if (temp.next == null)
                    {
                        temp.next = node;
                        node.pre = temp;
                        break;
                    }
                    temp = temp.next;
                }
            }
        }

        public void Update(Node2 node)
        {
            Node2 temp = head;
            bool flag = false;
            while (temp != null)
            {
                if (temp.no == node.no)
                {
                    temp.data = node.data;
                    flag = true;
                    break;
                }
                temp = temp.next;
            }

            if (!flag)
            {
                Console.WriteLine("nothing to update!");
                ToString();
            }
        }

        public void Delete(int no)
        {
            Node2 temp = head;
            bool flag = false;
            while (temp != null)
            {
                if (temp.no == no)
                {
                    flag = true;
                    break;
                }
                temp = temp.next;
            }

            if (!flag)
            {
                Console.WriteLine("nothing to delete!");
                ToString();
            }
            else
            {
                temp.pre.next = temp.next;
                if (temp.next != null)
                {
                    temp.next.pre = temp.pre;
                }
            }
        }

        public override string ToString()
        {
            if (head == null)
            {
                Console.WriteLine("blank list");
            }
            else
            {
                Node2 temp = head;
                while (temp != null)
                {
                    temp.ToString();                    
                    temp = temp.next;
                }
            }
            Console.WriteLine("");
            return base.ToString();
        }

    }

    public class Node2
    {
        public Node2 pre;
        public Node2 next;
        public string data;
        public int no;

        public Node2(int no, string data)
        {
            this.no = no;
            this.data = data;
        }

        public override string ToString()
        {
            Console.WriteLine("no=" + no.ToString() + " data=" + data);            
            return base.ToString();
        }
    }
}