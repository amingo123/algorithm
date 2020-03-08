using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GroupedDictionary
{
    public class GroupedDictionary:Dictionary<GroupEntry,int>
    {
        public GroupedDictionary GetByGroupId(int GroupId)
        {
            var d = new GroupedDictionary();
            var a = this.Where(t => t.Key.GroupId == GroupId);
            foreach (var item in a)
            {
                d.Add(item.Key, item.Value);
            }
            return d;
        }
    }

    public class GroupEntry
    {
        public int GroupId { get; set; }
        public string SomeValue { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is GroupEntry ge)
            {
                Console.WriteLine(ge.GroupId);
                if (ge.GroupId == GroupId && ge.SomeValue == SomeValue)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            Console.WriteLine(GroupId);
            return GroupId.GetHashCode();
        }
    }
}
