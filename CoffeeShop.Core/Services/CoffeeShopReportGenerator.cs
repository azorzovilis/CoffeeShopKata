namespace CoffeeShop.Core.Services
{
    using System;
    using System.Linq;
    using System.Text;
    using Extensions;

    public class CoffeeShopReportGenerator : ICoffeeShopReportGenerator
    {
        public string GenerateSummaryReport(ICoffeeShop coffeeShop)
        {
            var profit = coffeeShop.IncomeFromDrinks - coffeeShop.CostOfDrinks;

            var sb = new StringBuilder("Coffee Shop Summary")
                .AppendLine(Environment.NewLine)
                
                .AppendLine("Total customers: " + coffeeShop.Customers.Count)
                .AppendLine("General sales: ".Indent() + coffeeShop.Customers.Count(p => p.Type == CustomerType.General))
                .AppendLine("Loyalty member sales: ".Indent() +
                            coffeeShop.Customers.Count(p => p.Type == CustomerType.LoyaltyMember))
                .AppendLine("Employee Complimentary: ".Indent() +
                            coffeeShop.Customers.Count(p => p.Type == CustomerType.CoffeeEmployee) + Environment.NewLine)
                
                .AppendLine("Total revenue from drinks: " + coffeeShop.IncomeFromDrinks)
                .AppendLine("Total costs from drinks: " + coffeeShop.CostOfDrinks)

                .AppendLine(profit > 0
                    ? "Coffee Shop generating profit of: " + profit + Environment.NewLine
                    : "Coffee Shop losing money of: " + profit + Environment.NewLine)

                .AppendLine("Total loyalty points given away: " + coffeeShop.TotalLoyaltyPointsAccrued)
                .AppendLine("Total loyalty points redeemed: " + coffeeShop.TotalLoyaltyPointsRedeemed + Environment.NewLine)

                .AppendLine("Beans used: " + (coffeeShop.InitialBeanCount - coffeeShop.BeanCount))
                .AppendLine("Beans remaining: " + coffeeShop.BeanCount + Environment.NewLine)

                .Append(profit > 20 && coffeeShop.BeanCount > (coffeeShop.InitialBeanCount * 25) / 100
                    ? "Coffee Shop will open tomorrow"
                    : "Coffee Shop will not open tomorrow");

            return sb.ToString();
        }
    }
}
