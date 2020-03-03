using PNLCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PNLCalculator
{
    class Program
    {
        TradeProcessor Processor = new TradeProcessor();
        static void Main(string[] args)
        {
            (new Program()).ProcessPNL();
        }

        private void ProcessPNL()
        {
            Console.WriteLine("Enter trades as comma separated values. Eg:");
            Console.WriteLine("'Buy 1 100 Oil' for Buying 1 lot of Oil at 100");
            Console.WriteLine("'Sell 1 100 Oil' for Selling 1 lot of Oil at 100");
            Console.WriteLine("Enter 'Q' to finish entering the trades");
            try
            {
                int i = 0;
                //Enter character Q to end entries
                while (true)
                {
                    string[] data = Console.ReadLine().ToUpper().Split(' ');
                    if (data[0].Equals("Q"))
                        break;
                    Direction buySell = Direction.BUY;
                    int quantity = int.Parse(data[1]);
                    double price = double.Parse(data[2]);
                    string underlying = data[3];
                    if (data[0].Equals("SELL"))
                        buySell = Direction.SELL;
                    Trade NewTrade = new Trade()
                    {
                        BuySell = buySell,
                        Quantity = quantity,
                        Price = price,
                        Underlying = underlying,
                        TradeId = i++
                    };
                    if(NewTrade.IsTradeValid())
                        Processor.AddTrade(NewTrade);
                }
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Netted PNL = " + Processor.CalculatePNL());

            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Terminating application due to above Exception being thrown.");
            }finally
            {
                Console.ReadLine();
            }
        }
    }
}
