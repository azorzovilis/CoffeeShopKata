namespace CoffeeShop.Core.Strategies
{
    using CustomExceptions;

    internal class AbstractCoffeeStrategy : ICustomerCoffeeStrategy
    {
        public virtual void UpdateCoffeeShopState(ICoffeeShopState coffeeShopState, Customer customer, Drink drink)
        {
            if (coffeeShopState.BeanCount < drink.BeansPerCap)
            {
                throw new OutOfCoffeeBeansException(drink.Title, customer.Name);
            }

            coffeeShopState.CostOfDrinks += drink.BaseCost;
            coffeeShopState.BeanCount -= drink.BeansPerCap;
        }
    }
}