namespace CoffeeShop.Core
{
    using System;
    using System.Collections.Generic;
    using CustomExceptions;
    using Factories;
    using Services;

    public class CoffeeShop : ICoffeeShop
    {
        private readonly ICoffeeShopReportGenerator _coffeeShopReportGenerator;
        private readonly ICoffeeStrategyFactory _coffeeStrategyFactory;
        private readonly ICoffeeShopState _coffeeShopState;

        public CoffeeShop(ICoffeeShopReportGenerator coffeeShopReportGenerator, 
            ICoffeeStrategyFactory coffeeStrategyFactory,
            ICoffeeShopState coffeeShopState)
        {
            _coffeeShopReportGenerator = coffeeShopReportGenerator;
            _coffeeStrategyFactory = coffeeStrategyFactory;
            _coffeeShopState = coffeeShopState;

            Customers = new List<Customer>();
        }

        public List<Customer> Customers { get; }

        public void AddCustomer(Customer customer)
        {
            Customers.Add(customer);
        }

        public string GetSummary()
        {
            foreach (var customer in Customers)
            {
                try
                {
                    var customerCoffeeContext = _coffeeStrategyFactory.CreateCoffeeContext(customer.Type);

                    foreach (var drink in customer.Drinks)
                    {
                        customerCoffeeContext.UpdateCoffeeShopState(_coffeeShopState, customer, drink);
                    }

                }
                catch (OutOfCoffeeBeansException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return _coffeeShopReportGenerator.GenerateSummaryReport(_coffeeShopState);
        }
    }
}