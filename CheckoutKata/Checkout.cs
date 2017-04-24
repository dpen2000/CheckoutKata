using System.Collections.Generic;
using System.Linq;

namespace CheckoutKata
{
    public class Checkout : ICheckout
    {
        private List<string> _itemCodesScanned = new List<string>();
        private Dictionary<string, PricingRules> _itemToPriceDictionary;
        public Checkout(Dictionary<string, PricingRules> itemToPriceDictionary)
        {
            _itemToPriceDictionary = itemToPriceDictionary;
        }

        public int GetTotalPrice()
        {
            int totalPrice = 0;
            foreach (var itemToPrice in _itemToPriceDictionary)
            {
                var itemCode = itemToPrice.Key;
                var pricingRules = itemToPrice.Value;
                var specialPrice = pricingRules.SpecialPrice;
                int itemCount = _itemCodesScanned.Count(x => x == itemCode);
                if (specialPrice != null)
                {
                    var numberOfApplicationsOfDiscount = itemCount / specialPrice.UnitsForPriceToApply;
                    totalPrice += numberOfApplicationsOfDiscount * specialPrice.Price;
                    itemCount -= numberOfApplicationsOfDiscount * specialPrice.UnitsForPriceToApply;
                }
                totalPrice += itemCount * pricingRules.Price;
            }

            return totalPrice;
        }

        public void Scan(string itemCode)
        {
            _itemCodesScanned.Add(itemCode);
        }
    }
}
