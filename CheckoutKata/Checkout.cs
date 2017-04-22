﻿using System.Collections.Generic;
using System.Linq;

namespace CheckoutKata
{
    public class Checkout
    {
        private List<string> _itemCodesScanned = new List<string>();
        private Dictionary<string, PricingRules> _itemToPriceDictionary;
        public Checkout(Dictionary<string, PricingRules> itemToPriceDictionary)
        {
            _itemToPriceDictionary = itemToPriceDictionary;
        }

        internal int GetTotalPrice()
        {
            if (_itemCodesScanned.Count == 2 && _itemCodesScanned.Distinct().Count() == 1)
            {
                return _itemToPriceDictionary[_itemCodesScanned.First()].PriceForTwo;
            }
            return _itemCodesScanned.Sum(itemCode => _itemToPriceDictionary[itemCode].Price);
        }

        internal void Scan(string itemCode)
        {
            _itemCodesScanned.Add(itemCode);
        }
    }
}
