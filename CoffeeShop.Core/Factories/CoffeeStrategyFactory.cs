namespace CoffeeShop.Core.Factories
{
    using System;
    using Strategies;

    public class CoffeeStrategyFactory : ICoffeeStrategyFactory
    {
        ICustomerCoffeeContext ICoffeeStrategyFactory.CreateCoffeeContext(CustomerType customerType)
        {
            ICustomerCoffeeContext customerCoffeeContext = new CustomerCoffeeContext();

            switch (customerType)
            {
                case CustomerType.General:
                    customerCoffeeContext.SetCustomerCoffeeStrategy(new GeneralCoffeeStrategy());
                    break;

                case CustomerType.LoyaltyMember:
                    customerCoffeeContext.SetCustomerCoffeeStrategy(new LoyaltyCoffeeStrategy());
                    break;

                case CustomerType.CoffeeEmployee:
                    customerCoffeeContext.SetCustomerCoffeeStrategy(new EmployeeCoffeeStrategy());
                    break;

                case CustomerType.DiscountMember:
                    customerCoffeeContext.SetCustomerCoffeeStrategy(new DiscountCoffeeStrategy());
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            return customerCoffeeContext;
        }
    }
}
