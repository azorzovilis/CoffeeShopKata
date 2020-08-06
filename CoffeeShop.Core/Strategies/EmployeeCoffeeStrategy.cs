namespace CoffeeShop.Core.Strategies
{
    internal class EmployeeCoffeeStrategy : AbstractCoffeeStrategy
    {
        public override void UpdateCoffeeShopState(ICoffeeShopState coffeeShopState, Customer customer, Drink drink)
        {
            base.UpdateCoffeeShopState(coffeeShopState, customer, drink);

            var profit = coffeeShopState.IncomeFromDrinks - coffeeShopState.CostOfDrinks;

            if (profit >= 50 && customer.NumberOfComplimentaryDrinks > 0)
            {
                customer.NumberOfComplimentaryDrinks--;
                coffeeShopState.CoffeeSales.Complimentary++;
            }
            else
            {
                coffeeShopState.IncomeFromDrinks += drink.BasePrice;
                coffeeShopState.CoffeeSales.General++;
            }
        }
    }
}