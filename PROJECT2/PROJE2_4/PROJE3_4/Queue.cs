using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJE3_4
{
    class Queue
    {
        public int[] items;
        public int rear;
        public int front;

        public Queue(int capacity) 
        {
            items = new int[capacity];
            front = 0;
            rear = -1;
        }

        public void Enqueue(int item)
        {
            if (rear == items.Length - 1)
            {
                Console.WriteLine("Sıra dolu, eleman eklenemiyor.");
                return;
            }

            items[++rear] = item;
        }

        public int Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Sıra boş.");
            }

            int item = items[front++];
            return item;
        }

        public int Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Sıra boş.");
            }

            return items[front];
        }

        public bool IsEmpty()
        {
            return front > rear;
        }

        public int Count()
        {
            return rear - front + 1;
        }


    }
}
