namespace CoffeeShop.Core
{
    public interface ICoffeeShopState
    {
        decimal CostOfDrinks { get; set; }

        decimal IncomeFromDrinks { get; set; }

        int TotalLoyaltyPointsAccrued { get; set; }

        int TotalLoyaltyPointsRedeemed { get; set; }

        int BeanCount { get; set; }

        CoffeeSales CoffeeSales { get; }
    }
}