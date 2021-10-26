using System;
using System.Linq;

namespace BuyLowSellHigh
{
    /// <summary>
    /// Program to find the Buy day, Sell day and the appropriate prices for last month stock market of Computer share
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of days:");
            int x = Convert.ToInt32(Console.ReadLine());
            decimal[] array = new decimal[x];
            Console.WriteLine("Enter market-openeing stock prices:");

            for (int i = 0; i < x; i++)
            {
                array[i] = Convert.ToDecimal(Console.ReadLine());
            }

            decimal buyPrice = array[0];
            int buyDayOfMonth = 0;
            decimal sellPrice = array[0];
            int sellDayOfMonth = 0;

            for (int i = 0; i < x; i++)
            {
                if (buyPrice > array[i])
                {
                    buyPrice = array[i];
                    buyDayOfMonth = i + 1;
                }
            }

            decimal[] subList = array.Skip(buyDayOfMonth).ToArray();
            sellPrice = subList.DefaultIfEmpty().Max();

            if (sellPrice != 0)
            {
                sellDayOfMonth = buyDayOfMonth + Array.IndexOf(subList, sellPrice) + 1;
            }
            else
            {
                sellDayOfMonth = 0;
                Console.WriteLine("\nThere is no sell happened in the month!!!\n");
            }

            Console.WriteLine("\nBuy Day and Price:" + buyDayOfMonth + "(" + buyPrice + ")");
            Console.WriteLine("Sell Day and Price:" + sellDayOfMonth + "(" + sellPrice + ")\n\n");

            Console.WriteLine(+buyDayOfMonth + "(" + buyPrice + ")," + sellDayOfMonth + "(" + sellPrice + ")");
            Console.ReadKey();

        }

    }
}

