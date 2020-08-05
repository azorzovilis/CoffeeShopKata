namespace CoffeeShop.Core.Strategies
{
    internal class EmployeeCoffeeCalculator : AbstractCustomerCoffeeCalculator
    {
        public override void Calculate(ICoffeeShop coffeeShop, Customer customer)
        {
            //TODO Add employee new functionality

            base.Calculate(coffeeShop, customer);
        }
    }
}