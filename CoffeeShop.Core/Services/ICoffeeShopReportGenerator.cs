namespace CoffeeShop.Core.Services
{
    public interface ICoffeeShopReportGenerator
    {
        string GenerateSummaryReport(ICoffeeShopState state);
    }
}
