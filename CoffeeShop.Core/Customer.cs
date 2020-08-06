namespace CoffeeShop.Core
{
    using System.Collections.Generic;
    using System.Configuration;

    public class Customer
    {
        public Customer()
        {
            NumberOfComplimentaryDrinks = int.TryParse(ConfigurationManager.AppSettings["NumberOfComplimentaryDrinks"], out var noOfDrinks) ? noOfDrinks : 2;
        }

        public string Name { get; set; }
        public int LoyaltyPoints { get; set; }
        public bool IsUsingLoyaltyPoints { get; set; }
        public int NumberOfComplimentaryDrinks { get; set; }
        public CustomerType Type { get; set; }
        public virtual ICollection<Drink> Drinks { get; set; } = new List<Drink>();
    }
    
    public enum CustomerType
    {
        General,
        LoyaltyMember,
        CoffeeEmployee,
        DiscountMember
    }
}
