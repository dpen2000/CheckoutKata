using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CheckoutKata
{
    public class Tests
    {
        public class PricingRules
        {
            public PricingRules(int price)
            {
                Price = price;
            }
            public int Price { get; set; }
        }

        [Theory]
        [InlineData(new[] { "A" }, 50)]
        [InlineData(new[] { "B" }, 30)]
        [InlineData(new[] { "A", "B" }, 80)]
        public void CanCalculateTotalPriceCorrectly(string[] itemCodesToScan, int expectedTotalPrice)
        {
            var itemToPriceDictionary = new Dictionary<string, PricingRules>();
            itemToPriceDictionary.Add("A", new PricingRules(50));
            itemToPriceDictionary.Add("B", new PricingRules(30));
            var checkout = new Checkout(itemToPriceDictionary);
            foreach (var itemCode in itemCodesToScan)
            {
                checkout.Scan(itemCode);
            }
            Assert.Equal(expectedTotalPrice, checkout.GetTotalPrice());
        }

        private class Checkout
        {
            private List<string> _itemCodesScanned = new List<string>();
            private Dictionary<string, PricingRules> _itemToPriceDictionary;
            public Checkout(Dictionary<string, PricingRules> itemToPriceDictionary)
            {
                _itemToPriceDictionary = itemToPriceDictionary;
            }

            internal int GetTotalPrice()
            {
                return _itemCodesScanned.Sum(itemCode => _itemToPriceDictionary[itemCode].Price);
            }

            internal void Scan(string itemCode)
            {
                _itemCodesScanned.Add(itemCode);
            }
        }
    }
}
