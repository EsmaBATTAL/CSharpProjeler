using System;
using System.Collections.Generic;
namespace KarakterTerstenYazma
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lütfen bir cümle giriniz: ");
            string veri=Console.ReadLine();
            Array VListe = veri.Split(' ');
            List<string> liste = new List<string>();
            List<char> listeChar = new List<char>();
            foreach (var item in VListe)
            {
                liste.Add(item.ToString());
            }
            foreach (var item in liste)
            {
                foreach (var k in item)
                {
                    listeChar.Add(k);
                }
                listeChar.Reverse();
                foreach (var i in listeChar)
                {
                    Console.Write(i);
                }
                Console.Write(' ');
                listeChar.Clear();
            }

            Console.WriteLine();
        
        }
        
    }
}