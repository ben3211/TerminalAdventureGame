namespace ConsoleAppProgrammationObject2.Interface
{
    public interface IDescribable
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public void Describe();
    }
}
