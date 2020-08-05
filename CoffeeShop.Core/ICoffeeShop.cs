namespace CoffeeShop.Core
{
    using System.Collections.Generic;

    public interface ICoffeeShop
    {
        void AddCustomer(Customer customer);

        string GetSummary();

        List<Customer> Customers { get; }

        IDrink Drink { get; }

        decimal CostOfDrinks { get; set; }

        decimal IncomeFromDrinks { get; set; }

        int TotalLoyaltyPointsAccrued { get; set; }

        int TotalLoyaltyPointsRedeemed { get; set; }
        
        int BeanCount { get; set; }

        int InitialBeanCount { get; }
    }
}