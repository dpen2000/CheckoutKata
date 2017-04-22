namespace CheckoutKata
{
    public class PricingRules
    {
        public PricingRules(int price) => Price = price;
        public int Price { get; set; }
        public SpecialPriceConfig SpecialPrice { get; set; }
    }
}
