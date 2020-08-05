namespace CoffeeShop.Core.Strategies
{
    internal class GeneralCustomerCoffeeCalculator : AbstractCustomerCoffeeCalculator
    {
        public override void Calculate(ICoffeeShop coffeeShop, Customer customer)
        {
            coffeeShop.IncomeFromDrinks += coffeeShop.Drink.BasePrice;

            base.Calculate(coffeeShop, customer);
        }
    }
}
