namespace CoffeeShop.Core.Strategies
{
    internal class DiscountCustomerCoffeeCalculator : AbstractCustomerCoffeeCalculator
    {
        public override void Calculate(ICoffeeShop coffeeShop, Customer customer)
        {
            coffeeShop.IncomeFromDrinks += coffeeShop.Drink.BasePrice * 75 / 100; 

            base.Calculate(coffeeShop, customer);
        }
    }
}
