using System;
using System.Collections.Generic;
using System.Linq;

namespace Greedy
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, HashSet<string>> dict = new Dictionary<string, HashSet<string>>()
            {
                { "k1", new HashSet<string>(){ "北京","上海","天津"} },
                { "k2", new HashSet<string>(){ "北京","广州","深圳"} },
                { "k3", new HashSet<string>(){ "成都","上海","杭州"} },
                { "k4", new HashSet<string>(){ "上海","天津"} },
                { "k5", new HashSet<string>(){ "杭州", "大连"} }
            };

            List<string> allArea = new List<string>()
            {
                "北京","上海","天津","广州","成都","杭州","深圳","大连"
            };
            List<string> temp = new List<string>();

            List<string> keys = new List<string>();
            while (allArea.Count > 0)
            {
                int count = 0;
                string key = string.Empty;
                HashSet<string> value = new HashSet<string>();
                foreach (var item in dict)
                {
                    if (allArea.Intersect(item.Value).Count() > count)
                    {
                        key = item.Key;
                        value = item.Value;
                        count = allArea.Intersect(value).Count();
                    }
                }
                keys.Add(key);
                dict.Remove(key);
                allArea = allArea.Except(value).ToList();
            }

            Console.WriteLine(string.Join(',',keys.ToArray()));
            Console.Read();
        }
    }
}
