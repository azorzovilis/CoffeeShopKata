namespace CoffeeShop.Core.Strategies
{
    public interface ICustomerCoffeeCalculator
    {
        void Calculate(ICoffeeShop coffeeShop, Customer customer);
    }
}
