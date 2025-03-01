using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJE4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //AVLDemo();
            //DijkstraDemo();
            //PrimDemo();
            //TraversalDemo();
            TrieDemo();
            Console.ReadLine();
        }

        private static void TrieDemo()
        {
            Trie trie = new Trie();
            
            trie.Insert("istanbul");
            trie.Insert("izmir");
            trie.Insert("mugla");
            trie.Insert("mersin");
            trie.Insert("antalya");
            trie.PrintTrie();
            Console.ReadLine();
        }
        private static void TraversalDemo()
        {
            int[,] graph = {
            {0, 1, 1, 0, 0},
            {1, 0, 0, 1, 1},
            {1, 0, 0, 0, 1},
            {0, 1, 0, 0, 1},
            {0, 1, 1, 1, 0}
        };
            Console.WriteLine("BFS starting from vertex 0:");
            TraverseAlgorithm.BreadthFirstSearch(graph, 0);
            Console.WriteLine();

            int vertices = graph.GetLength(0);
            bool[] visited = new bool[vertices];

            Console.WriteLine("DFS starting from vertex 0:");
            TraverseAlgorithm.DepthFirstSearch(graph, 0, visited);
        }
        private static void PrimDemo()
        {
            PrimMST prim = new PrimMST();

            int[,] graph = {
            {0, 0, 0, 0, 3},
            {0, 0, 4, 6, 4},
            {0, 4, 5, 0, 0},
            {0, 6, 5, 0, 2},
            {3, 4, 0, 2, 0}
        };

            prim.PrimAlgorithm(graph);
        }
        private static void DijkstraDemo()
        {
            
            int[,] directedWeightedMatrix = {
            {0, 3, 0, 2, 0},
            {0, 0, 1, 3, 5},
            {0, 0, 0, 0, 2},
            {0, 0, 0, 0, 3},
            {0, 0, 0, 0, 0}
        };

            DijkstraAlgorithm.Dijkstra(directedWeightedMatrix, 0);

        }
        private static void AVLDemo()
        {
            AVLTree avlTree = new AVLTree();
            avlTree.Insert(10);
            avlTree.Insert(20);
            avlTree.Insert(35);
            Console.WriteLine("after 10 20 35 inserted: ");
            avlTree.PrintPreorder();

            avlTree.Insert(23);
            avlTree.Insert(50);
            avlTree.Insert(29);
            avlTree.Insert(3);

            Console.WriteLine("Preorder traversal of AVL tree(all numbers are inserted):");
            avlTree.PrintPreorder();
        }
    }
}
