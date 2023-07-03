using ConsoleAppCharacteristicEnum;
using ConsoleAppProgrammationObject2.Interface;

namespace ConsoleAppComputer
{
    public class Computer : IDescribable
    {

        // Propriétés, caractéristiques
        public virtual string Name { get; set; }
        public int Reference { get; set; }
        public int Price { get; set; }
        public string Os { get; set; }
        Dictionary<CharacteristicEnum, string> CharacteristicDictionary { get; set; }
        public static int nbComputer = 0;
        public Computer() { }

        public Computer(string name, int reference, int price, string os = "os")
        {
            Name = name;
            Reference = reference;
            Price = price;
            Os = os;

            nbComputer++;
        }

        // setDict
        public void SetDict(CharacteristicEnum key, string value)
        {
            if (CharacteristicDictionary == null)
            {
                CharacteristicDictionary = new Dictionary<CharacteristicEnum, string>();
            }

            if (CharacteristicDictionary.ContainsKey(key))
            {
                CharacteristicDictionary[key] = value;
            }
            else
            {
                CharacteristicDictionary.Add(key, value);
            }

        }

        // DESCRIBE
        public virtual void Describe()
        {
            Console.WriteLine($"{Name}({Reference})");
            Console.WriteLine("Prix TTC : " + Price);
            Console.WriteLine("Os : " + Os);

            if (CharacteristicDictionary != null)
            {
                Console.WriteLine("*** Caractéristique de l'ordinateur ***");

                foreach (var carac in CharacteristicDictionary)
                {
                    Console.WriteLine($"{carac.Key} : {carac.Value}");
                }
            }

            Console.WriteLine("***********************************");
        }
    }
}
