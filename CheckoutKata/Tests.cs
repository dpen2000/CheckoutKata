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
        [Theory]
        [InlineData(new[] { "A" }, 50)]
        [InlineData(new[] { "B" }, 30)]
        [InlineData(new[] { "A", "B" }, 80)]
        public void CanCalculateTotalPriceCorrectly(string[] itemCodesToScan, int expectedTotalPrice)
        {
            Dictionary<string, int> itemToPriceDictionary = new Dictionary<string, int>();
            itemToPriceDictionary.Add("A", 50);
            itemToPriceDictionary.Add("B", 30);
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
            private Dictionary<string, int> _itemToPriceDictionary;
            public Checkout(Dictionary<string, int> itemToPriceDictionary)
            {
                _itemToPriceDictionary = itemToPriceDictionary;
            }

            internal int GetTotalPrice()
            {
                return _itemCodesScanned.Sum(itemCode => _itemToPriceDictionary[itemCode]);
            }

            internal void Scan(string itemCode)
            {
                _itemCodesScanned.Add(itemCode);
            }
        }
    }
}
