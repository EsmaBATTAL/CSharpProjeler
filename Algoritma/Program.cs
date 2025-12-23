using System;

namespace Algoritma
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lütfen aralarında virgül ile bir kelime ve bir sayı giriniz(Örnek: Algoritma,3) : ");
            string alinan = Console.ReadLine();
            Array List = alinan.Split(' ');
            string veri = null;
            string[] ifade = new string[2];
            int index = 0;
            bool control;
            foreach (var item in List)
            {
                veri = Convert.ToString(item);
                ifade = veri.Split(',');
                index = Index(ifade[1]);
                control = Control(index, ifade[0]);
                if(control == true)
                    Console.Write(ifade[0].Remove(index,1) + " ");
                else
                    Console.Write(ifade[0]+ " ");
            }
            Console.WriteLine();
            
        }
        static int Index(string s)
        {
            int i = 0;
            try
            {
                i = int.Parse(s);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Lütfen bir sayı girerek tekrar deneyiniz." + ex);
            }
            return i;
        }
        static bool Control(int index, string s)
        {
            int count = s.Length;
            if(index > count)
                return false;
            return true;
        }
    }
}