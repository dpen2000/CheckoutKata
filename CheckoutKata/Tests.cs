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
        public void Test()
        {
            var checkout = new Checkout();
            checkout.Scan("A");
            Assert.Equal(50, checkout.GetTotalPrice());
        }

        private class Checkout
        {
            public Checkout()
            {
            }

            internal int GetTotalPrice()
            {
                return 0;
            }

            internal void Scan(string v)
            {

            }
        }
    }
}
