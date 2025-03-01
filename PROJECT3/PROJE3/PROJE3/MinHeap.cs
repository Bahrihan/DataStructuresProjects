using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJE3
{
    class MinHeap
    {
        private UM_Alani[] heap;
        private int size;
        private int capacity;

        public MinHeap(int capacity)
        {
            this.capacity = capacity;
            this.size = 0;
            this.heap = new UM_Alani[capacity];
        }

        private int Parent(int i)
        {
            return (i - 1) / 2;
        }

        private int LeftChild(int i)
        {
            return 2 * i + 1;
        }

        private int RightChild(int i)
        {
            return 2 * i + 2;
        }

        private void Swap(int i, int j)
        {
            UM_Alani temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }

        private void ResizeHeap()
        {
            int newCapacity = capacity * 2;
            UM_Alani[] newHeap = new UM_Alani[newCapacity];

            for (int i = 0; i < size; i++)
            {
                newHeap[i] = heap[i];
            }

            heap = newHeap;
            capacity = newCapacity;
        }

        private void HeapifyUp(int index)
        {
            while (index > 0 && string.Compare(heap[Parent(index)].alanAdi, heap[index].alanAdi, StringComparison.CurrentCulture) > 0)
            {
                Swap(index, Parent(index));
                index = Parent(index);
            }
        }

        private void HeapifyDown(int index)
        {
            int minIndex = index;
            int leftChild = LeftChild(index);
            int rightChild = RightChild(index);

            if (leftChild < size && string.Compare(heap[leftChild].alanAdi, heap[minIndex].alanAdi, StringComparison.CurrentCulture) < 0)
            {
                minIndex = leftChild;
            }

            if (rightChild < size && string.Compare(heap[rightChild].alanAdi, heap[minIndex].alanAdi, StringComparison.CurrentCulture) < 0)
            {
                minIndex = rightChild;
            }

            if (index != minIndex)
            {
                Swap(index, minIndex);
                HeapifyDown(minIndex);
            }
        }

        public void Insert(UM_Alani value)
        {
            if (size == capacity)
            {
                Console.WriteLine("Heap dolu! Kapasite arttırıldı.");
                ResizeHeap();
            }
            size++;
            heap[size - 1] = value;
            HeapifyUp(size - 1);
        }

        public UM_Alani ExtractMin()
        {
            if (size == 0)
            {
                Console.WriteLine("Heap zaten boş!");
                return null;
            }

            UM_Alani root = heap[0];
            heap[0] = heap[size - 1];
            size--;
            HeapifyDown(0);

            return root;
        }

        public void PrintHeap()
        {
            Console.Write("Min Heap:\n");
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine(heap[i].alanAdi);
            }
        }
    }
}
