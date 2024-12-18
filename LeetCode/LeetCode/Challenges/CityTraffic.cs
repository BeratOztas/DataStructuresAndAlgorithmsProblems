using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Globalization;

namespace LeetCode.Challenges.CoderByte.CityTraffic
{
    public class CityTraffic
    {
        Dictionary<int, LinkedList<int>> cityList = new Dictionary<int, LinkedList<int>>();

        public void PrintCities()
        {
            Console.WriteLine("-----CITIES-----");
            foreach (var i in cityList)
            {
                Console.Write(i.Key);
                Console.Write("--->" + string.Join(" ", i.Value));
                Console.WriteLine();
            }
        }

        public void AddVertex(int vertex)
        {
            cityList.Add(vertex, new LinkedList<int>());
        }

        public void AddEdge(int source, int destination)
        {
            cityList[source].AddFirst(destination);
        }

        public string cityTraffic(string[] strArr)
        {
            // Input :"1:[5]", "4:[5]", "3:[5]", "5:[1,4,3,2]", "2:[5,15,7]", "7:[2,8]", "8:[7,38]", "15:[2]", "38:[8]"
            // Example : 7:(2+15+1+3+4+5)=30, (38+8)=46 (30,46) =46.

            /*Your program should determine the maximum traffic for every single city and
            *return the answers in a comma separated string in the format:
            *city:max_traffic,city: max_traffic,... The cities should be outputted in
            *sorted order by the city number.For the above example, the output would
            *therefore be: 1:82,2:53,3:80,4:79,5:70,7:46,8:38,15:68,38:45.The cities will
            *all be unique positive integers and there will not be any cycles in the
            *graph. There will always be at least 2 cities in the graph.*/

            //Output :1:82,2:53,3:80,4:79,5:70,7:46,8:38,15:68,38:45
            /*Step 2: Calculate Traffic for Each City
            For each city, calculate the maximum traffic by considering all possible paths to that city.This involves summing the populations of all cities that can reach the current city through each of its neighbors.
            Step 3: Determine Maximum Traffic
            For each city, determine the maximum traffic value from the calculated traffic values for all paths leading to that city.*/
            foreach (string str in strArr)
            {
                string[] node = str.Replace("[", "").Replace("]", "").Split(":");
                int vertex = Convert.ToInt32(node[0]);
                AddVertex(vertex);
                string[] neighbors = node[1].Split(",");
                foreach (string neighbor in neighbors)
                {
                    AddEdge(Convert.ToInt32(node[0]), Convert.ToInt32(neighbor));
                }
            }
            PrintCities();

            Console.WriteLine();

            List<string> result = new List<string>();
            foreach(var i in cityList.OrderBy(x => x.Key))
            {
                result.Add(i.Key.ToString() + ":" + maxTrafficNode(i.Key).ToString());
            }
            Console.WriteLine("-----MaxTrafficCities-----");
            return string.Join(",",result);
        }

        public int maxTrafficNode(int vertex)
        {
            List<int> maxVertexList = new List<int>();

            foreach(int i in cityList.GetValueOrDefault(vertex,new LinkedList<int>()))
            {
                maxVertexList.Add(Bfs(i, vertex));
            }
            Console.Write("Vertex: "+vertex+" maxVertexList: "+string.Join(",",maxVertexList));
            Console.WriteLine();

            return maxVertexList.Max();

        }

        public int Bfs(int startVertex,int targetVertex)
        {
            Queue<int> queue = new Queue<int>();
            HashSet<int> visited = new HashSet<int>(cityList[targetVertex]);//Trick its here start set with target neighbors 

            queue.Enqueue(startVertex);
            visited.Add(startVertex);
            queue.Enqueue(targetVertex);
            visited.Add(targetVertex);

            int sum = startVertex;

            while (queue.Count > 0)
            {
                int currentVertex = queue.Dequeue();

                foreach (int neighbor in cityList.GetValueOrDefault(currentVertex, new LinkedList<int>()))
                {
                    if (!visited.Contains(neighbor))
                    {
                        sum += neighbor;
                        queue.Enqueue(neighbor);
                        visited.Add(neighbor);
                    }
                }
            }
            return sum;

        }


    }
}
