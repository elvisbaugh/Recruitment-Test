using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GiftAidCalculator.Service;
using GiftAidCalculator.TestConsole.Service;

namespace GiftAidCalculator.TestConsole
{
   public  class Program
    {
        static void Main(string[] args)
        {
            var giftAidCalculator = new DefaultGiftAidCalculator(new TaxRateProvider());

            // Calc Gift Aid Based on Previous
            Console.WriteLine("Please Enter donation amount:");
            Console.WriteLine(giftAidCalculator.GetGiftAidAmount(decimal.Parse(Console.ReadLine())));
            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }
    }
}
