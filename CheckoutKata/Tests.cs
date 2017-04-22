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
        }

        private class Checkout
        {
            public Checkout()
            {
            }
        }
    }
}
