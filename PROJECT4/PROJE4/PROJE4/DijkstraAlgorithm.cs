using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJE4
{
    class DijkstraAlgorithm
    {

        public static void Dijkstra(int[,] graph, int startVertex)
        {
            int numVertices = graph.GetLength(0);
            int[] distance = new int[numVertices];
            bool[] shortestPathSet = new bool[numVertices];

            // Başlangıç noktasına uzaklıkları initialize et
            for (int i = 0; i < numVertices; i++)
            {
                distance[i] = int.MaxValue;
                shortestPathSet[i] = false;
            }

            // Başlangıç noktasının kendisine uzaklığını 0 olarak ayarla
            distance[startVertex] = 0;

            for (int count = 0; count < numVertices - 1; count++)
            {
                int u = MinDistance(distance, shortestPathSet);
                shortestPathSet[u] = true;

                for (int v = 0; v < numVertices; v++)
                {
                    if (!shortestPathSet[v] && graph[u, v] > 0 && distance[u] != int.MaxValue &&
                        distance[u] + graph[u, v] < distance[v])
                    {
                        distance[v] = distance[u] + graph[u, v];
                    }
                }
            }

            PrintSolution(distance);
        }

        public static int MinDistance(int[] distance, bool[] shortestPathSet)
        {
            int min = int.MaxValue;
            int minIndex = -1;

            for (int v = 0; v < distance.Length; v++)
            {
                if (!shortestPathSet[v] && distance[v] <= min)
                {
                    min = distance[v];
                    minIndex = v;
                }
            }

            return minIndex;
        }

        public static void PrintSolution(int[] distance)
        {
            Console.WriteLine("En kısa mesafeler:");
            for (int i = 0; i < distance.Length; i++)
            {
                Console.WriteLine($"0 --> {i}: {distance[i]} birim");
            }
        }
    }
}
