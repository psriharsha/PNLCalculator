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
    class TradeTests
    {
        [Test]
        public void IsTradeValid_EmptyTrade_ReturnsFalse()
        {
            Trade NewTrade = new Trade();
            bool isValid = NewTrade.IsTradeValid();
            //Should return false as Quantity = 0 and Underlying is NULL (default values)
            Assert.IsFalse(isValid);
        }
        [Test]
        public void IsTradeValid_NegativeQuantity_ReturnsFalse()
        {
            Trade NewTrade = new Trade()
            {
                Quantity = -5,
                Price = 100,
                Underlying = "Oil"
            };
            bool isValid = NewTrade.IsTradeValid();
            Assert.IsFalse(isValid);
        }
        [Test]
        public void IsTradeValid_ZeroQuantity_ReturnsFalse()
        {
            Trade NewTrade = new Trade()
            {
                Quantity = 0,
                Price = 100,
                Underlying = "Oil"
            };
            bool isValid = NewTrade.IsTradeValid();
            Assert.IsFalse(isValid);
        }
        [Test]
        public void IsTradeValid_MaximumQuantity_ReturnsFalse()
        {
            Trade NewTrade = new Trade()
            {
                Quantity = int.MaxValue,
                Price = 100,
                Underlying = "Oil"
            };
            NewTrade.Quantity += 1;
            bool isValid = NewTrade.IsTradeValid();
            Assert.IsFalse(isValid);
        }
        [Test]
        public void IsTradeValid_NegativePrice_ReturnsFalse()
        {
            Trade NewTrade = new Trade()
            {
                Quantity = 5,
                Price = -1,
                Underlying = "Oil"
            };
            bool isValid = NewTrade.IsTradeValid();
            Assert.IsFalse(isValid);
        }
        [Test]
        public void IsTradeValid_NullUnderLying_ReturnsFalse()
        {
            Trade NewTrade = new Trade()
            {
                Quantity = 5,
                Price = 100,
                Underlying = null
            };
            bool isValid = NewTrade.IsTradeValid();
            Assert.IsFalse(isValid);
        }
    }
}
