namespace CoffeeShop.Core
{
    using System.Configuration;

    public class CoffeeShopState : ICoffeeShopState
    {
        public CoffeeShopState()
        {
            BeanCount = int.TryParse(ConfigurationManager.AppSettings["InitialBeanCount"], out var beanCount) ? beanCount : 1000;

            CoffeeSales = new CoffeeSales();
        }

        public decimal CostOfDrinks { get; set; }

        public decimal IncomeFromDrinks { get; set; }

        public int TotalLoyaltyPointsAccrued { get; set; }

        public int TotalLoyaltyPointsRedeemed { get; set; }

        public int BeanCount { get; set; }

        public CoffeeSales CoffeeSales { get; internal set; }
    }
}