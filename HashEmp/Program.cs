using System;
using System.Collections.Generic;

namespace HashEmp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class HashEmp
    {
        const int maxlength = 10;
        LinkedListEmp[] a = new LinkedListEmp[maxlength];

        public void add(Emp e)
        {
            int i = e.GetHashCode() / maxlength;
            if (a[i] == null) a[i] = new LinkedListEmp();
            a[i].add(e);
        }

        public void show()
        {

        }

        public void del(string id)
        {

        }
    }

    public class LinkedListEmp
    {
        Emp head;

        public void add(Emp e)
        {

        }
    }

    public class Emp
    {
        public string id;
        public string name;
        Emp next;
        public override int GetHashCode()
        {
            return id.GetHashCode();
        }

        public override string ToString()
        {
            return GetHashCode().ToString();
        }
    }
}
