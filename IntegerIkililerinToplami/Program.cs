using System;

namespace IntegerIkiliToplam
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("İkili olarak toplanacak sayı kümesini giriniz (Lütfen sayı adedini çift giriniz): ");
            string veri = Console.ReadLine();
            List<int> liste = new List<int>();
            Array veri2 = veri.Split(' ',StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in veri2)
            {
                liste.Add(Convert.ToInt32(item));
            }
            List<int> liste2 = new List<int>();
            int n = liste.Count;
            if (n % 2 != 0)
            {
                Console.WriteLine("Çift adet sayı girmediniz.");
                return;
            }
            int a = 0, b = 0, sonuc = 0;
            for (int i = 0; i < n; i += 2)
            {
                a = liste[i];
                b = liste[i+1];
                if (a != b)
                    sonuc = a+b;
                else
                    sonuc =(a + b) * (a + b);
                liste2.Add(sonuc);
            }
            foreach (var item in liste2)
            {
                Console.WriteLine(item);
            }

        }
    }
}