namespace CoffeeShop.Core.Services
{
    public interface ICoffeeShopReportGenerator
    {
        string GenerateSummaryReport(ICoffeeShop coffeeShop);
    }
}
