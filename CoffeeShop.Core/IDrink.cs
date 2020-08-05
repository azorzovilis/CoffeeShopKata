namespace CoffeeShop.Core
{
    public interface IDrink
    {
        string Title { get; set; }

        decimal BasePrice { get; set; }

        decimal BaseCost { get; set; }

        int LoyaltyPointsGained { get; set; }
    }
}