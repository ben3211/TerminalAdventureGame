using System.Collections.Generic;
using WebApplication1;
using WebApplication1.Monstres;
using WebApplication1.Personnages;

namespace MyGame
{
    public class Program
    {
        private bool DifficultMode { get; set; }

        public void Start()
        {
            StartGame();
        }

        public void Jouer(Personnage monPerso)
        {

            // Création d'une list de monstre
            List<Monstre> monstreList = new List<Monstre>();
            List<Monstre> monstreMortList = new List<Monstre>();

            // Créé une variable d'un chiffre entre 0 et 3
            Random random = new Random();
            int randomNumber = random.Next(0, 4);

            // Appeller plusieurs fois la méthode qui génére des monstres
            for (int i = 0; i < randomNumber; i++)
            {
                Monstre callMonster = GetRandomMonster();
                // Ajouter les instances a la list 
                monstreList.Add(callMonster);
            }

            bool victoire = true;
            bool suivant = false;

            // Si liste = 0, passer à la salle suivante 
            if (monstreList.Count == 0)
            {
                Console.WriteLine("Cette salle est vide");
            }
            else
            {
                var toot = new List<string>();
                foreach (var m in monstreList)
                {
                    var nom = m.ToString();
                    toot.Add(nom);
                }

                Console.WriteLine($@"il y a {monstreList.Count} monstres : {string.Join(" | ", toot)}");
            }

            // While -> Combattre temps que des éléments sont dans la list 
            while (monstreList.Count > 0 && victoire == true)
            {
                // Tour du personnage
                Console.ForegroundColor = ConsoleColor.Green;

                // Cb de mosntre je dois attaquer (bool, list) et choix 
                // Taper les monstres que je veux 
                var listToFight = GetListToFight(monstreList);

                // Attaquer une fois tous les éléments de la list 
                foreach (var monstre in listToFight)
                {
                    monPerso.Attaquer(monstre);
                    RemoveFromListIfDead(monstre, monPerso, monstreList);
                }

                // Attaque des monstres
                foreach (var monstre in monstreList)
                {
                    // Les éléments de la list attaque une fois le P
                    Console.ForegroundColor = ConsoleColor.Red;
                    monstre.Attaquer(monPerso);

                    Console.WriteLine();
                    Console.ReadKey(true);

                    // Si vie de P < 0 -> partie terminer
                    if (monPerso.EstMort())
                    {
                        victoire = false;
                        break;
                    }

                }
            }

            if (victoire)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine();

                while (!suivant)
                {
                    Console.WriteLine("Salle suivant ? (O/N)");
                    string saisie = Console.ReadLine().ToUpper();
                    if (saisie == "O")
                    {
                        suivant = true;
                        Jouer(monPerso);
                    }
                    else if (saisie == "N")
                    {
                        Environment.Exit(0);
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine();
                Console.WriteLine("Partie terminer");
                Console.ReadKey();
            }
        }

        public void StartGame()
        {
            Console.WriteLine("Choisir le mode de difficulté :");
            Console.WriteLine("1. Normal (mode par défaut)");
            Console.WriteLine("2. Difficile");
            string difficultyChoice = Console.ReadLine();

            if (difficultyChoice == "2")
            {
                DifficultMode = true;
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Le jeu");
            Console.WriteLine();
            Console.WriteLine("Choisir ta class : ");
            Console.WriteLine("1. Guerrier");
            Console.WriteLine("2. Sorcier");
            Console.WriteLine("3. Archer");
            Console.WriteLine("4. Quitter");
            Console.WriteLine();

            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Vous avez choisis Guerrier !");
                    Console.WriteLine();
                    Jouer(new Guerrier("Guerrier"));
                    break;
                case "2":
                    Console.WriteLine("Vous avez choisis Sorcier !");
                    Console.WriteLine();
                    Jouer(new Sorcier("Sorcier"));
                    break;
                case "3":
                    Console.WriteLine("Vous avez choisis Archer !");
                    Console.WriteLine();
                    Jouer(new Archer("Archer"));
                    break;
                case "4":
                    break;
            }
        }

        public static Monstre GetRandomMonster()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 4);

            switch (randomNumber)
            {
                case 1:
                    return new VersDeTerre("Vers De Terre féroce");
                case 2:
                    return new Plante("Plante qui pique");
                case 3:
                    return new Chaise("Chaise titane");
                default:
                    return null;
            }
        }

        public void RemoveFromListIfDead(Monstre monstre, Personnage monPerso, List<Monstre> monstreList)
        {
            // Si un monstre n'a plus de pv, le retirer de la liste 
            if (monstre.EstMort())
            {
                monstreList.Remove(monstre);
                monstre.DisplayMort();

                monPerso.GagnerExperience(new List<Monstre>() { monstre }, DifficultMode);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine();
                Console.WriteLine(monPerso.Caracteristique());
            }
            Console.WriteLine();
            Console.ReadKey(true);
        }

        public List<Monstre> GetListToFight(List<Monstre> monstreList)
        {
            List<Monstre> selectedMonsters = new List<Monstre>();

            if (!DifficultMode)
            {
                // Renvoi "simplement" la liste à attaqué
                selectedMonsters.AddRange(monstreList);
                return selectedMonsters;
            }

            // Choisir le(s) monstre que l'on souhaite attaquer
            Console.WriteLine("Quel monstre souhaitez-vous affronter :");

            for (int i = 0; i < monstreList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {monstreList[i]}");
            }

            string monstreAAttaquer = Console.ReadLine();

            if (!int.TryParse(monstreAAttaquer, out int monstreAAttaquerInt))
            {
                Console.WriteLine("Veuillez entrer un chiffre valide.");
            }
            if (monstreAAttaquerInt <= 1)
            {
                monstreAAttaquerInt = 1;
            }
            if (monstreAAttaquerInt > monstreList.Count)
            {
                monstreAAttaquerInt = monstreList.Count;
            }

            selectedMonsters.Add(monstreList[monstreAAttaquerInt - 1]);
            return selectedMonsters;
        }
    }

    // Static entry point
    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            Program program = new Program();
            program.Start();
        }
    }
}