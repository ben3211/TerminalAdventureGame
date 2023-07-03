namespace SportApp.Class
{
    public class Coach : Client
    {
        public string Speciality { get; set; }
        public static object Clients { get; private set; }

        // public List<Coach> Coaches { get; set; }

        public Coach(string name, string? speciality) : base(name)
        {
            Speciality = speciality;
        }

        // List coach
        public static List<Coach> CoachList (List<Client> Clients)
        {
            Console.WriteLine();
            Console.WriteLine("liste des coachs");

            List<Coach> coaches = Clients.OfType<Coach>().ToList();
 
            if (coaches != null)
            {
                foreach (var c in coaches)
                {
                    Console.WriteLine($"{c}");
                }
            }
            else
            {
                Console.WriteLine("Vide");
            }
            return coaches;
        }

        public override string ToString()
        {
            return $"{Name} Coach de : {Speciality}";
        }
    }
}
