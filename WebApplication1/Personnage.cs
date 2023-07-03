using MyGame;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System;
using WebApplication1;

namespace WebApplication1
{
    public abstract class Personnage : Entite
    {
        public int PvInitial { get; set; }
        private int Niveau { get; set; }

        protected Personnage(string nom, int pvInitial) : base(nom)
        {
            Niveau = 1;
            Experience = 0;
            PvInitial = pvInitial;
            ReinitialiserPointsDeVie();
        }

        public override string ToString()
        {
            return $"{Nom} ({Niveau})";
        }

        public void GagnerExperience(List<Monstre> monstreList, bool DifficultMode)
        {
            if (monstreList == null || !monstreList.Any() || monstreList.Any(m => !m.EstMort()))
            {
                throw new Exception("Le(s) monstre(s) devrait(ent) être mort");
            }

            foreach (Monstre monstre in monstreList)
            {
                var allXp = this.Experience + monstre.Experience;
                this.Experience = allXp;
            }

            while (this.Experience >= ExperienceRequise())
            {
                Niveau += 1;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Bravo, niveau {Niveau} atteint!");

                PointsDeVie += 10;
                DegatsMax += 2;
                DegatsMin += 2;


                // Augmenter pvInitial +10
                this.PvInitial = this.PvInitial + 10;

                // Si difficulté = normal => réinitialiser point de vie
                if (DifficultMode == false)
                {
                    // Soigner = revenir pvInitial
                    ReinitialiserPointsDeVie();
                }
            }
        }

        public double ExperienceRequise()
        {
            return Math.Round(4 * (Math.Pow(Niveau, 3) / 5));
        }

        public string Caracteristique()
        {
            return this.Nom + "\n" +
                "Points de vie : " + PointsDeVie + "\n" +
                "Niveau : " + Niveau + "\n" +
                "Points d'expéririence : (" + Experience + ExperienceRequise() + ")" + "\n" +
                "Dégats : [" + DegatsMin + ";" + DegatsMax + "]";
        }

        // Ne pas rentrer deux fois la même valeur
        // remetre les pv
        public void ReinitialiserPointsDeVie()
        {
            PointsDeVie = this.PvInitial;
        }
    }
}



//List<Monstre> listMonstreAAttaquer = monstreList;
//List<Monstre> listMonstreAAttaquer = new List<Monstre>();

//if (DifficultMode)
//{
//    while (monstreList.Count > 0)
//    {
//        Console.WriteLine("Quel monstre souhaitez-vous affronter :");
//        for (int i = 0; i < monstreList.Count; i++)
//        {
//            Console.WriteLine($"{i} : {monstreList[i]}");
//        }

//        var monstreAAttaquer = Console.ReadLine();
//        if (!int.TryParse(monstreAAttaquer, out int monstreAAttaquerInt))
//        {
//            Console.WriteLine("Veuillez entrer un chiffre valide.");
//        }
//        if (monstreAAttaquerInt < 0 || monstreAAttaquerInt >= monstreList.Count)
//        {
//            Console.WriteLine("Index de monstre invalide. Veuillez réessayer.");
//        }

//        Monstre selectedMonstre = monstreList[monstreAAttaquerInt];
//        listMonstreAAttaquer.Add(selectedMonstre);
//        monstreList.RemoveAt(monstreAAttaquerInt);
//    }
//}

//// While -> Combattre temps que des éléments sont dans la list 
//while (monstreList.Count > 0 && victoire == true)
//{
//    // Tour du personnage
//    Console.ForegroundColor = ConsoleColor.Green;
//    if (DifficultMode)
//    {
//        Monstre monstre = monstreList[0];
//        monPerso.Attaquer(monstre);

//        RemoveFromListIfDead(monstre, monPerso, monstreMortList, DifficultMode);

//        // Si vie de P < 0 -> partie terminer

//        //if (monPerso.EstMort())
//        //{
//        //    victoire = false;
//        //    break;
//        //}
//    }

//    else
//    {
//        // Attaquer une fois tous les éléments de la list 
//        foreach (var monstre in monstreList)
//        {

//            monPerso.Attaquer(monstre);

//            RemoveFromListIfDead(monstre, monPerso, monstreMortList, DifficultMode);

//            // Si vie de P < 0 -> partie terminer
//            //if (monPerso.EstMort())
//            //{
//            //    victoire = false;
//            //    break;
//            //}
//        }
//    }