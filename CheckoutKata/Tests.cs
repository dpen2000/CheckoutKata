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
        [Fact]
        public void IfAIsScanned_TotalPriceIs50()
        {
            var checkout = new Checkout();
            checkout.Scan("A");
            Assert.Equal(50, checkout.GetTotalPrice());
        }

        [Fact]
        public void IfBIsScanned_TotalPriceIs30()
        {
            var checkout = new Checkout();
            checkout.Scan("B");
            Assert.Equal(30, checkout.GetTotalPrice());
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
