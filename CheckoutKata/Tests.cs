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
        [InlineData("A", 50)]
        [InlineData("B", 30)]
        public void SingleItemsCanBePriced(string itemCode, int expectedTotalPrice)
        {
            Dictionary<char, int> itemToPriceDictionary = new Dictionary<char, int>();
            itemToPriceDictionary.Add('A', 50);
            itemToPriceDictionary.Add('B', 30);
            var checkout = new Checkout(itemToPriceDictionary);
            checkout.Scan(itemCode);
            Assert.Equal(expectedTotalPrice, checkout.GetTotalPrice());
        }

        private class Checkout
        {
            private string _itemCode;
            private Dictionary<char, int> _itemToPriceDictionary;
            public Checkout(Dictionary<char, int> itemToPriceDictionary)
            {
                _itemToPriceDictionary = itemToPriceDictionary;
            }

            internal int GetTotalPrice()
            {
                return _itemToPriceDictionary[_itemCode.First()];
            }

            internal void Scan(string itemCode)
            {
                _itemCode = itemCode;
            }
        }
    }
}
