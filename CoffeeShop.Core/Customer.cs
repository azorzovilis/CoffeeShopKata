namespace CoffeeShop.Core
{
    public class Customer
    {
        public string Name { get; set; }
        public int LoyaltyPoints { get; set; }
        public bool IsUsingLoyaltyPoints { get; set; }
        public CustomerType Type { get; set; }
    }
    
    public enum CustomerType
    {
        General,
        LoyaltyMember,
        CoffeeEmployee
    }
}
