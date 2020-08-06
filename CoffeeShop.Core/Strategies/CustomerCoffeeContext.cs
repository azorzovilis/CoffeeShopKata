namespace CoffeeShop.Core.Strategies
{
    internal class CustomerCoffeeContext : ICustomerCoffeeContext
    {
        private ICustomerCoffeeStrategy _customerCoffeeStrategy;

        public void SetCustomerCoffeeStrategy(ICustomerCoffeeStrategy customerCoffeeStrategy)
        {
            _customerCoffeeStrategy = customerCoffeeStrategy;
        }

        public void UpdateCoffeeShopState(ICoffeeShopState coffeeShopState, Customer customer, Drink drink)
        {
            _customerCoffeeStrategy?.UpdateCoffeeShopState(coffeeShopState, customer, drink);
        }
    }
}
