using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PNLCalculator.Models
{
    class Trade : IComparable
    {
        [Required]
        public int TradeId { get; set; }
        [Required]
        public Direction BuySell { get; set; }
        [Required]
        [Range(1,int.MaxValue)]
        public int Quantity { get; set; }
        [Required]
        [Range(0,double.MaxValue)]
        public double Price { get; set; }
        [Required]
        public string Underlying { get; set; }

        public bool IsTradeValid()
        {
            var context = new ValidationContext(this);
            var isValid = Validator.TryValidateObject(this, context, null, true);
            if (isValid)
            {
                isValid = Enum.IsDefined(typeof(Direction), BuySell);
            }
            return isValid;
        }

        public int CompareTo(object obj)
        {
            Trade otherTradeObj = (Trade)obj;
            int rank = Underlying.CompareTo(otherTradeObj.Underlying);
            if (rank == 0)
            {
                rank = TradeId.CompareTo(otherTradeObj.TradeId);
            }
            return rank;
        }
    }

    enum Direction
    {
        BUY = -1,
        SELL = 1
    }
}
