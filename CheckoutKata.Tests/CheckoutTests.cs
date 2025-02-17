﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CheckoutKata.Tests
{
    public class CheckoutTests
    {
        [Theory]
        [InlineData(new[] { "A" }, 50)]
        [InlineData(new[] { "B" }, 30)]
        [InlineData(new[] { "A", "B" }, 80)]
        [InlineData(new[] { "B", "B" }, 45)]
        [InlineData(new[] { "C", "C" }, 40)]
        [InlineData(new[] { "B", "B", "C" }, 65)]
        [InlineData(new[] { "A", "A", "A"}, 130)]
        [InlineData(new[] { "B", "A", "B" }, 95)]
        [InlineData(new[] { "D" }, 15)]
        public void CanCalculateTotalPriceCorrectly(string[] itemCodesToScan, int expectedTotalPrice)
        {
            var itemToPriceDictionary = new Dictionary<string, PricingRules>();
            itemToPriceDictionary.Add("A", new PricingRules(50) { SpecialPrice = new SpecialPriceConfig(130, 3) });
            itemToPriceDictionary.Add("B", new PricingRules(30) { SpecialPrice = new SpecialPriceConfig(45, 2) });
            itemToPriceDictionary.Add("C", new PricingRules(20));
            itemToPriceDictionary.Add("D", new PricingRules(15));
            var checkout = new Checkout(itemToPriceDictionary);
            foreach (var itemCode in itemCodesToScan)
            {
                checkout.Scan(itemCode);
            }
            Assert.Equal(expectedTotalPrice, checkout.GetTotalPrice());
        }
    }
}
