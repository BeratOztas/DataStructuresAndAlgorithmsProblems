using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Challenges
{
    public class AdjacencyListGraph
    {
        Dictionary<int, LinkedList<int>> adjancencyList;

        public AdjacencyListGraph()
        {
            this.adjancencyList = new Dictionary<int, LinkedList<int>>();
        }

        public void PrintListGraph()
        {
            Console.WriteLine("------ADJANCENCYLISTGRAPH------");
            foreach (var i in adjancencyList)
            {
                Console.Write(i.Key);
                Console.Write("-->" + string.Join(" ", i.Value));
                Console.WriteLine();
            }
        }

        public void AddVertex(int vertex)
        {
            adjancencyList.Add(vertex, new LinkedList<int>());
        }
        public void RemoveVertex(int vertex)
        {
            if (!adjancencyList.ContainsKey(vertex))
            {
                Console.WriteLine("Vertex Does not exist");
                return;
            }
            adjancencyList.Remove(vertex);

            foreach (LinkedList<int> neighbors in adjancencyList.Values)
            {
                neighbors.Remove(vertex);
            }
        }

        public void AddEdge(int source, int destination)
        {
            adjancencyList[source].AddFirst(destination);
            adjancencyList[destination].AddFirst(source);
        }
        public void RemoveEdge(int source, int destination)
        {
            adjancencyList[source].Remove(destination);
            adjancencyList[destination].Remove(source);
        }

        public void BFSIterative(int startVertex)
        {
            Queue<int> queue = new Queue<int>();
            HashSet<int> visited = new HashSet<int>();

            queue.Enqueue(startVertex);
            visited.Add(startVertex);
            while (queue.Count > 0)
            {
                int currentVertex = queue.Dequeue();
                Console.Write(currentVertex + " ");

                foreach (int neighbor in adjancencyList.GetValueOrDefault(currentVertex, new LinkedList<int>()))
                {
                    if (!visited.Contains(neighbor))
                    {
                        queue.Enqueue(neighbor);
                        visited.Add(neighbor);
                    }
                }
            }

        }

        public void DFSIterative(int startVertex)
        {
            HashSet<int> visited = new HashSet<int>();
            Stack<int> stack = new Stack<int>();

            stack.Push(startVertex);
            visited.Add(startVertex);

            while (stack.Count > 0)
            {
                int currentVertex = stack.Pop();
                
                Console.Write(currentVertex + " ");
                

                foreach (int neighbor in adjancencyList.GetValueOrDefault(currentVertex, new LinkedList<int>()))
                {
                    if (!visited.Contains(neighbor))
                    {
                        stack.Push(neighbor);
                        visited.Add(neighbor) ;
                    }
                }
            }
            //foreach(int i in visited)Console.Write(i+" ");
        }

        public void DFS(int startVertex)
        {
            HashSet<int> visited = new HashSet<int>();
            DFSRecursive(startVertex, visited);
        }

        private void DFSRecursive(int startVertex, HashSet<int> visited)
        {
            Console.Write(startVertex + " ");
            visited.Add(startVertex);

            foreach (int neighbor in adjancencyList.GetValueOrDefault(startVertex, new LinkedList<int>()))
            {
                if (!visited.Contains(neighbor))
                    DFSRecursive(neighbor, visited);
            }
        }
    }
}
