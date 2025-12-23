using System;

namespace GeometriUygulamasi
{
   
    public class GirdiOkuyucu
    {
        public string SekilAl()
        {
            Console.Write("Şekli giriniz (Daire, Üçgen, Kare, Dikdörtgen): ");
            return Console.ReadLine().Trim().ToLower();
        }

        public string HesapTuruAl()
        {
            Console.Write("Hesap türünü giriniz (Alan, Çevre, Hacim): ");
            return Console.ReadLine().Trim().ToLower();
        }

        public double DegerAl(string mesaj)
        {
            double deger;
            Console.Write(mesaj);
            while (!double.TryParse(Console.ReadLine(), out deger) || deger <= 0)
            {
                Console.Write("Geçersiz giriş. Pozitif sayı giriniz: ");
            }
            return deger;
        }
    }

    
    public abstract class Sekil
    {
        public abstract double Alan();
        public abstract double Cevre();
        public virtual double Hacim() => 0; 
    }

    public class Daire : Sekil
    {
        private double yaricap;
        public Daire(double yaricap) => this.yaricap = yaricap;

        public override double Alan() => Math.PI * yaricap * yaricap;
        public override double Cevre() => 2 * Math.PI * yaricap;
    }

    public class Kare : Sekil
    {
        private double kenar;
        public Kare(double kenar) => this.kenar = kenar;

        public override double Alan() => kenar * kenar;
        public override double Cevre() => 4 * kenar;
    }

    public class Dikdortgen : Sekil
    {
        private double kisa, uzun;
        public Dikdortgen(double kisa, double uzun)
        {
            this.kisa = kisa;
            this.uzun = uzun;
        }

        public override double Alan() => kisa * uzun;
        public override double Cevre() => 2 * (kisa + uzun);
    }

    public class Ucgen : Sekil
    {
        private double a, b, c;
        public Ucgen(double a, double b, double c)
        {
            this.a = a; this.b = b; this.c = c;
        }

        public override double Alan()
        {
            double s = (a + b + c) / 2; 
            return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        }

        public override double Cevre() => a + b + c;
    }

    public class Hesaplayici
    {
        public double Hesapla(Sekil sekil, string hesapTuru)
        {
            if (hesapTuru == "alan")
                return sekil.Alan();
            else if (hesapTuru == "çevre" || hesapTuru == "cevre")
                return sekil.Cevre();
            else if (hesapTuru == "hacim")
                return sekil.Hacim();
            else
                throw new ArgumentException("Geçersiz hesap türü");
        }
    }


    public class CiktiYazici
    {
        public void SonucuYaz(string sekil, string hesapTuru, double sonuc)
        {
            Console.WriteLine($"\n{sekil} için {hesapTuru} sonucu: {sonuc:F2}");
        }
    }

    // Akış
    class Program
    {
        static void Main()
        {
            var girdi = new GirdiOkuyucu();
            var hesaplayici = new Hesaplayici();
            var cikti = new CiktiYazici();

            string sekilAdi = girdi.SekilAl();
            string hesapTuru = girdi.HesapTuruAl();

            Sekil sekil = sekilAdi switch
            {
                "daire" => new Daire(girdi.DegerAl("Yarıçap: ")),
                "kare" => new Kare(girdi.DegerAl("Kenar: ")),
                "dikdörtgen" or "dikdortgen" => new Dikdortgen(
                    girdi.DegerAl("Kısa kenar: "), girdi.DegerAl("Uzun kenar: ")),
                "üçgen" or "ucgen" => new Ucgen(
                    girdi.DegerAl("1. Kenar: "), girdi.DegerAl("2. Kenar: "), girdi.DegerAl("3. Kenar: ")),
                _ => throw new ArgumentException("Geçersiz şekil seçimi")
            };

            double sonuc = hesaplayici.Hesapla(sekil, hesapTuru);
            cikti.SonucuYaz(sekilAdi, hesapTuru, sonuc);
        }
    }
}

