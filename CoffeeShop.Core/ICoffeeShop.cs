namespace CoffeeShop.Core
{
    using System.Collections.Generic;

    public interface ICoffeeShop
    {
        void AddCustomer(Customer customer);

        string GetSummary();

        List<Customer> Customers { get; }
    }
}