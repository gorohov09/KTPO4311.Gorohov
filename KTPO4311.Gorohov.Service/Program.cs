using KTPO4311.Gorohov.Lib.src.LogAn;
using System;

namespace KTPO4311.Gorohov.Service
{
    public class Program
    {
        static void Main(string[] args)
        {
            LogAnalyzer analyzer = new LogAnalyzer();
            if (analyzer.IsValidLogFileName("fff.ext"))
            {
                Console.WriteLine("Файл fff.ext с правильным расширением");
            }
            else
            {
                Console.WriteLine("Файл fff.ext с неправильным расширением");
            }

            if (analyzer.IsValidLogFileName("fff.exp"))
            {
                Console.WriteLine("Файл fff.exp с правильным расширением");
            }
            else
            {
                Console.WriteLine("Файл fff.exp с неправильным расширением");
            }
        }
    }
}
