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
        [InlineData(new[] { "B", "B" }, 45)]
        public void CanCalculateTotalPriceCorrectly(string[] itemCodesToScan, int expectedTotalPrice)
        {
            var itemToPriceDictionary = new Dictionary<string, PricingRules>();
            itemToPriceDictionary.Add("A", new PricingRules(50));
            itemToPriceDictionary.Add("B", new PricingRules(30) { PriceForTwo = 45 });
            var checkout = new Checkout(itemToPriceDictionary);
            foreach (var itemCode in itemCodesToScan)
            {
                checkout.Scan(itemCode);
            }
            Assert.Equal(expectedTotalPrice, checkout.GetTotalPrice());
        }
    }
}
