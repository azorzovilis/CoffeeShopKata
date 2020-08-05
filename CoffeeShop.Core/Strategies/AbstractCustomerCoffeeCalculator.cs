namespace CoffeeShop.Core.Strategies
{
    internal class AbstractCustomerCoffeeCalculator : ICustomerCoffeeCalculator
    {
        public virtual void Calculate(ICoffeeShop coffeeShop, Customer customer)
        {
            coffeeShop.CostOfDrinks += coffeeShop.Drink.BaseCost;
            coffeeShop.BeanCount -= 150;
        }
    }
}
