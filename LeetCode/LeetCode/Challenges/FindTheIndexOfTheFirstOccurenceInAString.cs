using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Challenges
{
    public class FindTheIndexOfTheFirstOccurenceInAString
    {
        public int StrStr(string haystack,string needle)
        {
            int index = haystack.IndexOf(needle);
            return index;
        }
    }
}
