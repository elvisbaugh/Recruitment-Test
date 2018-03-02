namespace GiftAidCalculator.TestConsole.Service
{
    public class TaxRateProvider : ITaxRateProvider
    {
        public decimal GetTaxRate() => 20;
    }
}