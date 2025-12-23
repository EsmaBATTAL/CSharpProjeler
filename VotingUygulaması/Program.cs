using System;
using System.Collections.Generic;

namespace VotingUygulamasi
{
    
    public class KullaniciYonetici
    {
        private Dictionary<string, bool> kullanicilar = new Dictionary<string, bool>();

        public bool KullaniciVarMi(string username)
        {
            return kullanicilar.ContainsKey(username);
        }

        public void KayitOl(string username)
        {
            if (!string.IsNullOrWhiteSpace(username) && !kullanicilar.ContainsKey(username))
                kullanicilar[username] = true;
        }
    }

    
    public class Kategori
    {
        public string Ad { get; }
        public int OySayisi { get; private set; }

        public Kategori(string ad)
        {
            Ad = ad;
            OySayisi = 0;
        }

        public void OyVer()
        {
            OySayisi++;
        }
    }

    
    public class VotingYonetici
    {
        private List<Kategori> kategoriler;

        public VotingYonetici(List<Kategori> kategoriler)
        {
            this.kategoriler = kategoriler;
        }

        public void OyKullan(string kategoriAdi)
        {
            Kategori kategori = null;

            
            foreach (var k in kategoriler)
            {
                if (k.Ad.ToLower() == kategoriAdi.ToLower())
                {
                    kategori = k;
                    break;
                }
            }

            if (kategori != null)
                kategori.OyVer();
            else
                Console.WriteLine("Geçersiz kategori seçimi!");
        }

        public void SonuclariYazdir()
        {
            int toplamOy = 0;

           
            foreach (var k in kategoriler)
            {
                toplamOy += k.OySayisi;
            }

            Console.WriteLine("\n--- Voting Sonuçları ---");
            foreach (var k in kategoriler)
            {
                double yuzde = toplamOy > 0 ? (k.OySayisi * 100.0 / toplamOy) : 0;
                Console.WriteLine($"{k.Ad}: {k.OySayisi} oy ({yuzde:F2}%)");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            var kullaniciYonetici = new KullaniciYonetici();

            
            var kategoriler = new List<Kategori>
            {
                new Kategori("Film"),
                new Kategori("Kitap"),
                new Kategori("Spor")
            };

            var votingYonetici = new VotingYonetici(kategoriler);

            Console.WriteLine("Voting Uygulamasına Hoşgeldiniz!");
            Console.WriteLine("Kategoriler:");
            foreach (var k in kategoriler)
                Console.WriteLine(" - " + k.Ad);

            string devam;
            do
            {
                Console.Write("\nUsername giriniz: ");
                string username = Console.ReadLine();

                if (!kullaniciYonetici.KullaniciVarMi(username))
                {
                    Console.WriteLine("Kullanıcı bulunamadı. Kayıt yapılıyor...");
                    kullaniciYonetici.KayitOl(username);
                }

                Console.Write("Oy vermek istediğiniz kategori: ");
                string kategoriAdi = Console.ReadLine();
                votingYonetici.OyKullan(kategoriAdi);

                Console.Write("Devam etmek istiyor musunuz? (e/h): ");
                devam = Console.ReadLine();
            }
            while (devam?.ToLower() == "e");

            votingYonetici.SonuclariYazdir();
        }
    }
}

