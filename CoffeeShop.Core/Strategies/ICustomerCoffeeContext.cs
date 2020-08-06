namespace CoffeeShop.Core.Strategies
{
    public interface ICustomerCoffeeContext
    {
        void SetCustomerCoffeeStrategy(ICustomerCoffeeStrategy customerCoffeeStrategy);

        void UpdateCoffeeShopState(ICoffeeShopState coffeeShop, Customer customer, Drink drink);
    }
}
