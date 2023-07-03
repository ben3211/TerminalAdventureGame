namespace SportApp.Class
{
    public class Client 
    {
        protected internal string Name { get; set; }
        private string Email { get; set; }
        private int Numero { get; set; }
        internal List<Sport> ListSport { get; set; }

        // public Client(){ }
        public Client(string name)
        {
            Name = name;
        }

        // Formulaire
        public static void Formulaire(List<Client> clients)
        {
            Console.WriteLine("Votre nom :");
            var name = Console.ReadLine();
            Console.WriteLine("Etes-vous coach ? true/false");
            var coach = Console.ReadLine();
            Console.WriteLine("\n");

            bool isCoach;
            if (bool.TryParse(coach, out isCoach))
            {
                Client client = new Client(name);
                if (isCoach)
                {
                    Console.WriteLine("Entrez la spécialité du coach :");
                    var speciality = Console.ReadLine();
                    client  = new Coach(name, speciality);
                }
                clients.Add(client);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter 'true' or 'false' for the coach question.\n");
            }
        }

        public override string ToString()
        {
            return $"{Name}  {Numero}";
        }

        // Client list 
        public static void ClientList(List<Client> clients)
        {
            Console.WriteLine("\n");
            Console.WriteLine("Client list:");
            if (clients != null && clients.Count > 0)
            {
                foreach (var client in clients)
                {
                    Console.WriteLine($"{client}");
                }
            }
            else
            {
                Console.WriteLine("No clients found. \n");
            }
        }

        // Update client
        public static void UpdateClient(List<Client> clients, string name)
        {
            var findClient = clients.FirstOrDefault( x => x.Name == name);

            if (findClient != null)
            {
                Console.WriteLine("Enter new name:");
                string newName = Console.ReadLine();
                //Console.WriteLine("Enter new phone number:");
                //int newNumero = int.Parse(Console.ReadLine());

                findClient.Name = newName;
                //findClient.Email = newEmail;
                //findClient.Numero = newNumero;

                Console.WriteLine("Les informations ont été mise à jour \n");
            }
            else
            {
                Console.WriteLine("Client not found. \n");
                Console.WriteLine("U to Update, D to Delete\n");

            }
        }

        // Delete client
        public static void DeleteClient(List<Client> clients, string name)
        {
            var clientToRemove = clients.FirstOrDefault(x => x.Name == name);
            if (clientToRemove != null)
            {
                clients.Remove(clientToRemove);
                Console.WriteLine($"Client {name} removed successfully. \n");
            }
            else
            {
                Console.WriteLine("Client not found. \n");
                Console.WriteLine("U to Update, D to Delete\n");
            }
        }

        // AddNumber
        public static void AddNumber(List<Client> clients, string name)
        {
            Console.WriteLine("Enter client phone number:");
            string numeroInput = Console.ReadLine();

            int numero;
            if (int.TryParse(numeroInput, out numero))
            {
                var existingClient = clients.FirstOrDefault(client => client.Name == name);
                if (existingClient != null)
                {
                    existingClient.Numero = numero; 
                    Console.WriteLine("Client updated successfully.\n");
                }
                else
                {
                    Client newClient = new Client(name);
                    newClient.Numero = numero;
                    clients.Add(newClient);
                    Console.WriteLine("Client added successfully.\n");
                }
            }
            else
            {
                Console.WriteLine("Invalid phone number format. Please enter a valid integer number.\n");
            }
        }
    }
}