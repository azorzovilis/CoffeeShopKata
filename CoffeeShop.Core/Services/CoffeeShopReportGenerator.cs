namespace CoffeeShop.Core.Services
{
    using System;
    using System.Configuration;
    using System.Text;
    using Extensions;

    public class CoffeeShopReportGenerator : ICoffeeShopReportGenerator
    {
        public string GenerateSummaryReport(ICoffeeShopState state)
        {
            var initialBeanCount = int.TryParse(ConfigurationManager.AppSettings["InitialBeanCount"], out var beanCount) ? beanCount : 1000;
            var profit = state.IncomeFromDrinks - state.CostOfDrinks;

            var sb = new StringBuilder("Coffee Shop Summary")
                .AppendLine(Environment.NewLine)
                
                .AppendLine("Total customers: " + state.CoffeeSales.TotalSales)
                .AppendLine("General sales: ".Indent() + state.CoffeeSales.General)
                .AppendLine("Loyalty member sales: ".Indent() + state.CoffeeSales.Loyalty)
                .AppendLine("Discount sales: ".Indent() + state.CoffeeSales.Discount)
                .AppendLine("Employee Complimentary: ".Indent() + state.CoffeeSales.Complimentary + Environment.NewLine)
                
                .AppendLine("Total revenue from drinks: " + state.IncomeFromDrinks)
                .AppendLine("Total costs from drinks: " + state.CostOfDrinks)

                .AppendLine(profit > 0
                    ? "Coffee Shop generating profit of: " + profit + Environment.NewLine
                    : "Coffee Shop losing money of: " + profit + Environment.NewLine)

                .AppendLine("Total loyalty points given away: " + state.TotalLoyaltyPointsAccrued)
                .AppendLine("Total loyalty points redeemed: " + state.TotalLoyaltyPointsRedeemed + Environment.NewLine)

                .AppendLine("Beans used: " + (initialBeanCount - state.BeanCount))
                .AppendLine("Beans remaining: " + state.BeanCount + Environment.NewLine)

                .Append(profit > 20 && state.BeanCount > (initialBeanCount * 25) / 100
                    ? "Coffee Shop will open tomorrow"
                    : "Coffee Shop will not open tomorrow");

            return sb.ToString();
        }
    }
}
