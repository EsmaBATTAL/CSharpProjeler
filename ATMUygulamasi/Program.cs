using System;
using System.Collections.Generic;
using System.IO;

namespace ATMUygulamasi
{
    class Program
    {
        static Dictionary<string, string> kullanicilar = new Dictionary<string, string>()
        {
            {"esma","1234"},
            {"ali","4321"}
        };

        static List<string> transactionLog = new List<string>();
        static List<string> fraudLog = new List<string>();

        static void Main()
        {
            Console.WriteLine("ATM Uygulamasına Hoşgeldiniz!");

            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            if (!Login(username, password))
            {
                Console.WriteLine("Hatalı giriş!");
                fraudLog.Add($"Fraud giriş denemesi: {username} - {DateTime.Now}");
                return;
            }

            string secim;
            do
            {
                Console.WriteLine("\nİşlemler:");
                Console.WriteLine("1- Para Çekme");
                Console.WriteLine("2- Para Yatırma");
                Console.WriteLine("3- Ödeme Yapma");
                Console.WriteLine("4- Gün Sonu (EOD)");
                Console.WriteLine("5- Çıkış");

                Console.Write("Seçiminiz: ");
                secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        Console.Write("Çekilecek tutar: ");
                        string cek = Console.ReadLine();
                        transactionLog.Add($"Para çekme: {cek} TL - {DateTime.Now}");
                        Console.WriteLine($"{cek} TL çekildi.");
                        break;

                    case "2":
                        Console.Write("Yatırılacak tutar: ");
                        string yatir = Console.ReadLine();
                        transactionLog.Add($"Para yatırma: {yatir} TL - {DateTime.Now}");
                        Console.WriteLine($"{yatir} TL yatırıldı.");
                        break;

                    case "3":
                        Console.Write("Ödeme tutarı: ");
                        string odeme = Console.ReadLine();
                        transactionLog.Add($"Ödeme yapma: {odeme} TL - {DateTime.Now}");
                        Console.WriteLine($"{odeme} TL ödendi.");
                        break;

                    case "4":
                        GunSonu();
                        break;

                    case "5":
                        Console.WriteLine("Çıkış yapılıyor...");
                        break;

                    default:
                        Console.WriteLine("Geçersiz seçim!");
                        break;
                }

            } while (secim != "5");
        }

        static bool Login(string username, string password)
        {
            return kullanicilar.ContainsKey(username) && kullanicilar[username] == password;
        }

        static void GunSonu()
        {
            string tarih = DateTime.Now.ToString("ddMMyyyy");
            string dosyaAdi = $"EOD_{tarih}.txt";
            string yol = Path.Combine(Environment.CurrentDirectory, dosyaAdi);

            using (StreamWriter sw = new StreamWriter(yol))
            {
                sw.WriteLine("--- Transaction Log ---");
                foreach (var log in transactionLog)
                    sw.WriteLine(log);

                sw.WriteLine("\n--- Fraud Log ---");
                foreach (var log in fraudLog)
                    sw.WriteLine(log);
            }

            Console.WriteLine($"Gün sonu raporu {dosyaAdi} dosyasına yazıldı.");

        
            Console.WriteLine("\n--- Dosyadan Okunan Gün Sonu ---");
            string[] satirlar = File.ReadAllLines(yol);
            foreach (var s in satirlar)
                Console.WriteLine(s);
        }
    }
}

