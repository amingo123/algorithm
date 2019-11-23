using System;
using System.Collections.Generic;
using System.Text;

namespace HuffmanTree
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 13, 7, 8, 3, 9, 6, 1 };
            Node n = HuffmanTree.CreateHuffmanTree(a);
            //n.PreOrder();

            string s = "i like like like java do you like a java";            
            byte[] b = System.Text.Encoding.Default.GetBytes(s);
            List<Node> nodes = HuffmanTree.GetDataCount(b);
            Node m = HuffmanTree.CreateHuffmanTree(nodes);
            //m.PreOrder();
            Dictionary<byte?, string> codes = HuffmanTree.CreateHuffmanCodes(m);
            byte[] b1 = HuffmanTree.ZipStringByHuffmanCodes(s,codes);
            string b2 = HuffmanTree.UnZipStringByHuffmanCodes(b1, codes);
            Console.Read();
        }       
    }

    class HuffmanTree
    {
        public static Node CreateHuffmanTree(int[] a)
        {
            // convert a to Node List
            List<Node> l = new List<Node>();
            for (int i = 0; i < a.Length; i++)
            {
                l.Add(new Node(a[i]));
            }

            while (l.Count > 1)
            {
                l.Sort();
                Node left = l[0];
                Node right = l[1];

                Node newnode = new Node(left.count + right.count);
                newnode.left = left;
                newnode.right = right;
                l.Remove(left);
                l.Remove(right);
                l.Add(newnode);
            }
            return l[0];
        }

        public static Node CreateHuffmanTree(List<Node> l)
        {
            while (l.Count > 1)
            {
                l.Sort();
                Node left = l[0];
                Node right = l[1];

                Node newnode = new Node(left.count + right.count);
                newnode.left = left;
                newnode.right = right;
                l.Remove(left);
                l.Remove(right);
                l.Add(newnode);
            }
            return l[0];
        }

        public static List<Node> GetDataCount(byte[] b)
        {
            List<Node> nodes = new List<Node>();
            Dictionary<byte, int> dict = new Dictionary<byte, int>();
            foreach (var item in b)
            {
                if (dict.ContainsKey(item))
                {
                    int c = dict[item] + 1;
                    dict.Remove(item);
                    dict.Add(item, c);
                }
                else
                {
                    dict.Add(item, 1);
                }
            }
            foreach (var item in dict)
            {
                nodes.Add(new Node(item.Value, item.Key));
            }
            return nodes;
        }

        public static Dictionary<byte?, string> CreateHuffmanCodes(Node node)
        {
            return CreateHuffmanCodes(node, string.Empty);
        }

        public static byte[] ZipStringByHuffmanCodes(string s , Dictionary<byte?, string> codes)
        {
            byte[] b = Encoding.Default.GetBytes(s);
            StringBuilder sb = new StringBuilder();
            foreach (var item in b)
            {
                sb.Append(codes[item]);
            }
            int len;
            if (sb.Length % 8 == 0)
            {
                len = sb.Length / 8;
            }
            else
            {
                len = sb.Length / 8 + 1;
            }
            byte[] huffmancodesbyte = new byte[len];
            int index = 0;
            string sbStr = sb.ToString();
            for (int i = 0; i < sbStr.Length; i+=8)
            {
                string str;
                if (i + 8 > sbStr.Length)
                {
                    str = sbStr.Substring(i);
                }
                else
                {
                    str = sbStr.Substring(i, 8);
                }
                huffmancodesbyte[index] = (byte)Convert.ToInt32(str, 2);
                index++;
            }
            return huffmancodesbyte;
        }

        public static string UnZipStringByHuffmanCodes(byte[] b, Dictionary<byte?, string> codes)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < b.Length; i++)
            {
                string s = string.Empty;
                if (i == b.Length - 1)
                {
                    s = ByteToString(true, b[i]);
                }
                else
                {
                    s = ByteToString(false, b[i]);
                }
                sb.Append(s);
            }

            Dictionary<string,byte> map = new Dictionary<string,byte>();
            foreach (var item in codes)
            {
                map.Add(item.Value, item.Key.Value);
            }

            List<byte> list = new List<byte>();
            string sbStr = sb.ToString();//sb 有错误
            //sbStr = "1000111101001111000011110100111100001111010011110000111011101001010101110000011011100100111101001111010011110000110101110111010010101";
            for (int i = 0; i < sbStr.Length;)
            {
                int count = 1;
                bool flag = true;
                byte? by = null;
                while (flag)
                {
                    string key = sbStr.Substring(i, count);
                    
                    if (!map.ContainsKey(key))
                    {
                        count++;
                    }
                    else
                    {
                        by = map[key];
                        flag = false;
                    }
                }
                list.Add(by.Value);
                i += count;
            }
            byte[] result = new byte[list.Count];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = list[i];
            }
            return Encoding.UTF8.GetString(result); ;
        }

        private static string ByteToString(bool flag,byte b)
        {
            int temp = b;
            string str = string.Empty;
            if (flag)
            {
                temp |= 256;                
            }
            str = Convert.ToString(temp, 2);
            if (flag)
            {
                return str.Substring(str.Length - 8);
            }
            else
            {
                return str;
            }
        }

        public static Dictionary<byte?, string> CreateHuffmanCodes(Node node,string NodePath,StringBuilder currentString =null)
        {
            StringBuilder temp = (currentString == null) ? new StringBuilder() : new StringBuilder(currentString.ToString());
            temp.Append(NodePath);
            if (node != null)
            {
                if (node.b == null)
                {
                    CreateHuffmanCodes(node.left, "0", temp);
                    CreateHuffmanCodes(node.right, "1", temp);
                }
                else
                {
                    HuffmanCodes.Add(node.b, temp.ToString());
                }
            }
            return HuffmanCodes;
        }
        private static Dictionary<byte?, string> HuffmanCodes = new Dictionary<byte?, string>();
    }

    class Node : IComparable<Node>
    {
        public int count;
        public byte? b;
        public Node left;
        public Node right;

        public Node(int count,byte? b = null)
        {
            this.count = count;
            this.b = b;
        }

        public int CompareTo(Node obj)
        {
            return count - obj.count;
        }

        public override string ToString()
        {
            Console.WriteLine(count);
            return base.ToString();
        }

        public void PreOrder()
        {
            Console.WriteLine("{1}-{0}",count,b);
            if (left != null) left.PreOrder();
            if (right != null) right.PreOrder();
        }
    }
}
