using System.Collections.Generic;
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
            int totalPrice = 0;
            List<string> itemsRemaining = _itemCodesScanned.ToList();
            foreach (var itemToPrice in _itemToPriceDictionary)
            {
                if (itemToPrice.Value.PriceForTwo.HasValue)
                {
                    var numberOfApplicationsOfDiscount = itemsRemaining.Count(x => x == itemToPrice.Key) / 2;
                    totalPrice += numberOfApplicationsOfDiscount * itemToPrice.Value.PriceForTwo.Value;
                    foreach(var time in Enumerable.Range(0, numberOfApplicationsOfDiscount * 2))
                        itemsRemaining.Remove(itemToPrice.Key);
                }
            }

            return totalPrice + itemsRemaining.Sum(itemCode => _itemToPriceDictionary[itemCode].Price);
        }

        internal void Scan(string itemCode)
        {
            _itemCodesScanned.Add(itemCode);
        }
    }
}
