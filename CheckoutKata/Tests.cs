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
            var checkout = new Checkout();
            checkout.Scan(itemCode);
            Assert.Equal(expectedTotalPrice, checkout.GetTotalPrice());
        }

        private class Checkout
        {
            private string _itemCode;
            public Checkout()
            {
            }

            internal int GetTotalPrice()
            {
                if (_itemCode == "B")
                    return 30;
                return 50;
            }

            internal void Scan(string itemCode)
            {
                _itemCode = itemCode;
            }
        }
    }
}
