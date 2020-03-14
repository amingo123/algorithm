using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

public class MyObject
{
    public int Key { get; set; }
    public int Value { get; set; }
}


public class SegmentTree
{
    // array size 
    readonly int n; 
    // limit for array size 
    readonly int N;
    // Max size of tree 
    readonly long[] tree;
    readonly List<MyObject> list;

    public SegmentTree(List<MyObject> list)
    {
        n = list.Count;
        N = 2 * n;
        tree = new long[N];
        this.list = list;
    }

    // function to build the tree 
    public void Build()
    {
        // insert leaf nodes in tree 
        for (int i = 0; i < n; i++)
        {
            tree[n + i] = list[i].Value;
        }

        // build the tree by calculating 
        // parents 
        for (int i = n - 1; i > 0; --i)
        {
            tree[i] = tree[i << 1] + tree[i << 1 | 1];
        }
    }

    // function to update a tree node 
    public void UpdateTreeNode(int p, MyObject myobj)
    {
        // set value at position p 
        tree[p + n] = myobj.Value;
        p += n;

        // move upward and update parents 
        for (int i = p; i > 1; i >>= 1)
        {
            tree[i >> 1] = tree[i] + tree[i ^ 1];
        }
    }

    // function to get sum on 
    // interval [l, r) 
    public long Query(int l, int r)
    {
        long res = 0;
        // loop to find the sum in the range 
        for (l += n, r += n; l < r; l >>= 1, r >>= 1)
        {
            if ((l & 1) > 0)
                res += tree[l++];

            if ((r & 1) > 0)
                res += tree[--r];
        }
        return res;
    }    
}

public class _test
{
    // driver program to test the 
    // above function  
    static public void Main()
    {
        List<MyObject> list = new List<MyObject>();
        int n = 99000000;
        for (int i = 0; i < n; i++)
        {
            list.Add(new MyObject() { Value = i, Key = i });
        }

        SegmentTree st = new SegmentTree(list);
        Stopwatch sw = new Stopwatch();
        sw.Start();
        st.Build();
        sw.Stop();        
        Console.WriteLine($"Build {sw.ElapsedMilliseconds}");

        // print the sum in range(1,2) 
        // index-based 
        int start = n/1321;
        int end = n/5;
        if (start > n || end > n || start > end)
        {
            Console.WriteLine("exception"); return;
        }
        sw.Reset();
        sw.Start();
        DateTime t1 = DateTime.Now;
        var sum = st.Query(start, end);
        DateTime t2 = DateTime.Now;
        sw.Stop();
        Console.WriteLine($"Query {sw.ElapsedMilliseconds} Reuslt:{sum}");
        Console.WriteLine($"Query {(t2.Ticks - t1.Ticks) / 100}ns Reuslt:{sum}");

        sum = 0;
        sw.Reset();
        sw.Start();
        t1 = DateTime.Now;
        for (int i = start; i < end; i++)
        {
            sum += list[i].Value;
        }
        t2 = DateTime.Now;
        sw.Stop();
        Console.WriteLine($"for {sw.ElapsedMilliseconds} Reuslt:{sum}");
        Console.WriteLine($"for {(t2.Ticks - t1.Ticks) / 100}ns Reuslt:{sum}");

        sw.Reset();
        sw.Start();
        // modify element
        st.UpdateTreeNode(4555555, new MyObject() {  Key = 77,Value = 77 });
        sw.Stop();
        Console.WriteLine($"UpdateTreeNode {sw.ElapsedMilliseconds}");
    }
}
