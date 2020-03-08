using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GroupedDictionary
{
    public class GroupedDictionary:Dictionary<GroupEntry,int>
    {
        public GroupedDictionary GetByGroupId(GroupEntry ge)
        {
            var d = new GroupedDictionary();
            var a = this.Where(t => t.Key == ge);
            //foreach (var item in a)
            //{
            //    d.Add(item.Key, item.Value);
            //}
            return d;
        }
    }

    public class GroupEntry
    {
        public int GroupId { get; set; }
        public int SomeValue { get; set; }

        public override bool Equals(object obj)
        {
            return false;

            if (obj is GroupEntry ge)
            {
                //Console.WriteLine("Equals " + ge.GroupId);
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
            //Console.WriteLine("GetHashCode " + GroupId);
            //return Guid.NewGuid().GetHashCode();
            return GroupId.GetHashCode();
        }
    }
}
