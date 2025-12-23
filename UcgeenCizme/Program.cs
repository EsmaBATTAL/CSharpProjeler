using System;

namespace ucgenCizme
{
    public class UcgenCizme
    {
        public bool BoyutKontrol(int boyut)
        {
            if (boyut <= 0)
            {
                Console.WriteLine("Boyut bilgisi {0}  olamaz.",boyut);
                return false;
            }
            return true;
        }

        public UcgenCizme(int boyut)
        {
            
            if (BoyutKontrol(boyut))
            {
                Console.WriteLine("Üçgen çiziliyor...");
                for(int i = 1; i <= boyut; i++)
                {
                    string bosluk = new string(' ', boyut - i);
                    string kare = new string('#',i);
                    Console.WriteLine(bosluk + kare);

                }
            }
        }

        
    }
    public class KonsolArayuzu
    {
        public void Baslat()
        {
            Console.Write("Lütfen üçgen boyutu giriniz: ");
            int boyut = int.Parse(Console.ReadLine());
            UcgenCizme ucgen = new UcgenCizme(boyut);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            KonsolArayuzu arayuzu = new KonsolArayuzu();
            arayuzu.Baslat();

        }
    }
}