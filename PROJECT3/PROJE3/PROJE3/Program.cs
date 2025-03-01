using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJE3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UM_Tree uM_Tree = new UM_Tree();
            List<UM_Alani> uMList = new List<UM_Alani>();
            InsertElements(uM_Tree);
            MinHeap minHeap = new MinHeap(uM_Tree.CountNodes());

            while (true)
            {
                Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz(0-4):\n" +
                "1-UM Ağacının derinliği, bilgiler ve dengeli ağaç hesaplaması\n" +
                "2-Gireceğiniz 2 harf arasındaki UM Alanları\n" +
                "3-Liste kullanarak binary(ikili) yöntemle dengeli ağaç oluşturma\n" +
                "4-HashTable oluşturma ve güncelleme\n" +
                "5-Heap veri yapısı kullanımı ve 3 elemanın silinmesi\n" +
                "0-Programdan çıkış.");
                int process;
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out process)) // kullanıcıdan sayı girdisi alma
                    {
                        if (process >= 0 && process <= 5)
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
                        uM_Tree.InOrder(uM_Tree.getRoot());
                        Console.WriteLine("---------------");
                        int depth = uM_Tree.FindDepth();
                        Console.WriteLine("Ağaç derinliği: " + depth);
                        int balancedDepth = uM_Tree.BalancedTreeDepth();
                        Console.WriteLine("Dengeli ağaç olursa ağaç derinliği: " + balancedDepth);
                        break;
                    case 2:
                        PrintBetweenTwoLetters(uM_Tree);
                        break;
                    case 3:
                        uM_Tree.ListInOrder(uM_Tree.getRoot(), uMList);
                        TreeNode node = uM_Tree.BuildBalancedTree(uMList);
                        Console.WriteLine("Dengeli ağaç oluşturuldu.");
                        uM_Tree.PreOrder(node, true);
                        break;
                    case 4:
                        Hashtable hashtable = new Hashtable();
                        AddToHashTable(hashtable);
                        Console.WriteLine("HashTable Oluşturuldu..");
                        Console.WriteLine("HashTable'ı güncellemek istiyor musunuz?(e/h)");
                        string input = Console.ReadLine();
                        if (input == "e")
                        {
                            Console.Write("Güncellemek istediğiniz UM Alan adını giriniz: ");
                            string currentName = Console.ReadLine();
                            Console.Write("Güncellemek için yeni UM Alan adını giriniz: ");
                            string newName = Console.ReadLine();
                            UpdateHashTable(currentName, newName, hashtable);
                        }

                        break;
                    case 5:
                        InsertToHeap(minHeap);
                        minHeap.PrintHeap();
                        for (int i = 0; i < 3; i++)
                        {
                            UM_Alani minUM = minHeap.ExtractMin();
                            Console.WriteLine($"Alan Adı: {minUM.alanAdi}");
                            Console.WriteLine("Ön Bilgi:");
                            string words = string.Join(" ", minUM.info);
                            Console.WriteLine(words);
                            Console.WriteLine();
                        }
                        break;
                }
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("Lütfen devam etmek için enter'a basınız...");
                Console.ReadLine();
                Console.WriteLine("-------------------------------------------");
            }
        }

        public static void PrintHashTable(Hashtable umHashTable)
        {
            foreach (var key in umHashTable.Keys)
            {
                string alanAdi = (string)key;
                UM_Alani um = (UM_Alani)umHashTable[key];

                Console.WriteLine($"Alan Adı: {alanAdi}");
                Console.WriteLine("Ön Bilgi:");
                string words = string.Join(" ", um.info);
                Console.WriteLine(words);
                Console.WriteLine();
            }
        }

        public static void InsertElements(UM_Tree uM_Tree)
        {
            string file = "C:\\Users\\LENOVO\\bahrihan\\Masaüstü\\C# VS\\Proje3\\PROJE3\\UM_Alanlari.txt";

            try
            {
                using (StreamReader sr = new StreamReader(file, Encoding.GetEncoding("iso-8859-9")))
                {
                    while (!sr.EndOfStream)
                    {
                        string satir1 = sr.ReadLine();
                        string satir2 = sr.ReadLine();
                        string[] words = satir2.Split(' ');
                        List<string> wordList = new List<string>();
                        foreach (string word in words)
                        {
                            wordList.Add(word);
                        }
                        UM_Alani uM_Alani = new UM_Alani(satir1, wordList);
                        uM_Tree.Insert(uM_Alani);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: " + e.Message);
            }
        }

        public static void PrintBetweenTwoLetters(UM_Tree uM_Tree)
        {
            Console.WriteLine("2 harf arasındaki şehirleri listelemek için lütfen harfleri sırasıyla giriniz: ");
            Console.Write("1.harf: ");
            string input1 = Console.ReadLine();
            Console.Write("2.harf: ");
            string input2 = Console.ReadLine();
            if (string.Compare(input1, input2, StringComparison.CurrentCulture) > 0)// alfabe önceliği input1de olmalıdır.
            {
                string temp = input1;
                input1 = input2;
                input2 = temp;
            }
            uM_Tree.PrintUMBetweenChars(input1, input2);
        }

        public static Hashtable AddToHashTable(Hashtable hashtable)
        {
            string file = "C:\\Users\\LENOVO\\bahrihan\\Masaüstü\\C# VS\\Proje3\\PROJE3\\UM_Alanlari.txt";

            try
            {
                using (StreamReader sr = new StreamReader(file, Encoding.GetEncoding("iso-8859-9")))
                {
                    while (!sr.EndOfStream)
                    {
                        string satir1 = sr.ReadLine();
                        string satir2 = sr.ReadLine();
                        string[] words = satir2.Split(' ');
                        List<string> wordList = new List<string>();
                        foreach (string word in words)
                        {
                            wordList.Add(word);
                        }
                        UM_Alani uM_Alani = new UM_Alani(satir1, wordList);
                        hashtable.Add(uM_Alani.alanAdi, uM_Alani); // alanAdi is used as key
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Hata: " + e.Message);
            }
            return hashtable;
        }

        public static void UpdateHashTable(string currentName, string newName, Hashtable hashtable)
        {
            if (hashtable.ContainsKey(currentName))
            {
                UM_Alani um = (UM_Alani)hashtable[currentName];
                um.alanAdi = newName;

                hashtable[newName] = um;

                hashtable.Remove(currentName);

                Console.WriteLine($"UM_Alanı adı güncellendi: {currentName} -> {newName}");
            }
            else
            {
                Console.WriteLine($"Hata: {currentName} adında bir UM Alanı bulunamadı.");
            }
        }

        public static void InsertToHeap(MinHeap minHeap)
        {
            string file = "C:\\Users\\LENOVO\\bahrihan\\Masaüstü\\C# VS\\Proje3\\PROJE3\\UM_Alanlari.txt";
            try
            {
                using (StreamReader sr = new StreamReader(file, Encoding.GetEncoding("iso-8859-9")))
                {
                    while (!sr.EndOfStream)
                    {
                        string satir1 = sr.ReadLine();
                        string satir2 = sr.ReadLine();
                        string[] words = satir2.Split(' ');
                        List<string> wordList = new List<string>();
                        foreach (string word in words)
                        {
                            wordList.Add(word);
                        }
                        UM_Alani uM_Alani = new UM_Alani(satir1, wordList);
                        minHeap.Insert(uM_Alani);
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
