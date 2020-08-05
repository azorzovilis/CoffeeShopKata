namespace CoffeeShop.Core.UnitTests
{
    using Moq;
    using NUnit.Framework;
    using System;
    using System.Linq;
    using Services;

    //TODO: This test should become an integration test
    public class CoffeeShopTests
    {
        private readonly IDrink _drink = Mock.Of<IDrink>();
        private ICoffeeShop _itemUnderTest;

        [Test]
        public void GivenCoffeeShop_WhenCallingAddCustomer_ThenCustomerIsAddedInTheShop()
        {
            _itemUnderTest = GivenCoffeeShop();

            var customer = new Customer { Name = "Artemis" };

            _itemUnderTest.AddCustomer(customer);

            Assert.AreEqual(8, _itemUnderTest.Customers.Count);
            Assert.AreEqual("Artemis", _itemUnderTest.Customers.Single(c => c.Name == "Artemis").Name);
        }

        [Test]
        public void GivenCoffeeShop_WhenCallingGetSummary_ThenSummaryStringShouldBeReturned()
        {
            _itemUnderTest = GivenCoffeeShop();

            var result = _itemUnderTest.GetSummary();

            Assert.AreEqual(
                "Coffee Shop Summary" + Environment.NewLine + Environment.NewLine +
                "Total customers: 7" + Environment.NewLine +
                "    General sales: 3" + Environment.NewLine +
                "    Loyalty member sales: 3" + Environment.NewLine +
                "    Employee Complimentary: 1" + Environment.NewLine + Environment.NewLine +
                "Total revenue from drinks: 500" + Environment.NewLine +
                "Total costs from drinks: 350" + Environment.NewLine +
                "Coffee Shop generating profit of: 150" + Environment.NewLine + Environment.NewLine +
                "Total loyalty points given away: 10" + Environment.NewLine +
                "Total loyalty points redeemed: 100" + Environment.NewLine + Environment.NewLine +
                "Beans used: 1050" + Environment.NewLine +
                "Beans remaining: -50" + Environment.NewLine + Environment.NewLine +
                "Coffee Shop will not open tomorrow",
                result);
        }

        [Test]
        public void GivenEmptyCoffeeShop_WhenCallingGetSummary_ThenSummaryStringShouldBeReturned()
        {
            _itemUnderTest = GivenEmptyCoffeeShop();

            var result = _itemUnderTest.GetSummary();

            Assert.AreEqual(
                    "Coffee Shop Summary" + Environment.NewLine + Environment.NewLine +
                            "Total customers: 0" + Environment.NewLine +
                            "    General sales: 0" + Environment.NewLine +
                            "    Loyalty member sales: 0" + Environment.NewLine +
                            "    Employee Complimentary: 0" + Environment.NewLine + Environment.NewLine +
                            "Total revenue from drinks: 0" + Environment.NewLine +
                            "Total costs from drinks: 0" + Environment.NewLine +
                            "Coffee Shop losing money of: 0" + Environment.NewLine + Environment.NewLine +
                            "Total loyalty points given away: 0" + Environment.NewLine +
                            "Total loyalty points redeemed: 0" + Environment.NewLine + Environment.NewLine +
                            "Beans used: 0" + Environment.NewLine +
                            "Beans remaining: 1000" + Environment.NewLine + Environment.NewLine +
                            "Coffee Shop will not open tomorrow",
                    result);
        }

        private ICoffeeShop GivenCoffeeShop()
        {
            var drink = Mock.Of<IDrink>(d =>
                d.Title == "Americano" && d.BaseCost == 50 && d.BasePrice == 100 && d.LoyaltyPointsGained == 5);

            var coffeeShop = new CoffeeShop(drink, new CoffeeShopReportGenerator());

            coffeeShop.AddCustomer(new Customer { Name = "Christopher", Type = CustomerType.General });
            coffeeShop.AddCustomer(new Customer { Name = "Damian", Type = CustomerType.LoyaltyMember, LoyaltyPoints = 1000, IsUsingLoyaltyPoints = true });
            coffeeShop.AddCustomer(new Customer { Name = "Craig", Type = CustomerType.LoyaltyMember, LoyaltyPoints = 0, IsUsingLoyaltyPoints = false });
            coffeeShop.AddCustomer(new Customer { Name = "Kirsty", Type = CustomerType.LoyaltyMember, LoyaltyPoints = 60, IsUsingLoyaltyPoints = false });
            coffeeShop.AddCustomer(new Customer { Name = "Andrzej", Type = CustomerType.CoffeeEmployee });
            coffeeShop.AddCustomer(new Customer { Name = "Matt", Type = CustomerType.General });
            coffeeShop.AddCustomer(new Customer { Name = "Colin", Type = CustomerType.General });

            return coffeeShop;
        }

        private ICoffeeShop GivenEmptyCoffeeShop()
        {
            return new CoffeeShop(_drink, new CoffeeShopReportGenerator());
        }
    }
}