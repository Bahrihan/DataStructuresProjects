using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJE4
{
    public class TrieNode
    {
        public TrieNode[] Children { get; set; }
        public bool IsEndOfWord { get; set; }

        public TrieNode()
        {
            Children = new TrieNode[26]; // 26 harf için
            IsEndOfWord = false;
        }
    }
    internal class Trie
    {
        private TrieNode root;

        public Trie()
        {
            root = new TrieNode();
        }

        private int GetIndex(char c)
        {
            return c - 'a'; // Küçük harfler için
        }
        public void Insert(string word)
        {
            TrieNode node = root;

            foreach (char c in word)
            {
                int index = GetIndex(c);

                if (node.Children[index] == null)
                {
                    node.Children[index] = new TrieNode();
                }

                node = node.Children[index];
            }

            node.IsEndOfWord = true;
        }

        public void PrintTrie()
        {
            PrintTrie(root, "");
        }

        private void PrintTrie(TrieNode node, string currentWord)
        {
            if (node.IsEndOfWord)
            {
                Console.WriteLine(currentWord);
            }

            for (int i = 0; i < 26; i++)
            {
                if (node.Children[i] != null)
                {
                    char ch = (char)('a' + i);
                    PrintTrie(node.Children[i], currentWord + ch);
                }
            }
        }
    }
}
