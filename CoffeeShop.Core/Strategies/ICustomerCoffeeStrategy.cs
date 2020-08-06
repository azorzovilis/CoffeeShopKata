namespace CoffeeShop.Core.Strategies
{
    public interface ICustomerCoffeeStrategy
    {
        void UpdateCoffeeShopState(ICoffeeShopState coffeeShopState, Customer customer, Drink drink);
    }
}
