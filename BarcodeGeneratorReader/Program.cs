using System;
using System.Drawing;
using System.Drawing.Imaging;
using ZXing;

class Program
{
    static void Main()
    {
        Console.WriteLine("Barcode Generator/Reader Uygulaması");

       
        Console.Write("Barkod için içerik giriniz: ");
        string content = Console.ReadLine();

        
        string filePath = "barcode.png";
        GenerateBarcode(content, filePath);
        Console.WriteLine($"Barkod {filePath} dosyasına kaydedildi.");

        
        string result = ReadBarcode(filePath);
        Console.WriteLine($"Okunan barkod içeriği: {result}");
    }

    
    static void GenerateBarcode(string content, string filePath)
    {
        var barcodeWriter = new BarcodeWriter
        {
            Format = BarcodeFormat.CODE_128,
            Options = new ZXing.Common.EncodingOptions
            {
                Width = 300,
                Height = 100,
                Margin = 10
            }
        };

        using (Bitmap bitmap = barcodeWriter.Write(content))
        {
            bitmap.Save(filePath, ImageFormat.Png);
        }
    }

    
    static string ReadBarcode(string filePath)
    {
        var barcodeReader = new BarcodeReader();
        using (Bitmap bitmap = (Bitmap)Image.FromFile(filePath))
        {
            var result = barcodeReader.Decode(bitmap);
            return result?.Text ?? "Barkod okunamadı!";
        }
    }
}

