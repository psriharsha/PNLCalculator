using NUnit.Framework;
using PNLCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PNLCalculator.UnitTests
{
    [TestFixture]
    class TradeProcessorTests
    {
        [Test]
        public void Example1_Returns0()
        {
            TradeProcessor tradeProcessor = new TradeProcessor();
            tradeProcessor.AddTrade(new Trade()
            {
                BuySell = Direction.BUY,
                Quantity = 2,
                Price = 100,
                Underlying = "Oil",
                TradeId = 0
            });
            tradeProcessor.AddTrade(new Trade()
            {
                BuySell = Direction.BUY,
                Quantity = 2,
                Price = 110,
                Underlying = "Oil",
                TradeId = 1
            });
            tradeProcessor.AddTrade(new Trade()
            {
                BuySell = Direction.BUY,
                Quantity = 3,
                Price = 102,
                Underlying = "Oil",
                TradeId = 2
            });
            double netPNL = tradeProcessor.CalculatePNL();
            Assert.AreEqual(netPNL, 0d);
        }
        [Test]
        public void Example2_Returns20()
        {
            TradeProcessor tradeProcessor = new TradeProcessor();
            tradeProcessor.AddTrade(new Trade()
            {
                BuySell = Direction.BUY,
                Quantity = 2,
                Price = 100,
                Underlying = "Oil",
                TradeId = 0
            });
            tradeProcessor.AddTrade(new Trade()
            {
                BuySell = Direction.SELL,
                Quantity = 2,
                Price = 110,
                Underlying = "Oil",
                TradeId = 1
            });
            double netPNL = tradeProcessor.CalculatePNL();
            Assert.AreEqual(netPNL, 20d);
        }
        [Test]
        public void Example3_Returns10()
        {
            TradeProcessor tradeProcessor = new TradeProcessor();
            tradeProcessor.AddTrade(new Trade()
            {
                BuySell = Direction.BUY,
                Quantity = 1,
                Price = 100,
                Underlying = "Oil",
                TradeId = 0
            });
            tradeProcessor.AddTrade(new Trade()
            {
                BuySell = Direction.SELL,
                Quantity = 4,
                Price = 110,
                Underlying = "Oil",
                TradeId = 1
            });
            double netPNL = tradeProcessor.CalculatePNL();
            Assert.AreEqual(netPNL, 10.0);
        }
        [Test]
        public void Example4_ReturnsMinus20()
        {
            TradeProcessor tradeProcessor = new TradeProcessor();
            tradeProcessor.AddTrade(new Trade()
            {
                BuySell = Direction.BUY, Quantity = 1, Price = 100, Underlying = "Oil", TradeId = 0
            });
            tradeProcessor.AddTrade(new Trade()
            {
                BuySell = Direction.SELL, Quantity = 4, Price = 110, Underlying = "Oil", TradeId = 1
            });
            tradeProcessor.AddTrade(new Trade()
            {
                BuySell = Direction.BUY, Quantity = 4, Price = 120, Underlying = "Oil", TradeId = 2
            });
            double netPNL = tradeProcessor.CalculatePNL();
            Assert.AreEqual(netPNL, -20d);
        }
        [Test]
        public void Example5_ReturnsMinus5()
        {
            TradeProcessor tradeProcessor = new TradeProcessor();
            tradeProcessor.AddTrade(new Trade()
            {
                BuySell = Direction.BUY,
                Quantity = 1,
                Price = 100,
                Underlying = "Oil",
                TradeId = 0
            });
            tradeProcessor.AddTrade(new Trade()
            {
                BuySell = Direction.SELL,
                Quantity = 4,
                Price = 110,
                Underlying = "Gas",
                TradeId = 1
            });
            tradeProcessor.AddTrade(new Trade()
            {
                BuySell = Direction.BUY,
                Quantity = 2,
                Price = 120,
                Underlying = "Gas",
                TradeId = 2
            });
            tradeProcessor.AddTrade(new Trade()
            {
                BuySell = Direction.SELL,
                Quantity = 5,
                Price = 115,
                Underlying = "Oil",
                TradeId = 2
            });
            double netPNL = tradeProcessor.CalculatePNL();
            Assert.AreEqual(netPNL, -5d);
        }
        ///Custom test for 2 Buys and 1 Sell
        public void TwoBuysOneSell_Returns10()
        {
            TradeProcessor tradeProcessor = new TradeProcessor();
            tradeProcessor.AddTrade(new Trade()
            {
                BuySell = Direction.BUY,
                Quantity = 1,
                Price = 100,
                Underlying = "Oil",
                TradeId = 0
            });
            tradeProcessor.AddTrade(new Trade()
            {
                BuySell = Direction.BUY,
                Quantity = 4,
                Price = 110,
                Underlying = "Oil",
                TradeId = 1
            });
            tradeProcessor.AddTrade(new Trade()
            {
                BuySell = Direction.SELL,
                Quantity = 4,
                Price = 110,
                Underlying = "Oil",
                TradeId = 2
            });
            double netPNL = tradeProcessor.CalculatePNL();
            //(-1 * 100 + 1 * 100) + (-3 * 110 + 3 * 110)
            Assert.AreEqual(netPNL, 10d);
        }

    }
}
