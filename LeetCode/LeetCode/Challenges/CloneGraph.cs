using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Challenges.CloneGraphs;

public class Node
{
    public int val;
    public IList<Node> neighbors;

    public Node()
    {
        val = 0;
        neighbors=new List<Node>();
    }

    public Node(int val)
    {
        this.val = val;
        neighbors = new List<Node>();
    }

    public Node(int val, List<Node> neighbors)
    {
        this.val = val;
        this.neighbors = neighbors;
    }

}
public class CloneGraph
{
    public Node Clone(Node node)
    {
        if (node == null)
            return null;

        Dictionary<Node, Node> dict = new Dictionary<Node, Node>(); //[1:1] ,[2:2], [3:3] ,[4:4] ,[5:5]

        Queue<Node> queue =new Queue<Node>();
        queue.Enqueue(node);
        dict.Add(node, new Node(node.val)); //Gelen node'un kopyasını value olarak oluştur.


        while(queue.Count > 0)  //BFS
        {
            Node currentVertex =queue.Dequeue();

            foreach(Node neighbor in currentVertex.neighbors)
            {
                if (!dict.ContainsKey(neighbor))
                {
                    dict.Add(neighbor, new Node(neighbor.val));
                    queue.Enqueue(neighbor);
                }
                dict[currentVertex].neighbors.Add(dict[neighbor]);
            }

        }

        return dict[node];

    }
    
}
