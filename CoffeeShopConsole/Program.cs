namespace CoffeeShopProblem
{
    using System;
    using CoffeeShop.Core;

    class Program
    {
        private static CoffeeShop _coffeeShop ;

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
                        Name = segments[2]
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
                        IsUsingLoyaltyPoints = Convert.ToBoolean(segments[4])
                    });
                }
                else if (enteredText.Contains("add employee"))
                {
                    string[] segments = enteredText.Split(' ');
                    _coffeeShop.AddCustomer(new Customer
                    {
                        Type = CustomerType.CoffeeEmployee, 
                        Name = segments[2]
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

        private static void SetupData()
        {
            Drink drink = new Drink("Americano")
            {
                BaseCost = 50, 
                BasePrice = 100, 
                LoyaltyPointsGained = 5
            };

            _coffeeShop = new CoffeeShop(drink);
        }
    }
}
