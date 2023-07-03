using ConsoleAppLaptop;

namespace ConsoleAppMacBook
{
    public class MacBook : Laptop
    {
        private static readonly string _internalName = "MacBook";
        public string Certification { get; set; }

        public MacBook(int reference, int price, string screenSize, string certification) : base(_internalName, reference, price, screenSize)
        {
            Certification = certification;
        }

        public override void Describe()
        {
            base.Describe();
            //Console.WriteLine("Certification :" + Certification);    
        }

    }
}
