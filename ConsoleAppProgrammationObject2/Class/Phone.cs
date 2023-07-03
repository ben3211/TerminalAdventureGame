using ConsoleAppLaptop;

namespace ConsoleAppPhone
{
    public class Phone : Laptop
    {
        public string StockageCapacity { get; set; }

        public Phone(string name, int reference, int price, string screenSize, string stockageCapacity) : base(name, reference, price, screenSize)
        {
            StockageCapacity = stockageCapacity;
        }
    }
}
