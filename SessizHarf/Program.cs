using System;

namespace SessizHarf
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
                Console.WriteLine(Kontrol(kelime));
            }
        }

        static bool Kontrol(string kelime)
        {
            string sesliler = "aeıioöuüAEIİOÖUÜ"; 

            for (int i = 0; i < kelime.Length - 1; i++)
            {
                bool ilkSessiz = !sesliler.Contains(kelime[i]);
                bool ikinciSessiz = !sesliler.Contains(kelime[i + 1]);

                if (ilkSessiz && ikinciSessiz)
                    return true;
            }

            return false;
        }
    }
}

