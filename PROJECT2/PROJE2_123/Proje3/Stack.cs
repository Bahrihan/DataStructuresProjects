using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje3
{
    class Stack<T>
    {
        private const int DefaultCapacity = 4;
        private T[] items;
        private int size;

        public Stack()
        {
            items = new T[DefaultCapacity];
            size = 0;
        }

        public int Count
        {
            get { return size; }
        }

        public void Push(T item)
        {
            if (size == items.Length)
            {
                ResizeArray();
            }

            items[size++] = item;
        }

        public T Pop()
        {
            if (size == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }

            T poppedItem = items[--size];
            return poppedItem;
        }

        public T Peek()
        {
            if (size == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }

            return items[size - 1];
        }

        public bool isEmpty()
        {
            return size == 0;
        }

        private void ResizeArray()
        {
            int newCapacity = items.Length * 2;
            Array.Resize(ref items, newCapacity);
        }
    }
}
