using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJE4
{
    class AVLNode
    {
        public int Data;
        public int Height;
        public AVLNode Left, Right;

        public AVLNode(int data)
        {
            Data = data;
            Height = 1;
            Left = Right = null;
        }
    }

    class AVLTree
    {
        AVLNode root;

        // Ağacın yüksekliğini döndür
        int Height(AVLNode node)
        {
            if (node == null)
                return 0;
            return node.Height;
        }

        // Yükseklik farkını hesapla
        int BalanceFactor(AVLNode node)
        {
            if (node == null)
                return 0;
            return Height(node.Left) - Height(node.Right);
        }

        // Yeni yükseklik değerini güncelle
        void UpdateHeight(AVLNode node)
        {
            if (node != null)
                node.Height = 1 + Math.Max(Height(node.Left), Height(node.Right));
        }

        // Sağa dön
        AVLNode RightRotate(AVLNode y)
        {
            AVLNode x = y.Left;
            AVLNode T2 = x.Right;

            x.Right = y;
            y.Left = T2;

            UpdateHeight(y);
            UpdateHeight(x);

            return x;
        }

        // Sola dön
        AVLNode LeftRotate(AVLNode x)
        {
            AVLNode y = x.Right;
            AVLNode T2 = y.Left;

            y.Left = x;
            x.Right = T2;

            UpdateHeight(x);
            UpdateHeight(y);

            return y;
        }

        // Dengele ve düzelt
        AVLNode Balance(AVLNode node)
        {
            UpdateHeight(node);

            int balance = BalanceFactor(node);

            // Sol ağaç yüksekse
            if (balance > 1)
            {
                if (BalanceFactor(node.Left) < 0)
                    node.Left = LeftRotate(node.Left);
                return RightRotate(node);
            }
            // Sağ ağaç yüksekse
            if (balance < -1)
            {
                if (BalanceFactor(node.Right) > 0)
                    node.Right = RightRotate(node.Right);
                return LeftRotate(node);
            }

            return node;
        }

        // Yeni bir düğüm ekle
        public void Insert(int data)
        {
            root = Insert(root, data);
        }

        // Yeni bir düğüm ekle
        AVLNode Insert(AVLNode node, int data)
        {
            // Standart BST ekleme
            if (node == null)
                return new AVLNode(data);

            if (data < node.Data)
                node.Left = Insert(node.Left, data);
            else if (data > node.Data)
                node.Right = Insert(node.Right, data);
            else
                return node; // Duplicate veri eklenmez.

            // Yükseklik güncelle
            UpdateHeight(node);

            // Dengele ve düzelt
            return Balance(node);
        }

        // Ağacı preorder olarak gez
        void InorderTraversal(AVLNode root)
        {
            if (root != null)
            {
                InorderTraversal(root.Left);
                Console.Write(root.Data + " ");
                InorderTraversal(root.Right);
            }
        }

        void PreorderTraversal(AVLNode root)
        {
            if (root != null)
            {
                Console.Write(root.Data + " ");
                PreorderTraversal(root.Left);               
                PreorderTraversal(root.Right);
            }
        }

        // Ağacı Preorder olarak gezerek yazdır
        public void PrintPreorder()
        {
            PreorderTraversal(root);
            Console.WriteLine();
        }
    }
}
