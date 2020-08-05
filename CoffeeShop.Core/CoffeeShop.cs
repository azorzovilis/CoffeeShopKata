namespace CoffeeShop.Core
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class CoffeeShop : ICoffeeShop
    {
        private readonly string VERTICAL_WHITE_SPACE = Environment.NewLine + Environment.NewLine;
        private readonly string NEW_LINE = Environment.NewLine;
        private const string INDENTATION = "    ";

        public CoffeeShop(IDrink drink)
        {
            Drink = drink;
            Customers = new List<Customer>();
        }

        public IDrink Drink { get; private set; }
        public List<Customer> Customers { get; private set; }

        public void AddCustomer(Customer customer)
        {
            Customers.Add(customer);
        }
        
        public string GetSummary()
        {
            double costOfDrinks = 0;
            double incomeFromDrinks = 0;
            int totalLoyaltyPointsAccrued = 0;
            int totalLoyaltyPointsRedeemed = 0;

            string result = "Coffee Shop Summary";

            foreach (var customer in Customers)
            {
                switch (customer.Type)
                {
                    case(CustomerType.General):
                        {
                            incomeFromDrinks += Drink.BasePrice;
                            break;
                        }
                    case(CustomerType.LoyaltyMember):
                        {
                            if (customer.IsUsingLoyaltyPoints)
                            {
                                int loyaltyPointsRedeemed = Convert.ToInt32(Math.Ceiling(Drink.BasePrice));
                                customer.LoyaltyPoints -= loyaltyPointsRedeemed;
                                totalLoyaltyPointsRedeemed += loyaltyPointsRedeemed;
                            }
                            else
                            {
                                totalLoyaltyPointsAccrued += Drink.LoyaltyPointsGained;
                                incomeFromDrinks += Drink.BasePrice;
                            }
                            break;
                        }
                }
                costOfDrinks += Drink.BaseCost;
            }

            result += VERTICAL_WHITE_SPACE;
            
            result += "Total customers: " + Customers.Count;
            result += NEW_LINE;
            result += INDENTATION + "General sales: " + Customers.Count(p => p.Type == CustomerType.General);
            result += NEW_LINE;
            result += INDENTATION + "Loyalty member sales: " + Customers.Count(p => p.Type == CustomerType.LoyaltyMember);
            result += NEW_LINE;
            result += INDENTATION + "Employee Complimentary: " + Customers.Count(p => p.Type == CustomerType.CoffeeEmployee);
            
            result += VERTICAL_WHITE_SPACE;

            result += "Total revenue from drinks: " + incomeFromDrinks;
            result += NEW_LINE;
            result += "Total costs from drinks: " + costOfDrinks;
            result += NEW_LINE;

            double profit = incomeFromDrinks - costOfDrinks;

            result += (profit > 0 ? "Coffee Shop generating profit of: " : "Coffee Shop losing money of: ") + profit;

            result += VERTICAL_WHITE_SPACE;

            result += "Total loyalty points given away: " + totalLoyaltyPointsAccrued + NEW_LINE;
            result += "Total loyalty points redeemed: " + totalLoyaltyPointsRedeemed + NEW_LINE;

            result += NEW_LINE;

            result += (profit > 20 ? "Coffee Shop will open tomorrow" : "Coffee Shop will not open tomorrow");

            return result;
        }
    }
}
