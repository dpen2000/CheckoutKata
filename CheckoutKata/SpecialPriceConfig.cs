using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata
{
    public class SpecialPriceConfig
    {
        public SpecialPriceConfig(int price, int unitsForPriceToApply)
        {
            Price = price;
            UnitsForPriceToApply = unitsForPriceToApply;
        }
        public int Price { get; private set; }
        public int UnitsForPriceToApply { get; private set; }
    }
}
