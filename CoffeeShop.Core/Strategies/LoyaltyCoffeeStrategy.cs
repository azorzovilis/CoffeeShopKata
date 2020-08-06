namespace CoffeeShop.Core.Strategies
{
    using System;

    internal class LoyaltyCoffeeStrategy : AbstractCoffeeStrategy
    {
        public override void UpdateCoffeeShopState(ICoffeeShopState coffeeShopState, Customer customer, Drink drink)
        {
            base.UpdateCoffeeShopState(coffeeShopState, customer, drink);

            if (customer.IsUsingLoyaltyPoints)
            {
                var loyaltyPointsRedeemed = Convert.ToInt32(Math.Ceiling(drink.BasePrice));
                customer.LoyaltyPoints -= loyaltyPointsRedeemed;
                coffeeShopState.TotalLoyaltyPointsRedeemed += loyaltyPointsRedeemed;
            }
            else
            {
                coffeeShopState.TotalLoyaltyPointsAccrued += drink.LoyaltyPointsGained;
                coffeeShopState.IncomeFromDrinks += drink.BasePrice;
            }

            coffeeShopState.CoffeeSales.Loyalty++;
        }
    }
}