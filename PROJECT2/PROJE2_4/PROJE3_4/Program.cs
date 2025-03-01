using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJE3_4
{
    class Program
    {
        const double READ_TIME = 2.5; // (second)
        static void Main(string[] args)
        {
            int[] customerList = {10,4,8,6,7,1,15,9,3,2};

            ReadTimeWithQ(customerList);
            ReadTimeWithPQ(customerList);
            Console.ReadLine();
        }
        
        /*
        * FIFO VE PQ yöntemlerini birleştirmeye öneri:
        * Yine az ürün öncelikli olarak sırayla her müşterinin sırayla birer ürününü okutarak devam etmek olmalıdır.
        * bkz. birer birer okuttuğumuzda her müşteri için ortalama memnuniyet artmalıdır.
        */

        
        private static void ReadTimeWithPQ(int[] customerList)
        {
            PriorityQueue<int> pq = new PriorityQueue<int>();

            for (int i = 0; i < customerList.Length; i++)
            {
                pq.Enqueue(customerList[i]);
            }
            int j = 0;
            double sumOfTime = 0;
            double totalSum = 0;
            while (pq.Count > 0)
            {
                double customerTime = pq.Dequeue() * READ_TIME;
                sumOfTime += customerTime;
                totalSum += sumOfTime;
                j++;
                Console.WriteLine($"{j}. öncelikli müşterinin işlem süresi: {sumOfTime}");
            }
            Console.WriteLine($"Ortalama işlem süresi: {totalSum / customerList.Length}");
        }

        private static void ReadTimeWithQ(int[] customerList)
        {
            Queue queue = new Queue(customerList.Length);

            for (int i = 0; i < customerList.Length; i++)
            {
                queue.Enqueue(customerList[i]);
            }

            double sumOfTime = 0;
            double totalSum = 0;
            int j = 0;
            while (!queue.IsEmpty())
            {
                double customerTime = queue.Dequeue() * READ_TIME;
                sumOfTime += customerTime;
                totalSum += sumOfTime;
                j++;
                Console.WriteLine($"{j}. müşterinin işlem tamamlama süresi: {sumOfTime}");
            }
            Console.WriteLine($"Ortalama işlem süresi: {totalSum / customerList.Length}");
        }
    }
}
