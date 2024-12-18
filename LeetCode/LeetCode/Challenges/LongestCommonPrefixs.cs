using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Challenges.LongestCommonPrefix;

public class LongestCommonPrefixs
{
    public string LongestCommonPrefix(string[] strs)
    {
        StringBuilder stringBuilder = new StringBuilder();
        Array.Sort(strs);

        char[] first = strs[0].ToCharArray();
        char[] last = strs[strs.Length - 1].ToCharArray();

        for(int i = 0; i < first.Length; i++)
        {
            if (first[i] == last[i])
                stringBuilder.Append(first[i]);
            else
                break;
        }
        return stringBuilder.ToString();

    }
}

