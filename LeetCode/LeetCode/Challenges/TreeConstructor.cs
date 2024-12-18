using LeetCode.Challenges.BinaryTree;

namespace LeetCode.Challenges.TreeConstructors
{
    public class TreeConstructor
    {
        public string IsBinaryTree(string[] strArr)
        { /*
           Input: new string[] {"(1,2)", "(2,4)", "(5,7)", "(7,2)", "(9,5)"}
           Output: true
            Input: new string[] {"(1,2)", "(3,2)", "(2,12)", "(5,2)"}
            Output: false
            */
            /*
        1.Parents must have at most 2 children. parents={parents[child1,child2]};
        2.Children must have at most 1 parent. children ={child,parent};
        3.Itarate  through strArr to see if conditions remain true     
           */
            Dictionary<string,int> parents =new Dictionary<string,int>();
            Dictionary<string,int> childs = new Dictionary<string,int>();
            
            
            foreach (string item in strArr) {
                string[] str = item.Replace("(", "").Replace(")", "").Split(",");
                string child = str[0];
                string parent = str[1];

                if(parents.ContainsKey(parent))
                {
                    parents[parent]++;
                    if (parents[parent] > 2)
                        return "false";
                }
                else
                {
                    parents.Add(parent, 1);
                }
                if (childs.ContainsKey(child))
                    return "false";
                else
                    childs.Add(child, 1);  

            }
            return "true";
        }
    }
}
