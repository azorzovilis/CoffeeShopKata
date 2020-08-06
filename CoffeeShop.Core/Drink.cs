namespace CoffeeShop.Core
{
    using System.Configuration;

    public class Drink
    {
        public Drink(string title)
        {
            Title = title;
            BeansPerCap = int.TryParse(ConfigurationManager.AppSettings["BeansPerCap"], out var beansPerCap) ? beansPerCap : 150;
        }

        public string Title { get; set; }
        public decimal BasePrice { get; set; }
        public decimal BaseCost { get; set; }
        public int LoyaltyPointsGained { get; set; }
        public int BeansPerCap { get; }
    }
}
