using ConsoleAppCharacteristicEnum;
using ConsoleAppComputer;
using ConsoleAppLaptop;
using ConsoleAppMacBook;
using ConsoleAppPhone;
using ConsoleAppProgrammationObject2.Interface;

namespace ConsoleAppProgrammationObject
{
    class Program
    {
        public List<IDescribable> Inventory { get; set; }

        static void Main(string[] args)
        {
            // Initialisation du stock 
            Program estab1 = new Program();
            estab1.InitData();

            // Afficher inventaire
            estab1.DisplayInventory();

            // Achater un item
            estab1.BuyItem();

            Program estab2 = new Program();
            // Ajouter un pc
            estab1.AddItem();

            // Rechercher un item
            Console.WriteLine("Rechercher un item");
            Console.WriteLine("Entrer le nom de l'item rechercher");
            var itemName = Console.ReadLine();
            estab1.SearhItem(itemName);
        }



        // Création data
        public void InitData()
        {
            Inventory = new List<IDescribable>();

            // Computer 
            Computer Computer1 = new Computer("Computer1", 1563325, 2000, "OS");
            Computer1.SetDict(CharacteristicEnum.GraphicCard, "Intel Core i7");
            Computer1.SetDict(CharacteristicEnum.Processor, "NVIDIA GeForce RTX 2080");
            Computer1.SetDict(CharacteristicEnum.RAM, "16GB");
            Computer1.Describe();
            Inventory.Add(Computer1);

            Computer Computer2 = new Computer("Computer2", 1563325, 2000, "ios");
            Computer2.SetDict(CharacteristicEnum.GraphicCard, "Inter i5");
            Computer2.Describe();
            Inventory.Add(Computer2);

            // MacBook
            MacBook macBook1 = new MacBook(666666, 654, "17''", "--_|||_");
            macBook1.Describe();
            Inventory.Add(macBook1);
            MacBook macBook2 = new MacBook(444444, 4654, "23''", "||_--_|");
            macBook2.Describe();
            Inventory.Add(macBook2);


            // Laptop
            Laptop laptop1 = new Laptop("laptop1", 1563325, 2000, "17''");
            laptop1.Describe();
            Inventory.Add(laptop1);

            Laptop laptop2 = new Laptop("laptop2", 45612132, 3500, "15''");
            laptop2.Describe();
            Inventory.Add(laptop2);


            // Phone
            Phone phone1 = new Phone("phone1", 99999, 65, "9''", "16g");
            phone1.Describe();
            Inventory.Add(phone1);

            Phone phone2 = new Phone("phone2", 33333, 654, "8''", "20g");
            phone2.Describe();
            Inventory.Add(phone2);

            Console.WriteLine();
            TotalPriceItem();
            Console.ReadKey();
            Console.WriteLine();
        }


        // DISPLAY INVENTORY
        public void DisplayInventory()
        {
            Console.WriteLine("Afficher inventaire :");
            Console.ReadKey();

            foreach (var item in Inventory)
            {
                Console.WriteLine(item.Name);
            }

            Console.ReadKey();
            Console.WriteLine();
        }

        // ACHETER UN ITEM
        public void BuyItem()
        {
            Console.WriteLine("Achater un item");
            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine("Quel item souhaitez-vous acheter :");
            string userInput = Console.ReadLine();
            Console.WriteLine("achat de " + userInput);
            getPriceItem(userInput);
            Console.ReadKey();
            Console.WriteLine();
            DisplayInventory();
            TotalPriceItem();
            Console.ReadKey();
        }

        // SUPPRIMER 
        public void DeleteFromInventory(string name)
        {
            var itemToRemove = Inventory.FirstOrDefault(item => item.Name == name);
            if (itemToRemove != null)
            {
                Inventory.Remove(itemToRemove);
                Console.WriteLine($"Item '{name}' supprimer de l'inventaire");
            }
            else
            {
                Console.WriteLine($"Item '{name}' introuvable");
            }
            Console.WriteLine();
        }


        // PRIX DE L'ITEM CHOISI
        public void getPriceItem(string name)
        {
            var itemName = Inventory.FirstOrDefault(item => item.Name == name);
            if (itemName != null)
            {
                var price = itemName.Price;
                Console.WriteLine($"Cet item coute {price} euros");
                Console.ReadKey();
                DeleteFromInventory(name);
            }
            else
            {
                Console.WriteLine($"Item '{name}' introuvable");
            }
            Console.WriteLine();
        }

        // PRIX TOTAL INVENTAIRE
        public void TotalPriceItem()
        {
            var totalPrice = 0;
            foreach (var item in Inventory)
            {
                totalPrice += item.Price;
            }
            Console.WriteLine("Total Price of all items: " + totalPrice + " euros");
            Console.WriteLine();

        }

        // AJOUTER ITEM
        public void AddItem()
        {
            Console.WriteLine("Ajout d'un item Computer");
            Console.WriteLine("Entrer intems details :");
            Console.WriteLine("Nom:");
            string name = Console.ReadLine();
            Console.WriteLine("Reference:");
            int reference = int.Parse(Console.ReadLine());
            Console.WriteLine("Prix:");
            int price = int.Parse(Console.ReadLine());

            Computer computer = new Computer(name, reference, price);
            Inventory.Add(computer);
            Console.WriteLine($"{name} Ajoutet à l'inventaire");
            Console.WriteLine();
            Console.ReadKey();
            DisplayInventory();
            Console.WriteLine();
            TotalPriceItem();
            Console.WriteLine();
            Console.ReadKey();
        }


        // RECHERCHER UN ITEM 
        public void SearhItem(string name)
        {
            var item = Inventory.FirstOrDefault(x => x.Name == name);

            if (item != null)
            {
                Console.WriteLine("item trouver");
                Console.WriteLine("Description");
                item.Describe();
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("item indisponible");
                Console.ReadKey();
            }
            Console.WriteLine();
        }
    }
}