namespace CoffeeShop.Core
{
    public interface IDrink
    {
        string Title { get; set; }

        double BasePrice { get; set; }

        int LoyaltyPointsGained { get; set; }

        double BaseCost { get; set; }
    }
}