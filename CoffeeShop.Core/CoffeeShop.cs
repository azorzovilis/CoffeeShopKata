namespace CoffeeShop.Core
{
    using System;
    using System.Collections.Generic;
    using Services;
    using Strategies;

    public class CoffeeShop : ICoffeeShop
    {
        private readonly ICoffeeShopReportGenerator _coffeeShopReportGenerator;

        //TODO: Remove drink dependency
        public CoffeeShop(IDrink drink, ICoffeeShopReportGenerator coffeeShopReportGenerator)
        {
            _coffeeShopReportGenerator = coffeeShopReportGenerator;
            Drink = drink;
            Customers = new List<Customer>();
        }

        public IDrink Drink { get; }

        public List<Customer> Customers { get; }

        public int InitialBeanCount { get; set; } = 1000;

        public decimal CostOfDrinks { get; set; }

        public decimal IncomeFromDrinks { get; set; }

        public int TotalLoyaltyPointsAccrued { get; set; }

        public int TotalLoyaltyPointsRedeemed { get; set; }

        public int BeanCount { get; set; } = 1000;


        public void AddCustomer(Customer customer)
        {
            Customers.Add(customer);
        }

        public string GetSummary()
        {
            //TODO: check if there are enough beans for coffee
            foreach (var customer in Customers)
            {
                var customerCoffeeContext = new CustomerCoffeeContext();

                switch (customer.Type)
                {
                    case CustomerType.General:
                        customerCoffeeContext.SetCustomerCoffeeCalculatorStrategy(new GeneralCustomerCoffeeCalculator());
                        break;

                    case CustomerType.LoyaltyMember:
                        customerCoffeeContext.SetCustomerCoffeeCalculatorStrategy(new LoyaltyCustomerCoffeeCalculator());
                        break;

                    case CustomerType.CoffeeEmployee:
                        customerCoffeeContext.SetCustomerCoffeeCalculatorStrategy(new EmployeeCoffeeCalculator());
                        break;

                    case CustomerType.DiscountMember:
                        customerCoffeeContext.SetCustomerCoffeeCalculatorStrategy(new DiscountCustomerCoffeeCalculator());
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                customerCoffeeContext.Calculate(this, customer);
            }

            return _coffeeShopReportGenerator.GenerateSummaryReport(this);
        }
    }
}