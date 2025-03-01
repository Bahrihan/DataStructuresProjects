using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJE3_4
{
    public class PriorityQueue<T> where T : IComparable<T>
    {
        //@INFO
        // IComparable interface'i T nesnesinin karşılaştırılabilir olmasını sağlar.
        // 2 <T> nesneyi karşılaştırır.
        private T[] array;
        private int count;

        public PriorityQueue()
        {
            array = new T[10];
            count = 0;
        }

        public int Count
        {
            get { return count; }
        }

        public void Enqueue(T item)
        {
            if (count == array.Length)
            {
                Array.Resize(ref array, array.Length * 2);
            }

            int index = count;
            // item.CompareTo(array[index - 1]) < 0 eklenen yeni nesneyi doğru yere alana kadar nesneyi kaydırır.
            while (index > 0 && item.CompareTo(array[index - 1]) < 0)
            {
                array[index] = array[index - 1];
                index--;
            }

            array[index] = item;
            count++;
        }

        public T Dequeue()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("Priority Queue is empty.");
            }

            T frontItem = array[0];

            for (int i = 1; i < count; i++)
            {
                array[i - 1] = array[i];
            }

            count--;

            return frontItem;
        }
    }
}
