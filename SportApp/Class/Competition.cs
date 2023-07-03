namespace SportApp.Class
{
    internal class Competition 
    {
        public List<Client> PlayersList { get; set; }
        public Coach Arbitre { get; set; }
        public Sport SportCompetition { get; set; }

        public Competition(List<Client> playersList, Coach arbitre, Sport sportCompetition) 
        {

            PlayersList = playersList ?? new List<Client>();
            Arbitre = arbitre;
            SportCompetition = sportCompetition;
        }

        public void CreateCompetition()
        {
            Console.WriteLine("The competition begins!");
        }

        public void DisplayTheRules()
        {
            if (SportCompetition != null)
            {
                Console.WriteLine($"Régles du {SportCompetition.SportName}");
                SportCompetition.DisplayRules();
            } else
            {
                Console.WriteLine($"sport introuvable");
            }
        }

        public void WhoIsTheCoach()
        {
            if (SportCompetition != null)
            {
                Console.WriteLine($"L'arbitre pour la compétition de {SportCompetition.SportName} sera {Arbitre.Name}.");
            }
            else
            {
                Console.WriteLine($"Aucun arbitre trouver");
            }
        }
    }
}
