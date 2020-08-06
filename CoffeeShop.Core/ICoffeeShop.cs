namespace CoffeeShop.Core
{
    public interface ICoffeeShop
    {
        void AddCustomer(Customer customer);

        string GetSummary();
    }
}