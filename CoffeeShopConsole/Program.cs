namespace CoffeeShop.Console
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Core;
    using Core.Factories;
    using Core.Services;

    class Program
    {
        private static ICoffeeShop _coffeeShop;
        private static readonly List<Drink> _drinks = new List<Drink>
        {
            new Drink("Americano") { BaseCost = 50, BasePrice = 100, LoyaltyPointsGained = 5},
            new Drink("Cappuccino") { BaseCost = 60, BasePrice = 120, LoyaltyPointsGained = 8},
            new Drink("Latte") { BaseCost = 50, BasePrice = 100, LoyaltyPointsGained = 5},
            new Drink("Espresso") { BaseCost = 30, BasePrice = 60, LoyaltyPointsGained = 3},
            new Drink("Mocha") { BaseCost = 60, BasePrice = 120, LoyaltyPointsGained = 8}
        };

        //TODO: Refactor
    static void Main(string[] args)
        {
            SetupData();

            string command = "";
            do
            {
                command = Console.ReadLine() ?? "";
                var enteredText = command.ToLower();
                if (enteredText.Contains("print summary"))
                {
                    Console.WriteLine();
                    Console.WriteLine(_coffeeShop.GetSummary());
                }
                else if (enteredText.Contains("add general"))
                {
                    string[] segments = enteredText.Split(' ');
                    _coffeeShop.AddCustomer(new Customer
                    {
                        Type = CustomerType.General,
                        Name = segments[2],
                        Drinks = GetDrinks()
                    });
                }
                else if (enteredText.Contains("add loyalty"))
                {
                    string[] segments = enteredText.Split(' ');
                    _coffeeShop.AddCustomer(new Customer
                    {
                        Type = CustomerType.LoyaltyMember,
                        Name = segments[2],
                        LoyaltyPoints = Convert.ToInt32(segments[3]),
                        IsUsingLoyaltyPoints = Convert.ToBoolean(segments[4]),
                        Drinks = GetDrinks()
                    });
                }
                else if (enteredText.Contains("add employee"))
                {
                    string[] segments = enteredText.Split(' ');
                    _coffeeShop.AddCustomer(new Customer
                    {
                        Type = CustomerType.CoffeeEmployee,
                        Name = segments[2],
                        Drinks = GetDrinks()
                    });
                }
                else if (enteredText.Contains("add discount"))
                {
                    string[] segments = enteredText.Split(' ');
                    _coffeeShop.AddCustomer(new Customer
                    {
                        Type = CustomerType.CoffeeEmployee,
                        Name = segments[2],
                        Drinks = GetDrinks()
                    });
                }
                else if (enteredText.Contains("exit"))
                {
                    Environment.Exit(1);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("UNKNOWN INPUT");
                    Console.ResetColor();
                }
            } while (command != "exit");
        }

        //TODO: Use IoC
        private static void SetupData()
        {
            _coffeeShop = new CoffeeShop(
                new CoffeeShopReportGenerator(), 
                new CoffeeStrategyFactory(), 
                new CoffeeShopState());
        }

        // This is purely to keep original interface in functionality as drinks can be provided via the console in the future
        private static IList<Drink> GetDrinks()
        {
            var rnd = new Random();

            return _drinks.OrderBy(x => rnd.Next()).Take(rnd.Next(1,2)).ToList();
        }
    }
}
