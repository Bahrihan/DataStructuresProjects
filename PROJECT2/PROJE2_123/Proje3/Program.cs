using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Proje3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] regions = { "Akdeniz", "Doğu Anadolu", "Ege", "Güneydoğu Anadolu", "İç Anadolu", "Karadeniz", "Marmara"};

            List<UMAlani>[] genericList = new List<UMAlani>[7];

            for (int i = 0; i < genericList.Length; i++)
            {
                genericList[i] = new List<UMAlani>();
            }
            while (true)
            {
                Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz(0-4):\n" +
                "1-UM Alanlarını yazdırma\n" +
                "2-UM Alanlarını yığıta ekleme-çıkarma ile yazdırma\n" +
                "3-UM Alanlarını kuyruğa ekleme-çıkarma ile yazdırma\n" +
                "4-UM Alanlarını Alfabe önceliğine göre yazdırma\n" +
                "0-Programdan çıkış.");
                int process;
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out process)) // kullanıcıdan sayı girdisi alma
                    {
                        if (process >= 0 && process <= 4)
                        {
                            // girdi hatasız.
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Hatalı giriş! Lütfen 1 ile 4 arasında bir sayı girin:");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Hatalı giriş! Lütfen bir sayı girin:");
                    }
                }

                switch (process)
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        CreateUMField(genericList, regions);
                        break;
                    case 2:
                        CreateWithStack(genericList, regions);
                        break;
                    case 3:
                        CreateWithQueue(genericList, regions);
                        break;
                    case 4:
                        CreateWithPQ(genericList, regions);
                        break;
                }
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("Lütfen devam etmek için enter'a basınız...");
                Console.ReadLine();
                Console.WriteLine("-------------------------------------------");
            }
        }

        private static void CreateWithPQ(List<UMAlani>[] genericList, string[] regions)
        {
            string UMText = "C:\\Users\\LENOVO\\bahrihan\\Masaüstü\\C# VS\\Proje3\\Proje3\\UnescoMirasListesi.txt";
            try
            {
                PriorityQueue pq = new PriorityQueue();
                using (StreamReader sr = new StreamReader(UMText, Encoding.GetEncoding("iso-8859-9")))
                {
                    while (!sr.EndOfStream)
                    {
                        string row = sr.ReadLine();
                        string[] elements = row.Split(',');
                        List<string> cityNamesList = new List<string>();
                        string updatedCityName = RemoveParenthesis(elements[1]);
                        string[] citiesName = updatedCityName.Split('-');
                        foreach (string city in citiesName)
                        {
                            cityNamesList.Add(city);
                        }
                        int acceptedYear = int.Parse(elements[2]);
                        UMAlani umAlan = new UMAlani(elements[0], cityNamesList, acceptedYear);
                        pq.Add(umAlan);
                    }

                    while (!pq.isEmpty())
                    {
                        pq.Delete();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: " + e.Message);
            }
        }

        private static void CreateWithQueue(List<UMAlani>[] genericList, string[] regions)
        {
            string UMText = "C:\\Users\\LENOVO\\bahrihan\\Masaüstü\\C# VS\\Proje3\\Proje3\\UnescoMirasListesi.txt";
            try
            {
                Queue<UMAlani> queue = new Queue<UMAlani>();
                using (StreamReader sr = new StreamReader(UMText, Encoding.GetEncoding("iso-8859-9")))
                {
                    while (!sr.EndOfStream)
                    {
                        string row = sr.ReadLine();
                        string[] elements = row.Split(',');
                        List<string> cityNamesList = new List<string>();
                        string updatedCityName = RemoveParenthesis(elements[1]);
                        string[] citiesName = updatedCityName.Split('-');
                        foreach (string city in citiesName)
                        {
                            cityNamesList.Add(city);
                        }
                        int acceptedYear = int.Parse(elements[2]);
                        UMAlani umAlan = new UMAlani(elements[0], cityNamesList, acceptedYear);
                        queue.Enqueue(umAlan);
                    }

                    while (!queue.isEmpty())
                    {
                        UMAlani uMAlani = queue.Dequeue();
                        Console.Write($"Alan adı: {uMAlani.AlanAdi},");
                        foreach (var item in uMAlani.IlAdlari)
                        {
                            Console.Write($"il adı/adları: {item}, ");
                        }
                        Console.Write($"ilan yılı: {uMAlani.IlanYili}");
                        Console.WriteLine();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: " + e.Message);
            }
        }

        private static void CreateWithStack(List<UMAlani>[] genericList, string[] regions)
        {
            string UMText = "C:\\Users\\LENOVO\\bahrihan\\Masaüstü\\C# VS\\Proje3\\Proje3\\UnescoMirasListesi.txt";
            try
            {
                Stack<UMAlani> stack = new Stack<UMAlani>();
                using (StreamReader sr = new StreamReader(UMText, Encoding.GetEncoding("iso-8859-9")))
                {
                    while (!sr.EndOfStream)
                    {
                        string row = sr.ReadLine();
                        string[] elements = row.Split(',');
                        List<string> cityNamesList = new List<string>();
                        string updatedCityName = RemoveParenthesis(elements[1]);
                        string[] citiesName = updatedCityName.Split('-');
                        foreach (string city in citiesName)
                        {
                            cityNamesList.Add(city);
                        }
                        int acceptedYear = int.Parse(elements[2]);
                        UMAlani umAlan = new UMAlani(elements[0], cityNamesList, acceptedYear);
                        stack.Push(umAlan);
                    }

                    while (!stack.isEmpty())
                    {
                        UMAlani uMAlani = stack.Pop();
                        Console.Write($"Alan adı: {uMAlani.AlanAdi},");
                        foreach (var item in uMAlani.IlAdlari)
                        {
                            Console.Write($"il adı/adları: {item}, ");
                        }
                        Console.Write($"ilan yılı: {uMAlani.IlanYili}");
                        Console.WriteLine();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: " + e.Message);
            }
        }

        private static void CreateUMField(List<UMAlani>[] genericList, string[] regions)
        {
            string UMText = "C:\\Users\\LENOVO\\bahrihan\\Masaüstü\\C# VS\\Proje3\\Proje3\\UnescoMirasListesi.txt";
            try
            {
                using (StreamReader sr = new StreamReader(UMText, Encoding.GetEncoding("iso-8859-9")))
                {
                    while (!sr.EndOfStream)
                    {
                        string row = sr.ReadLine();
                        string[] elements = row.Split(',');
                        List<string> cityNamesList = new List<string>();
                        string updatedCityName = RemoveParenthesis(elements[1]);
                        string[] citiesName = updatedCityName.Split('-');
                        foreach (string city in citiesName)
                        {
                            cityNamesList.Add(city);
                        }
                        int acceptedYear = int.Parse(elements[2]);
                        UMAlani umAlan = new UMAlani(elements[0], cityNamesList, acceptedYear);
                        InsertElements(umAlan, genericList);
                    }

                    /*
                    string lastRow = sr.ReadLine();// 21. satır için
                    string[] lastRowElements = lastRow.Split(',');
                    List<string> lastCityNamesList = new List<string>();
                    string lastUpdatedCitiesName = RemoveParenthesis(lastRowElements[1]);
                    string[] lastCitiesName = lastUpdatedCitiesName.Split('/');
                    int lastAcceptedYear = int.Parse(lastRowElements[2]);
                    foreach (string city in lastCitiesName)
                    {
                        string[] tempRegionNameList = city.Split('-');
                        lastCityNamesList.Add(tempRegionNameList[0]);
                    }
                    UMAlani lastUMAlan = new UMAlani(lastRowElements[0], lastCityNamesList, lastAcceptedYear);
                    InsertElements(lastUMAlan, genericList);
                    */

                    PrintUMAlanlari(genericList, regions);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: " + e.Message);
            }
        }

        private static void PrintUMAlanlari(List<UMAlani>[] genericList, string[] regions)
        {
            int j = 0;
            foreach (var item in genericList)
            {
                Console.WriteLine($"Bölge: {regions[j]} - Bölgedeki toplam UM sayısı: {genericList[j].Count}");
                foreach (var item1 in item)
                {
                    Console.Write($"Alan adı: {item1.AlanAdi}| UM'nin bulunduğu il adı/adları:");
                    foreach (var city in item1.IlAdlari)
                    {
                        Console.Write($"{city} ");
                    }
                    Console.WriteLine($"| İlan yılı:{item1.IlanYili}");
                }
                Console.WriteLine();
                j++;
            }
        }

        private static string RemoveParenthesis(string text)
        {
            string newText = Regex.Replace(text, @"[\(\)]", "");

            return newText.Trim();
        }

        private static void InsertElements(UMAlani umAlan, List<UMAlani>[] genericList)
        {
            

            string bolgelerText = "C:\\Users\\LENOVO\\bahrihan\\Masaüstü\\C# VS\\Proje3\\Proje3\\Regions.txt";
            try
            {
                using (StreamReader sr = new StreamReader(bolgelerText, Encoding.GetEncoding("iso-8859-9")))
                {
                    List<int> indexList = new List<int>(); // il adlarının bölgelere göre indexlerini tutan liste.
                    int counter = 0;
                    bool isFound = false;
                    while (!sr.EndOfStream && !isFound || !(umAlan.IlAdlari.Count ==indexList.Count))
                    {
                        string satir = sr.ReadLine();
                        string[] regionOfCities = satir.Split(',');
                        foreach (string city in umAlan.IlAdlari)
                        {
                            for (int i = 0; i < regionOfCities.Length; i++)
                            {
                                if (regionOfCities[i] == city)
                                {
                                    isFound = true;
                                    indexList.Add(counter);
                                }
                            }
                        }
                        counter++;
                    }
                    foreach (var item in indexList) // for multi-city in cityNames list
                    {
                        genericList[item].Add(umAlan);
                    }
                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: " + e.Message);
            }
        }
    }
}
