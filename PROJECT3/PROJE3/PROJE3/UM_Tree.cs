using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PROJE3
{
    internal class TreeNode
    {
        public TreeNode leftChild;
        public TreeNode rightChild;
        public UM_Alani data;
        public TreeNode(UM_Alani data)
        {
            this.data = data;
        }

        public void PrintNode()
        {
            string words = string.Join(" ", data.info);
            Console.WriteLine("Alan adı: " + data.alanAdi + "\nÖn Bilgi:\n" + words);
            Console.WriteLine();
        }
    }
    internal class UM_Tree
    {
        
        private TreeNode root;
        public UM_Tree()
        { 
            root = null;
        }
        public TreeNode getRoot()
        { 
            return root;
        }

        public void Insert(UM_Alani newData)
        {
            TreeNode newNode = new TreeNode(newData);
            if (root == null)
            {
                root = newNode;
                return;
            }
            else
            {
                TreeNode current = root;
                TreeNode parent;

                while (true)
                {
                    parent = current;
                    if (string.Compare(newData.alanAdi, current.data.alanAdi) < 0)
                    {
                        current = current.leftChild;
                        if (current == null)
                        {
                            parent.leftChild = newNode;
                            return;
                        }
                    }
                    else
                    {
                        current = current.rightChild;
                        if (current == null)
                        {
                            parent.rightChild = newNode;
                            return;
                        }
                    }
                }
            }
        }

        public int CountNodes()
        {
            return CountNodesRecursive(root);
        }

        private int CountNodesRecursive(TreeNode node)
        {
            if (node == null)
                return 0;

            return CountNodesRecursive(node.leftChild) + CountNodesRecursive(node.rightChild) + 1;
        }

        public int FindDepth()
        {
            return FindDepthRecursive(root) - 1;
        }

        private int FindDepthRecursive(TreeNode node)
        {
            if (node == null)
                return 0;

            int leftHeight = FindDepthRecursive(node.leftChild);
            int rightHeight = FindDepthRecursive(node.rightChild);

            return Math.Max(leftHeight, rightHeight) + 1; //Max method compare two parameters and return which is higher between two.
        }

        public int BalancedTreeDepth()
        {
            return PBalancedTreeDepth(CountNodes());
        }

        private int PBalancedTreeDepth(int n)
        {
            return (int)Math.Log(n,2);
        }

        public void ListInOrder(TreeNode root, List<UM_Alani> uMList) // make List from tree
        {
            if (root == null)
            {
                return;
            }
            ListInOrder(root.leftChild, uMList);
            uMList.Add(root.data);
            ListInOrder(root.rightChild, uMList);
        }

        public void PrintUMBetweenChars(string startChar, string endChar)
        {
            PrintUMBetweenCharsRecursive(root, startChar, endChar);
        }

        private void PrintUMBetweenCharsRecursive(TreeNode node, string startChar, string endChar)
        {
            if (node != null)
            {
                if (string.Compare(node.data.alanAdi.Substring(0,1), startChar, StringComparison.CurrentCulture) >= 0
                    && string.Compare(node.data.alanAdi.Substring(0, 1), endChar, StringComparison.CurrentCulture) <= 0)// control letters
                {
                    node.PrintNode();
                    Console.WriteLine();
                }

                if (string.Compare(node.data.alanAdi.Substring(0, 1), startChar, StringComparison.CurrentCulture) >= 0)
                {
                    PrintUMBetweenCharsRecursive(node.leftChild, startChar, endChar);
                }

                if (string.Compare(node.data.alanAdi.Substring(0, 1), endChar, StringComparison.CurrentCulture) <= 0)
                {
                    PrintUMBetweenCharsRecursive(node.rightChild, startChar, endChar);
                }
            }
        }

        public TreeNode BuildBalancedTree(List<UM_Alani> umList)
        {
            if (umList == null || umList.Count == 0)
            {
                return null;
            }
            return BuildBalancedTreeRecursive(0, umList.Count - 1, umList);
        }

        private TreeNode BuildBalancedTreeRecursive(int start, int end, List<UM_Alani> umList)
        {
            if (start > end)
            {
                return null;
            }

            int middle = (start + end) / 2;
            TreeNode root = new TreeNode(umList[middle]);

            root.leftChild = BuildBalancedTreeRecursive(start, middle - 1, umList);
            root.rightChild = BuildBalancedTreeRecursive(middle + 1, end, umList);

            return root;
        }
        public void PreOrder(TreeNode root)
        {
            if (root == null)
            {
                return;
            }
            root.PrintNode();
            PreOrder(root.leftChild);
            PreOrder(root.rightChild);
        }
        public void PreOrder(TreeNode root, bool isBasicInfo) // sadece alan adı yazdırmak için..
        {
            if (root == null)
            {
                return;
            }
            if (isBasicInfo) { Console.WriteLine("Alan adı: " + root.data.alanAdi); }
            PreOrder(root.leftChild, true);
            PreOrder(root.rightChild, true);
        }
        public void InOrder(TreeNode root)
        {
            if (root == null)
            {
                return;
            }
            InOrder(root.leftChild);
            root.PrintNode();
            InOrder(root.rightChild);
        }

        public void PostOrder(TreeNode root)
        {
            if (root == null)
            {
                return;
            }
            PostOrder(root.leftChild);
            PostOrder(root.rightChild);
            root.PrintNode();
        }

    }
}
