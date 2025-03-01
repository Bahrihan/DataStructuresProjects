using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje3
{
        public class Queue<T>
        {
            private const int DefaultCapacity = 4;
            private T[] items;
            private int size;
            private int front;
            private int rear;

            public Queue()
            {
                items = new T[DefaultCapacity];
                size = 0;
                front = 0;
                rear = -1;
            }

            public int Count
            {
                get { return size; }
            }

            public void Enqueue(T item)
            {
                if (size == items.Length)
                {
                    ResizeArray();
                }

                rear = (rear + 1) % items.Length;
                items[rear] = item;
                size++;
            }

            public T Dequeue()
            {
                if (size == 0)
                {
                    throw new InvalidOperationException("Queue is empty");
                }

                T dequeuedItem = items[front];
                front = (front + 1) % items.Length;
                size--;

                return dequeuedItem;
            }

            public T Peek()
            {
                if (size == 0)
                {
                    throw new InvalidOperationException("Queue is empty");
                }

                return items[front];
            }

            public bool isEmpty()
            {
                return size == 0;
            }

            private void ResizeArray()
            {
                int newCapacity = items.Length * 2;
                T[] newItems = new T[newCapacity];
                for (int i = 0; i < size; i++)
                {
                    newItems[i] = items[(front + i) % items.Length];
                }

                items = newItems;
                front = 0;
                rear = size - 1;
            }
        }
}
