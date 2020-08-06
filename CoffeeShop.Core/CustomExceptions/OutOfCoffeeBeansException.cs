namespace CoffeeShop.Core.CustomExceptions
{
    using System;

    public class OutOfCoffeeBeansException : Exception
    {
        public OutOfCoffeeBeansException(string drink, string customerName)
            : base($"ERROR! There are not enough coffee beans in store to make a {drink} for customer {customerName}!" + Environment.NewLine)
        {

        }
    }
}
