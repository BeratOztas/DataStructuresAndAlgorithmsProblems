using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Challenges
{
    public class Graph
    {
        private int[,] adjMatrix;
        private int vertices;

        public Graph(int vertices)
        {
            this.vertices = vertices;
            adjMatrix = new int[vertices, vertices];
        }
        public void AddEdge(int i, int j)
        {
            adjMatrix[i - 1, j - 1] = 1;
            adjMatrix[j - 1, i - 1] = 1;
        }
        public void RemoveEdge(int i, int j)
        {
            adjMatrix[i - 1, j - 1] = 0;
            adjMatrix[j - 1, i - 1] = 0;
        } 
        public void AddVertex()
        {
            int[,] newAdjMatrix = new int[vertices + 1, vertices + 1];

            for (int i = 0; i < vertices; i++)
            {
                for (int j = 0; j < vertices; j++)
                {
                    newAdjMatrix[i, j] = adjMatrix[i, j];
                }
            }
            adjMatrix = newAdjMatrix;
            vertices++;
        }
        public void RemoveVertex(int v)
        {
            if (v > vertices)
            {
                Console.WriteLine("Vertex not present");
                return;
            }
            int[,] newAdjMatrix = new int[vertices - 1, vertices - 1];

            for (int i = 0; i < vertices; i++)
            {
                for (int j = 0; j < vertices; j++)
                {
                    if (i != v - 1 && j != v - 1)
                        newAdjMatrix[i, j] = adjMatrix[i, j];
                }
            }
            adjMatrix = newAdjMatrix;
            vertices--;
        }

        public void PrintMatrix()
        {
            Console.WriteLine("----ADJMATRIX----");
            for (int i = 0; i < adjMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < adjMatrix.GetLength(1); j++)
                {
                    Console.Write(adjMatrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

    }

    public class AdjacencyMatrix
    {

    }
}
