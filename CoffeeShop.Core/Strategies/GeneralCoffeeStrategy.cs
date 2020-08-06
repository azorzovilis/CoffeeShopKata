namespace CoffeeShop.Core.Strategies
{
    internal class GeneralCoffeeStrategy : AbstractCoffeeStrategy
    {
        public override void UpdateCoffeeShopState(ICoffeeShopState coffeeShopState, Customer customer, Drink drink)
        {
            base.UpdateCoffeeShopState(coffeeShopState, customer, drink);

            coffeeShopState.IncomeFromDrinks += drink.BasePrice;
            coffeeShopState.CoffeeSales.General++;
        }
    }
}
