namespace CoffeeShop.Core.UnitTests
{
    using System.Collections.Generic;
    using Moq;
    using NUnit.Framework;
    using Factories;
    using Services;
    using Strategies;

    public class CoffeeShopTests
    {
        private readonly ICoffeeStrategyFactory _coffeeStrategyFactory = Mock.Of<ICoffeeStrategyFactory>();
        private readonly ICoffeeShopReportGenerator _coffeeShopReportGenerator = Mock.Of<ICoffeeShopReportGenerator>();
        private readonly ICoffeeShopState _coffeeShopState = Mock.Of<ICoffeeShopState>();
        private readonly ICustomerCoffeeContext _customerCoffeeContext = Mock.Of<ICustomerCoffeeContext>();

        private ICoffeeShop _itemUnderTest;

        [Test]
        public void GivenCoffeeShop_WhenCallingGetSummary_ThenSummaryIsReturned()
        {
            _itemUnderTest = GivenCoffeeShopWithCustomers();

            var result = _itemUnderTest.GetSummary();

            Assert.IsNotEmpty(result);
            Mock.Get(_coffeeShopReportGenerator).Verify(c => c.GenerateSummaryReport(_coffeeShopState), Times.Once);
        }

        private ICoffeeShop GivenCoffeeShopWithCustomers()
        {
            Mock.Get(_coffeeStrategyFactory).Setup(s => s.CreateCoffeeContext(It.IsAny<CustomerType>())).Returns(_customerCoffeeContext);
            Mock.Get(_coffeeShopReportGenerator).Setup(s => s.GenerateSummaryReport(It.IsAny<ICoffeeShopState>())).Returns("My coffee shop summary");

            var coffeeShop = new CoffeeShop(_coffeeShopReportGenerator, _coffeeStrategyFactory, _coffeeShopState);

            coffeeShop.AddCustomer(new Customer
            {
                Name = "Christopher",
                Type = CustomerType.General,
                Drinks = new List<Drink>
                {
                    new Drink("Americano") { BaseCost = 50, BasePrice = 100, LoyaltyPointsGained = 5 }
                }
            });

            coffeeShop.AddCustomer(new Customer
            {
                Name = "Kirsty",
                Type = CustomerType.LoyaltyMember,
                LoyaltyPoints = 60,
                IsUsingLoyaltyPoints = false,
                Drinks = new List<Drink> {
                    new Drink("Latte") { BaseCost = 50, BasePrice = 100, LoyaltyPointsGained = 5 },
                    new Drink("Espresso") { BaseCost = 30, BasePrice = 60, LoyaltyPointsGained = 3 }
                }
            });

            return coffeeShop;
        }
    }
}