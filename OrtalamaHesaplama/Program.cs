using System;
using System.Collections.Generic;

namespace FibonacciOrtalamaApp
{
    // Fibonacci serisini üreten sınıf
    public class FibonacciGenerator
    {
        public List<int> Uret(int derinlik)
        {
            List<int> seri = new List<int>();

            if (derinlik <= 0) return seri;

            int a = 1, b = 1;
            seri.Add(a);

            if (derinlik > 1)
                seri.Add(b);

            for (int i = 2; i < derinlik; i++)
            {
                int c = a + b;
                seri.Add(c);
                a = b;
                b = c;
            }

            return seri;
        }
    }

    // Ortalama hesaplayan sınıf
    public class OrtalamaHesaplayici
    {
        public double Hesapla(List<int> sayilar)
        {
            if (sayilar.Count == 0) return 0;
            double toplam = 0;
            foreach (var s in sayilar)
            {
                toplam += s;
            }
            return toplam / sayilar.Count;
        }
    }

    // Konsol arayüzü sınıfı
    public class KonsolArayuzu
    {
        private FibonacciGenerator fibonacciGenerator;
        private OrtalamaHesaplayici ortalamaHesaplayici;

        public KonsolArayuzu()
        {
            fibonacciGenerator = new FibonacciGenerator();
            ortalamaHesaplayici = new OrtalamaHesaplayici();
        }

        public void Baslat()
        {
            Console.Write("Lütfen derinlik giriniz: ");
            int derinlik = int.Parse(Console.ReadLine());

            var seri = fibonacciGenerator.Uret(derinlik);
            double ortalama = ortalamaHesaplayici.Hesapla(seri);

            Console.WriteLine("\nFibonacci Serisi:");
            Console.WriteLine(string.Join(", ", seri));

            Console.WriteLine($"\nSerinin Ortalaması: {ortalama}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            KonsolArayuzu arayuz = new KonsolArayuzu();
            arayuz.Baslat();
        }
    }
}