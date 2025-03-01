using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje1
{
    internal static class Operations
    {
        public static void MaxDistance(String[] cities, int[][] distances)
        {
            int max = 0;
            int maxCity1 = 0; // index city
            int maxCity2 = 0;

            for (int i = 0; i < distances.Length; i++)
            {
                for (int j = 0; j < distances[i].Length; j++)
                {
                    if (distances[i][j] != 0)
                    {
                        if (max < distances[i][j])
                        {
                            max = distances[i][j];
                            maxCity1 = i;
                            maxCity2 = j;
                        }
                    }
                }
            }
            Console.WriteLine("Aralarındaki mesafenin en uzun olduğu 2 il : " + cities[maxCity1]
                + " ve " + cities[maxCity2] + "\nAralarındaki mesafe: " + max + " km");
        }
        public static void MinDistance(String[] cities, int[][] distances)
        {
            int min = int.MaxValue;
            int minCity1 = 0; // index city
            int minCity2 = 0;
            for (int i = 0; i < distances.Length; i++)
            {
                for (int j = 0; j < distances[i].Length; j++)
                {
                    if (distances[i][j] != 0)
                    {
                        if (min > distances[i][j])
                        {
                            min = distances[i][j];
                            minCity1 = i;
                            minCity2 = j;
                        }
                    }
                }
            }
            Console.WriteLine("Aralarındaki mesafenin en kısa olduğu 2 il : " + cities[minCity1]
                + " ve " + cities[minCity2] + "\nAralarındaki mesafe: " + min + " km");
        }
        public static void RequestedCity(String[] cities, int[][] distances)
        {
            Console.Write("İl plakasını veya adını giriniz: ");
            String cityNum = Console.ReadLine();
            Console.Write("O ilden gezilecek mesafeyi giriniz: ");
            int distance = Convert.ToInt32(Console.ReadLine());
            int plateNumber = 1;
            if (cityNum.Length <= 2) //plaka kodu en fazla 2 karakter olabilir.
            {
                int intInput = Convert.ToInt32(cityNum);
                if (intInput <= 0 || intInput > 81)
                {
                    Console.WriteLine("Şehir bulunamadı.");
                    return;
                }
                else
                {
                    plateNumber = intInput - 1;
                }
            }
            else
            {
                int i = 0;
                while (i < cities.Length)
                {
                    if (cities[i] == cityNum.ToUpper())
                    {
                        plateNumber = i;
                        break;
                    }
                    i++;
                }
                if (plateNumber == 1)
                {
                    Console.WriteLine("Şehir bulunamadı: " + cityNum);
                    return; // şehir bulunamadığı için fonksiyonu sonlandır.
                }

            }
            Console.WriteLine("İstenilen şehir ve plaka kodu: " + cities[plateNumber] + "," + (plateNumber + 1));
            Console.WriteLine("-------------------------------------------");
            int counter = 0;
            for (int j = 0; j < cities.Length; j++)
            {
                if (distances[plateNumber][j] <= distance)
                {
                    if (distances[plateNumber][j] != 0)
                    {
                        counter++;
                        Console.WriteLine("Şehir ismi: " + cities[j] + " Uzaklık: " + distances[plateNumber][j]);
                    }
                }
            }
            Console.WriteLine("Gezilebilecek toplam il sayısı: " + counter);
        }

        public static int[][] DistanceOfCities(int[][] distances)
        {
            string file = "C:\\Users\\LENOVO\\bahrihan\\Masaüstü\\C# VS\\KarayollarıUH\\proje1\\ilMesafe.txt";
            using (StreamReader sr = new StreamReader(file))
            {
                string satir;
                int i = 0;
                while ((satir = sr.ReadLine()) != null)
                {
                    String[] tempList = satir.Split(' '); // string to int dönüşümü
                    for (int j = 0; j < tempList.Length; j++)
                    {
                        distances[i][j] = Convert.ToInt32(tempList[j]);
                    }
                    i++;
                }
                sr.Close();
            }
            return distances;
        }

        public static void Random5Cities(String[] cities, int[][] distances)
        {
            int[] randomCities = new int[5];
            Random random = new Random();

            for (int i = 0; i < 5; i++)
            {
                int j = 0;
                randomCities[i] = random.Next(81);
                while (j < i) // same value control
                {
                    while (randomCities[j] == randomCities[i])
                    {
                        randomCities[i] = random.Next(81);
                    }
                    j++;
                }
            }
            int[,] citiesLength = new int[5, 5];

            for (int i = 0; i < randomCities.Length; i++)
            {
                for (int j = 0; j < randomCities.Length; j++)
                {
                    citiesLength[i, j] = distances[randomCities[i]][randomCities[j]];
                }
            }
            Console.Write("               ");
            for (int i = 0; i < randomCities.Length; i++)
            {
                String b = String.Format("{0, -15}", cities[randomCities[i]]);
                Console.Write(b);
            }

            Console.WriteLine();
            Console.WriteLine();
            for (int i = 0; i < citiesLength.GetLength(0); i++)
            {
                String s = String.Format("{0, -15}", cities[randomCities[i]]);
                Console.Write(s);
                for (int j = 0; j < citiesLength.GetLength(1); j++)
                {
                    String a = String.Format("{0, -15}", citiesLength[i, j]);
                    Console.Write(a);
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }
        public static String[] InsertCities(String[] cities)
        {
            string file = "C:\\Users\\LENOVO\\bahrihan\\Masaüstü\\C# VS\\KarayollarıUH\\proje1\\şehirler.txt";
            using (StreamReader sr = new StreamReader(file, Encoding.GetEncoding("iso-8859-9")))
            {
                string row;
                int i = 0;
                while ((row = sr.ReadLine()) != null)
                {
                    cities[i] = row;
                    i++;
                }
            }
            return cities;
        }

        public static void printCities(String[] cities)
        {
            foreach (var item in cities)
            {
                Console.WriteLine(item);
            }
        }
        public static void MaxCitiesGivenDistance(string[] plakaList, int[][] km_list)
        {

            Console.WriteLine("Hangi il için bakmak istiyorsunuz(plaka kodu): ");
            int ilk_il_input = Convert.ToInt32(Console.ReadLine());
            int il_input = ilk_il_input;
            int gercek_il_input = il_input - 1;

            Console.WriteLine("Kaç km içinde bakıyorsunuz: ");
            int km_input = Convert.ToInt32(Console.ReadLine());
            int[][] km_listKopya = CopyJaggedArray(km_list);
            string[] plakaListKopya = new string[plakaList.Length];

            Array.Copy(plakaList, plakaListKopya, plakaList.Length);
            List<int> ziyaretEdilenIller = new List<int>();

            int toplam = 0; // gidilen toplam km
            int il_say = 0;
            int min = km_list.Min(x => x[gercek_il_input]);
            var result = FindMinValueAndIndex(km_list[gercek_il_input], ziyaretEdilenIller);
            int minValue = result.Item1;
            int minIndex = result.Item2;

            for (int j = 0; j < 81; j++)
            {
                if (result != null)
                {
                    minValue = result.Item1;
                    minIndex = result.Item2;
                    toplam += minValue;
                    if (toplam < km_input)
                    {
                        // index 0-80 --> plaka kodu 1-81
                        Console.WriteLine($"{plakaListKopya[il_input - 1]}' den  {plakaListKopya[minIndex - 1]} 'a  Uzaklık: {minValue + " km"}");
                        ziyaretEdilenIller.Add(il_input);
                        il_input = minIndex;
                        result = FindMinValueAndIndex(km_listKopya[il_input - 1], ziyaretEdilenIller);
                        il_say++;
                        Console.WriteLine();
                    }
                }
            }
            Console.WriteLine($"{plakaListKopya[ilk_il_input - 1]}' den {km_input} km mesafe ile gidilebilen maksimum il sayısı: {il_say}");
        }
        static Tuple<int, int> FindMinValueAndIndex(int[] array, List<int> yasaklist)
        {
            if (array == null || array.Length == 0)
            {
                return null;
            }
            int minValue = int.MaxValue;
            int minIndex = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] <= minValue && array[i] != 0 && !yasaklist.Contains(i + 1))
                {
                    minValue = array[i];
                    minIndex = i;
                }
            }
            return new Tuple<int, int>(minValue, minIndex + 1);
        }
        static int[][] CopyJaggedArray(int[][] originalArray)
        {
            int[][] copiedArray = new int[originalArray.Length][];

            for (int i = 0; i < originalArray.Length; i++)
            {
                copiedArray[i] = new int[originalArray[i].Length];
                for (int j = 0; j < originalArray[i].Length; j++)
                {
                    copiedArray[i][j] = originalArray[i][j];
                }
            }
            return copiedArray;
        }
    }
}
