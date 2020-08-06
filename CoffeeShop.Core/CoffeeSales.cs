namespace CoffeeShop.Core
{
    public class CoffeeSales
    {
        public int General { get; set; }

        public int Loyalty { get; set; }

        public int Discount { get; set; }

        public int Complimentary { get; set; }

        public int TotalSales => General + Loyalty + Discount + Complimentary;
    }
}
