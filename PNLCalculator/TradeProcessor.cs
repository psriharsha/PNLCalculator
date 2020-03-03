using PNLCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace PNLCalculator
{
    class TradeProcessor
    {
        private List<Trade> ListOfTrades = new List<Trade>();
        public void AddTrade(Trade NewTrade)
        {
            ListOfTrades.Add(NewTrade);
        }

        public double CalculatePNL()
        {
            double pnl = 0;
            //This sorts the trades based on Underlying and then by order of entry
            ListOfTrades.Sort();
            List<Trade> ProcessedTrades = new List<Trade>();
            foreach (Trade trade in ListOfTrades)
            {
                int quantity = trade.Quantity;
                while(quantity > 0)
                {
                    //Find trades under same underlying in opposite direction
                    Trade previousTrade = ProcessedTrades.Find(x => x.Underlying.Equals(trade.Underlying)
                            && x.BuySell != trade.BuySell);
                    if (null == previousTrade)
                        break;
                    //Get minimum quantity to calculate PNL
                    int q = (quantity > previousTrade.Quantity) ? previousTrade.Quantity : quantity;
                    pnl += (q * trade.Price * Convert.ToDouble(trade.BuySell)) +
                        (q * previousTrade.Price * Convert.ToDouble(previousTrade.BuySell));
                    Console.WriteLine("(" + Convert.ToDouble(trade.BuySell) * q + "*" + trade.Price + " + "
                                + Convert.ToDouble(previousTrade.BuySell) * q + "*" + previousTrade.Price + ")");
                    quantity = quantity - q;
                    if(previousTrade.Quantity == q)
                    {
                        ProcessedTrades.Remove(previousTrade);
                    }else
                    {
                        previousTrade.Quantity -= q;
                    }
                }
                //IF a trade is not filled in current iteration save it for next iterations
                if (quantity > 0)
                {
                    trade.Quantity = quantity;
                    ProcessedTrades.Add(trade);
                }
            }
            return pnl;
        }

    }
}
