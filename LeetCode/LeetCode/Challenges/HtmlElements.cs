using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LeetCode.Challenges
{
    public class HtmlElements
    {
        public string HtmlElement(string strParam)
        {
            //Input :str :"<div><b><p>hello world</p></b></div>"
            //Output :true
            //Input :str :"<div>abc</div><p><em><i>test test test</b></em></p>"
            //Output : i
            Stack<string> stack = new Stack<string>();
            string[] open_tags = { "<b>", "<i>", "<em>", "<div>", "<p>" };
            string[] close_tags = { "</b>", "</i>", "</em>", "</div>", "</p>" };
            string[] tags = Regex.Split(strParam, "(<[^>]*>)");
            foreach (string tag in tags)
                Console.WriteLine($"{tag}");

            foreach(string tag in tags)
            {
                if (open_tags.Contains(tag))
                {
                    
                    stack.Push(tag);
                }
                else if(close_tags.Contains(tag))
                {
                    int check=Array.IndexOf(close_tags,tag);
                    if (stack.Count >0 && (open_tags[check]==stack.Peek()))
                    {
                        stack.Pop();
                    }
                }
            }
            if (stack.Count > 0)
                return stack.Pop().Replace("<", "").Replace(">", "");
            else
                return "true";


        }

    }
}
