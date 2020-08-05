namespace CoffeeShop.Core.Strategies
{
    internal class CustomerCoffeeContext
    {
        private ICustomerCoffeeCalculator _customerCoffeeCalculator;

        public void SetCustomerCoffeeCalculatorStrategy(ICustomerCoffeeCalculator customerCoffeeCalculator)
        {
            _customerCoffeeCalculator = customerCoffeeCalculator;
        }

        public void Calculate(ICoffeeShop coffeeShop, Customer customer)
        {
            _customerCoffeeCalculator?.Calculate(coffeeShop, customer);
        }
    }
}
