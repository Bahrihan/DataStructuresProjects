using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJE4
{
    internal class TraverseAlgorithm
    {
        public static void BreadthFirstSearch(int[,] graph, int startVertex)
        {
            int vertices = graph.GetLength(0);
            bool[] visited = new bool[vertices];

            Queue<int> queue = new Queue<int>();
            visited[startVertex] = true;
            queue.Enqueue(startVertex);

            while (queue.Count != 0)
            {
                startVertex = queue.Dequeue();
                Console.Write($"{startVertex} ");

                for (int i = 0; i < vertices; i++)
                {
                    if (graph[startVertex, i] != 0 && !visited[i])
                    {
                        visited[i] = true;
                        queue.Enqueue(i);
                    }
                }
            }
        }

        public static void DepthFirstSearch(int[,] graph, int startVertex, bool[] visited)
        {
            Console.Write($"{startVertex} ");
            visited[startVertex] = true;

            for (int i = 0; i < graph.GetLength(0); i++)
            {
                if (graph[startVertex, i] != 0 && !visited[i])
                {
                    DepthFirstSearch(graph, i, visited);
                }
            }
        }
    }
}
