namespace CoffeeShop.Core
{
    public class Drink : IDrink
    {
        public Drink(string title)
        {
            Title = title;
        }

        public string Title { get; set; }
        public decimal BasePrice { get; set; }
        public decimal BaseCost { get; set; }
        public int LoyaltyPointsGained { get; set; }    
    }
}
