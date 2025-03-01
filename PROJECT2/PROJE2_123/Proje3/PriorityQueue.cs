using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje3
{
    public class PriorityQueue
    {
        private List<UMAlani> umAlanlari; // Generic List

        public PriorityQueue()
        {
            umAlanlari = new List<UMAlani>();
        }

        public void Add(UMAlani umAlan)
        {
            umAlanlari.Add(umAlan); // liste sonuna ekleme
        }

        public void Delete()
        {
            if (umAlanlari.Count == 0)
            {
                Console.WriteLine("PQ boş!");
                return;
            }

            //alfabetik sıraya göre silme
            UMAlani mostPriority = umAlanlari[0];
            for (int i = 1; i < umAlanlari.Count; i++)
            {
                if (umAlanlari[i].AlanAdi.CompareTo(mostPriority.AlanAdi) < 0)
                {
                    mostPriority = umAlanlari[i];
                }
            }

            umAlanlari.Remove(mostPriority);
            Console.WriteLine($"'{mostPriority.AlanAdi}' adlı UM Alanı Silindi.");
        }

        public bool isEmpty()
        {
            return umAlanlari.Count == 0;
        }
    }
}
