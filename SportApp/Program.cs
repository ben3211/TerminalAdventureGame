using SportApp.Class;
using SportApp.Class.Sports;
using static SportApp.Enum.EquipementEnum;

namespace SportApp
{
    public class Program
    {
        private List<Client> Clients = new List<Client>();
        private List<Sport> Sports = new List<Sport>();

        public void Start()
        {
            // Data initialization
            DataInit();

            // Add clients
            Client.Formulaire(Clients);

            // Show client, sport, and coach list
            Client.ClientList(Clients);
            Sport.SportList(Sports);
            var tt = GetCoaches();
            Console.WriteLine("\n");
            Console.WriteLine("List des coaches");
            foreach (var coach in tt)
            {
                Console.WriteLine(coach.ToString());
            }


            Console.WriteLine("\n");

            {
                // Options menu
                Console.WriteLine("Please select an option:\n");
                Console.WriteLine("A to Add client");
                Console.WriteLine("U to Update client");
                Console.WriteLine("D to Delete client");
                Console.WriteLine("S to display list");
                Console.WriteLine("SE to display sport equipment");
                Console.WriteLine("AN to change phone number");
                Console.WriteLine("DCS to display coach and their speciality");
                Console.WriteLine("C to start a competition");
                Console.WriteLine("G to get sport by equipment");
                Console.WriteLine("R to restart\n");

                var input = Console.ReadLine().ToUpper(); // Case sensitivity

                switch (input)
                {
                    // Add client
                    case "A":
                        Client.Formulaire(Clients);
                        break;

                    // Update client
                    case "U":
                        Console.WriteLine("Enter your name:");
                        var yourName = Console.ReadLine();
                        Client.UpdateClient(Clients, yourName);
                        break;

                    // Delete client
                    case "D":
                        Console.WriteLine("Enter the name of the client to delete:\n");
                        var nameToDelete = Console.ReadLine();
                        Client.DeleteClient(Clients, nameToDelete);
                        break;

                    // Show list
                    case "S":
                        Client.ClientList(Clients);
                        Sport.SportList(Sports);
                        Coach.CoachList(Clients);
                        Console.WriteLine();
                        break;

                    // Change phone number
                    case "AN":
                        Console.WriteLine("Enter the client's name:\n");
                        var name = Console.ReadLine();
                        Client.AddNumber(Clients, name);
                        break;

                    // Display coach and their speciality
                    case "DCS":
                        Console.WriteLine("Enter the coach's name:\n");
                        var coachName = Console.ReadLine();
                        Sport.DisplaySpeciality(coachName);
                        break;

                    // Display sport equipment
                    case "SE":
                        Console.WriteLine("Enter the name of the sport:");
                        var sportName = Console.ReadLine();
                        Console.WriteLine();
                        var p = Sports.FirstOrDefault(s => s.SportName == sportName);
                        if (p != null)
                        {
                            p.DisplayEquipement();
                        }
                        else
                        {
                            Console.WriteLine("Sport not found.");
                        }
                        Console.WriteLine();
                        break;


                    // Start a competition
                    case "C":
                        Console.WriteLine("Select a discipline (Tennis / Rugby / Basket / Football):\n");
                        var chosenSport = Console.ReadLine();
                        Console.WriteLine("\n");

                        // Get the coach and rules
                        Sport sportcomp = Sports.FirstOrDefault(s => s.SportName.Equals(chosenSport, StringComparison.OrdinalIgnoreCase));
                        Coach coach = GetCoaches().FirstOrDefault(c => c.Speciality == sportcomp.SportName);
                        if (sportcomp != null)
                            {
                                Competition competition = new Competition(Clients, coach, sportcomp);
                                competition.DisplayTheRules();
                                competition.WhoIsTheCoach();
                                Console.WriteLine("\n");
                            }
                            else
                            {
                                Console.WriteLine("Invalid sport");
                            }
                        Console.WriteLine("\n");

                        // Shuffle and split into two teams
                        Random random = new Random();
                        List<Client> shuffledPlayers = Clients.OrderBy(x => random.Next()).ToList();
                        int halfCount = shuffledPlayers.Count / 2;
                        List<Client> team1 = shuffledPlayers.Take(halfCount).ToList();
                        List<Client> team2 = shuffledPlayers.Skip(halfCount).ToList();

                        // Display the teams
                        Console.WriteLine("Team 1:");
                        foreach (Client player in team1)
                        {
                            Console.WriteLine(player.ToString());
                        }

                        Console.WriteLine("\nTeam 2:");
                        foreach (Client player in team2)
                        {
                            Console.WriteLine(player.ToString());
                        }

                        Console.WriteLine();
                        break;

                    // Get sport by equipment
                    case "G":
                        Console.WriteLine("Enter the equipment:");
                        var equipmentInput = Console.ReadLine();
                        Console.WriteLine("/n");

                        if (System.Enum.TryParse<SportEquipement>(equipmentInput, out SportEquipement equipment))
                        {
                            List<Sport> matchingSports = SportManager.GetSportByObject(equipment, Sports);

                            Console.WriteLine("Matching sports:");
                            foreach (Sport sport in matchingSports)
                            {
                                Console.WriteLine(sport.SportName);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid equipment input.");
                        }

                        Console.WriteLine();
                        break;

                    // Restart
                    case "R":
                        Restart();
                        DataInit();
                        Client.Formulaire(Clients);
                        Client.ClientList(Clients);
                        Sport.SportList(Sports);
                        Coach.CoachList(Clients);
                        Console.WriteLine();
                        break;

                    default:
                        Console.WriteLine("No action selected.\n");
                        Console.WriteLine("U to Update, D to Delete\n");
                        break;
                }
            }
        }

        public void DataInit()
        {
            Console.WriteLine("Data initialization:\n");

            // Clients
            Client client1 = new Client("client1");
            Client client2 = new Client("client2");
            Client client3 = new Client("client3");
            Client client4 = new Client("client4");
            Client client5 = new Client("client5");
            Client client6 = new Client("client6");
            Client client7 = new Client("client7");
            Client client8 = new Client("client8");
            Client client9 = new Client("client9");
            Client client10 = new Client("client10");

            Clients.Add(client1);
            Clients.Add(client2);
            Clients.Add(client3);
            Clients.Add(client4);
            Clients.Add(client5);
            Clients.Add(client6);
            Clients.Add(client7);
            Clients.Add(client8);
            Clients.Add(client9);
            Clients.Add(client10);

            // Coaches
            Coach basketCoach = new Coach("BasketCoach", "Basket");
            Coach tennisCoach = new Coach("TennisCoach", "Tennis");
            Coach rugbyCoach = new Coach("RugbyCoach", "Rugby");
            Coach footballCoach = new Coach("FootballCoach", "Football");

            Clients.Add(basketCoach);
            Clients.Add(tennisCoach);
            Clients.Add(rugbyCoach);
            Clients.Add(footballCoach);

            // Sports
            Sport sport1 = new Basket();
            Sport sport2 = new Tennis();
            Sport sport3 = new Football();
            Sport sport4 = new Rugby();

            Sports.Add(sport1);
            Sports.Add(sport2);
            Sports.Add(sport3);
            Sports.Add(sport4);
        }

        // Restart
        public void Restart()
        {
            Clients.Clear();
            Sports.Clear();
        }

        public List<Coach> GetCoaches()
        {
            List<Coach> coaches = Clients.OfType<Coach>().ToList();
            return coaches;
        }
    }

    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            Program program = new Program();
            program.Start();
        }
    }
}