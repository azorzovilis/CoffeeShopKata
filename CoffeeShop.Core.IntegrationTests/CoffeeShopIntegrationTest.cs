namespace CoffeeShop.Core.IntegrationTests
{
    using System;
    using System.Collections.Generic;
    using Factories;
    using Services;
    using NUnit.Framework;

    public class CoffeeShopIntegrationTest
    {
        private ICoffeeShop _itemUnderTest;

        [Test]
        public void GivenCoffeeShop_WhenCallingGetSummary_ThenSummaryStringShouldBeReturned()
        {
            _itemUnderTest = GivenCoffeeShop();

            var result = _itemUnderTest.GetSummary();

            Assert.AreEqual(
                "Coffee Shop Summary" + Environment.NewLine + Environment.NewLine +
                "Total customers: 6" + Environment.NewLine +
                "    General sales: 2" + Environment.NewLine +
                "    Loyalty member sales: 3" + Environment.NewLine +
                "    Discount sales: 1" + Environment.NewLine +
                "    Employee Complimentary: 0" + Environment.NewLine + Environment.NewLine +
                "Total revenue from drinks: 450" + Environment.NewLine +
                "Total costs from drinks: 300" + Environment.NewLine +
                "Coffee Shop generating profit of: 150" + Environment.NewLine + Environment.NewLine +
                "Total loyalty points given away: 8" + Environment.NewLine +
                "Total loyalty points redeemed: 120" + Environment.NewLine + Environment.NewLine +
                "Beans used: 900" + Environment.NewLine +
                "Beans remaining: 100" + Environment.NewLine + Environment.NewLine +
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
                            "    Discount sales: 0" + Environment.NewLine +
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

        private static ICoffeeShop GivenCoffeeShop()
        {
            ICoffeeShop coffeeShop = new CoffeeShop(new CoffeeShopReportGenerator(), new CoffeeStrategyFactory(), new CoffeeShopState());

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
                Name = "Damian",
                Type = CustomerType.LoyaltyMember,
                LoyaltyPoints = 1000,
                IsUsingLoyaltyPoints = true,
                Drinks = new List<Drink>
                {
                    new Drink("Cappuccino") { BaseCost = 60, BasePrice = 120, LoyaltyPointsGained = 8 }
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

            coffeeShop.AddCustomer(new Customer
            {
                Name = "Andrzej",
                Type = CustomerType.CoffeeEmployee,
                Drinks = new List<Drink>
                {
                    new Drink("Americano") { BaseCost = 50, BasePrice = 100, LoyaltyPointsGained = 5 }
                }
            });

            coffeeShop.AddCustomer(new Customer
            {
                Name = "Matt",
                Type = CustomerType.DiscountMember,
                Drinks = new List<Drink>
                {
                    new Drink("Mocha") { BaseCost = 60, BasePrice = 120, LoyaltyPointsGained = 8}
                }
            });

            return coffeeShop;
        }

        private static ICoffeeShop GivenEmptyCoffeeShop()
        {
            return new CoffeeShop(new CoffeeShopReportGenerator(), new CoffeeStrategyFactory(), new CoffeeShopState());
        }
    }
}