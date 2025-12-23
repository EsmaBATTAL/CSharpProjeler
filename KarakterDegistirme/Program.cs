using System;

namespace KarakterDegistirme
{
    class Program
{
    static void Main()
    {
        Console.WriteLine("İfadeyi giriniz (kelimeler arası boşluk bırakın):");
        string giris = Console.ReadLine();

        string[] kelimeler = giris.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        foreach (var kelime in kelimeler)
        {
            Console.Write(Degistir(kelime) + " ");
        }
    }

    
    static string Degistir(string kelime)
    {
        if (string.IsNullOrEmpty(kelime) || kelime.Length == 1)
            return kelime; 

        char[] karakterler = kelime.ToCharArray();

        char ilk = karakterler[0];
        char son = karakterler[karakterler.Length - 1];

        karakterler[0] = son;
        karakterler[karakterler.Length - 1] = ilk;

        return new string(karakterler);
    }
}
}


