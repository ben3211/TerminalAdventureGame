using ConsoleAppComputer;

namespace ConsoleAppLaptop
{
    public class Laptop : Computer
    {
        public string ScreenSize { get; set; }

        public Laptop(string name, int reference, int price, string screenSize) : base(name, reference, price)
        {
            ScreenSize = screenSize;
        }

        public override void Describe()
        {
            base.Describe();
            // Console.WriteLine("Ecran : " + ScreenSize);
        }
    }
}
