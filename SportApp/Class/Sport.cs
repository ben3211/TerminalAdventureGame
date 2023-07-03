using SportApp.Interface;
using static SportApp.Enum.EquipementEnum;

namespace SportApp.Class
{
    internal abstract class Sport : ISport
    {
        public string SportName { get; set; }
        public List<SportEquipement> RequiredMateriel { get; set; }

        public Sport(string sportName)
        {
            SportName = sportName;
            RequiredMateriel = new List<SportEquipement>() 
            {
                SportEquipement.Chaussure,
                SportEquipement.Maillot,
                SportEquipement.Ballon
            };
        }

        // List sports
        public static void SportList(List<Sport> sports)
        {
            Console.WriteLine();
            Console.WriteLine("Liste des sports");
            if (sports != null)
            {
                foreach (var c in sports)
                {
                    Console.WriteLine($"{c.SportName}");
                }
            }
            else
            {
                Console.WriteLine("Liste vide");
            }
        }

        public void AddEqui(SportEquipement equipement)
        {
            if (!RequiredMateriel.Contains(equipement))
                {
                    RequiredMateriel.Add(equipement);
                }
            else
                {
                    Console.WriteLine("Equipment already exists in the list.");
                }
        }

        public void RemoveEquipement (SportEquipement equipement)
        {
            if (RequiredMateriel.Contains(equipement))
            {
                RequiredMateriel.Remove(equipement);
            }
            else
            {
                Console.WriteLine("Equipement introuvable");
            }
        }

        public void DisplayPoints()
        {
            throw new NotImplementedException();
        }

        public void DisplayEquipement()
        {
            if (RequiredMateriel != null && RequiredMateriel.Any())
            {
                foreach (var item in RequiredMateriel)
                {
                    Console.WriteLine(item);
                }
            }
        }

        public static void DisplaySpeciality(string coachName)
        {
            Program program = new Program();
            List<Coach> coaches = program.GetCoaches();

            foreach (Coach coach in coaches)
            {
                if (coach.Name == coachName)
                {
                    Console.WriteLine($"Coach: {coach.Name}");
                    Console.WriteLine($"Speciality: {coach.Speciality}");
                    return;
                }
            }
            Console.WriteLine("Coach non trouvé");
        }

        public abstract void DisplayRules();
    }
}
