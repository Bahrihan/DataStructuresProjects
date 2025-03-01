using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace proje1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            // Program başladığında liste ve matrisi otomatik oluşturur.
            //----------------------------------
            int[][] distances = new int[81][]; // jagged matris
            for (int i = 0; i < distances.Length; i++)
            {
                distances[i] = new int[81];
            }
            String[] cities = new string[81]; // şehir list
            Operations.DistanceOfCities(distances); // il mesafesini textten oku ve jagged matrise at.
            String[] insertedCities = Operations.InsertCities(cities); // şehirleri dosyadan oku ve diziye at.
            // ---------------------------------

            while (true)
            {
                Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz: " +
                "\n1-Verilen ilden belli bir uzaklığa kadar olan illeri ve uzaklıklarını listeleme" +
                "\n2-Türkiye’deki birbirine en yakın iki ili yazdırma" +
                "\n3-Türkiye’deki birbirine en uzak iki ili yazdırma " +
                "\n4-Verilen ilden verilen mesafe kullanılarak en fazla kaç il dolaşılabildiğini bulma" +
                "\n5-Rastgele 5 ilin birbirleri ile olan mesafelerini yazdırma" +
                "\n0-Çıkış");
                int islem;
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out islem)) // kullanıcıdan sayı girdisi alma
                    {
                        if (islem >= 0 && islem <= 5)
                        {
                            // girdi hatasız.
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Hatalı giriş! Lütfen 1 ile 6 arasında bir sayı girin:");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Hatalı giriş! Lütfen bir sayı girin:");
                    }
                }

                switch (islem)
                {
                    case 0:
                        Environment.Exit(0); // programdan çıkış.
                        break;
                    case 1:
                        Operations.RequestedCity(cities, distances);
                        break;
                    case 2:
                        Operations.MinDistance(cities, distances);
                        break;
                    case 3:
                        Operations.MaxDistance(cities, distances);
                        break;
                    case 4:
                        Operations.MaxCitiesGivenDistance(cities, distances);
                        //int toplam = Operations.DFS(distances, 33,1000);
                        //Console.WriteLine("toplam il: " + toplam);
                        break;
                    case 5:
                        Operations.Random5Cities(cities, distances);
                        break;
                }
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("Lütfen devam etmek için enter'a basınız...");
                Console.ReadLine();
                Console.WriteLine("-------------------------------------------");
            }
            
        }    
    }
}
