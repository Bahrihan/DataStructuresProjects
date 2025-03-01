using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJE4
{
    class PrimMST
    {
        static int V = 5;

        public int MinKey(int[] key, bool[] mstSet)
        {
            int min = int.MaxValue, minIndex = -1;

            for (int v = 0; v < V; v++)
            {
                if (mstSet[v] == false && key[v] < min)
                {
                    min = key[v];
                    minIndex = v;
                }
            }

            return minIndex;
        }

        public void PrintMST(int[] parent, int[,] graph)
        {
            Console.WriteLine("Minimum Spanning Tree:");
            for (int i = 1; i < V; i++)
            {
                Console.WriteLine($"Edge: {parent[i]} - {i}, Weight: {graph[i, parent[i]]}");
            }
        }

        public void PrimAlgorithm(int[,] graph)
        {
            int[] parent = new int[V];
            int[] key = new int[V];
            bool[] mstSet = new bool[V];

            for (int i = 0; i < V; i++)
            {
                key[i] = int.MaxValue;
                mstSet[i] = false;
            }

            key[0] = 0;
            parent[0] = -1;

            for (int count = 0; count < V - 1; count++)
            {
                int u = MinKey(key, mstSet);
                mstSet[u] = true;

                for (int v = 0; v < V; v++)
                {
                    if (graph[u, v] != 0 && mstSet[v] == false && graph[u, v] < key[v])
                    {
                        parent[v] = u;
                        key[v] = graph[u, v];
                    }
                }
            }

            PrintMST(parent, graph);
        }
    }
}
