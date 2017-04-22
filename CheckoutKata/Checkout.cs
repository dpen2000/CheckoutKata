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
                var itemCode = itemToPrice.Key;
                var pricingRules = itemToPrice.Value;
                var specialPrice = pricingRules.SpecialPrice;
                if (specialPrice != null)
                {
                    var numberOfApplicationsOfDiscount = itemsRemaining.Count(x => x == itemCode) / specialPrice.UnitsForPriceToApply;
                    totalPrice += numberOfApplicationsOfDiscount * specialPrice.Price;
                    foreach (var time in Enumerable.Range(0, numberOfApplicationsOfDiscount * specialPrice.UnitsForPriceToApply))
                    {
                        itemsRemaining.Remove(itemCode);
                    }
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
