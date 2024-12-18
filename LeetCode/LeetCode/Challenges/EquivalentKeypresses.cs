using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Challenges.EquiavalentKey
{
    public class EquivalentKeypresses
    {
        public string EquivalentKey(string[] strArr)
        {
            /*
             Input :["a,b,c,d","a,b,c,d,-B,d"]
             Output :true
             Input :["c,a,r,d","c,a,-B,r,d"]
             Output :false
             */
            string first = "";
            string second = "";
            string[] str = strArr[0].Split(",");
            string[] str1 = strArr[1].Split(",");
            Stack<string> firstString = new Stack<string>();
            Stack<string> secondString = new Stack<string>();

            foreach(string i in str)
            {
                if (i == "-B")
                    firstString.Pop();
                else
                    firstString.Push(i);
            }
            foreach(string i in str1)
            {
                if (i == "-B")
                    secondString.Pop();
                else
                    secondString.Push(i);
            }
            while (firstString.Count > 0)
                first += firstString.Pop();
            while (secondString.Count > 0)
                second += secondString.Pop();

            if (first.Equals(second))
                return "True";
            else 
                return "False";
   
            
        }
    }
}
