namespace CoffeeShop.Core.Factories
{
    using Strategies;

    public interface ICoffeeStrategyFactory
    {
        ICustomerCoffeeContext CreateCoffeeContext(CustomerType customerType);
    }
}
