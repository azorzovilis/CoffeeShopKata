namespace CoffeeShop.Core.Strategies
{
    internal class DiscountCoffeeStrategy : AbstractCoffeeStrategy
    {
        public override void UpdateCoffeeShopState(ICoffeeShopState coffeeShopState, Customer customer, Drink drink)
        {
            base.UpdateCoffeeShopState(coffeeShopState, customer, drink);

            coffeeShopState.IncomeFromDrinks += drink.BasePrice * 75 / 100;
            coffeeShopState.CoffeeSales.Discount++;
        }
    }
}
