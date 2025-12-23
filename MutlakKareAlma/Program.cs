using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Sayıları boşlukla ayırarak giriniz:");
        string veri = Console.ReadLine();

        string[] parcalar = veri.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        List<int> sayilar = new List<int>();
        foreach (var item in parcalar)
        {
            sayilar.Add(Convert.ToInt32(item));
        }

        int toplamKucuk = 0;
        int toplamBuyuk = 0;
        int fark = 0;

        foreach (int s in sayilar)
        {
            if (s < 67)
            {
                fark = 67 - s;
                toplamKucuk += fark;
            }
            else if (s > 67)
            {
                fark = s - 67;
                toplamBuyuk += fark * fark;
            }
        }

        Console.WriteLine(toplamKucuk + " " + toplamBuyuk);
    }
}
