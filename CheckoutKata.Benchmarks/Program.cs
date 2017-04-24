using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata.Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<CheckoutKataBenchmark>();
        }
    }
    [MemoryDiagnoser]
    public class CheckoutKataBenchmark
    {
        Dictionary<string, PricingRules> _itemToPriceDictionary;
        public CheckoutKataBenchmark()
        {
            _itemToPriceDictionary = new Dictionary<string, PricingRules>();
            _itemToPriceDictionary.Add("A", new PricingRules(50) { SpecialPrice = new SpecialPriceConfig(130, 3) });
            _itemToPriceDictionary.Add("B", new PricingRules(30) { SpecialPrice = new SpecialPriceConfig(45, 2) });
            _itemToPriceDictionary.Add("C", new PricingRules(20));
            _itemToPriceDictionary.Add("D", new PricingRules(15));
        }

        [Benchmark(Baseline = true)]
        public int RunLegacy()
        {
            var checkout = new CheckoutLegacy(_itemToPriceDictionary);
            return InnerBenchmark(checkout);
        }

        private static int InnerBenchmark(ICheckout checkout)
        {
            foreach (var time in Enumerable.Range(1, 1000))
            {
                checkout.Scan("A");
            }
            return checkout.GetTotalPrice();
        }

        [Benchmark]
        public int RunNew()
        {
            var checkout = new Checkout(_itemToPriceDictionary);
            return InnerBenchmark(checkout);
        }

        [Benchmark]
        public int RunNewNew()
        {
            var checkout = new FutureCheckout(_itemToPriceDictionary);
            return InnerBenchmark(checkout);
        }
    }
}
