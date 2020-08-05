namespace CoffeeShop.Core.Strategies
{
    using System;

    internal class LoyaltyCustomerCoffeeCalculator : AbstractCustomerCoffeeCalculator
    {
        public override void Calculate(ICoffeeShop coffeeShop, Customer customer)
        {
            if (customer.IsUsingLoyaltyPoints)
            {
                int loyaltyPointsRedeemed = Convert.ToInt32(Math.Ceiling(coffeeShop.Drink.BasePrice));
                customer.LoyaltyPoints -= loyaltyPointsRedeemed;
                coffeeShop.TotalLoyaltyPointsRedeemed += loyaltyPointsRedeemed;
            }
            else
            {
                coffeeShop.TotalLoyaltyPointsAccrued += coffeeShop.Drink.LoyaltyPointsGained;
                coffeeShop.IncomeFromDrinks += coffeeShop.Drink.BasePrice;
            }

            base.Calculate(coffeeShop, customer);
        }
    }
}