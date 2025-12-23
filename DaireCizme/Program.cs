using System;

namespace DaireCizme
{
    class Program
    {
        static void Main(string[] args)
        {
            int yaricap = YariCapAl();
            DaireCiz(yaricap);
            
            
        }
        public static int YariCapAl()
        {
            Console.Write ("Lütfen dairenin yarıçapını giriniz: ");
            int yariCap;
            while(!int.TryParse(Console.ReadLine(), out yariCap) || yariCap <= 0)
            {
                Console.Write("Geçersiz giriş.Pozitif tamsayı giriniz: ");
            }
            return yariCap;
        }
        public static void DaireCiz(int yariCap)
        {
            int cap = 2 * yariCap;
            for (int y = 0; y <= cap; y++)
            {
                for(int x = 0; x <= cap; x++)
                {
                    int dx = x - yariCap;
                    int dy = y - yariCap;
                    double uzaklik = Math.Sqrt(dx * dx + dy * dy);

                    if (Math.Abs(uzaklik -yariCap) < 0.5)
                    {
                        Console.Write("#");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                    Console.WriteLine();
            }
        }
    }
}