namespace WebApplication1
{
    public abstract class Entite
    {
        protected string Nom { get; set; }
        public int PointsDeVie { get; set; }
        protected int DegatsMin { get; set; }
        protected int DegatsMax { get; set; }
        protected int PointsDeDefence { get; set; }
        public int Experience { get; set; }
        protected Random random = new Random();


        public Entite(string nom)
        {
            this.Nom = nom;
        }

        public override string ToString()
        {
            return $"{Nom} ({Experience})";
        }

        public void Attaquer(Entite entiteVictime)
        {
            int degats = random.Next(DegatsMin, DegatsMax);

            ResumeCaracteristic(entiteVictime, degats);

            if (degats > entiteVictime.PointsDeVie / 2)
            {
                Console.WriteLine("Critical Strike!");
                entiteVictime.PointsDeVie = 0;
            }
            else
            {
                entiteVictime.PerdrePointsDeVie(degats, PointsDeDefence);
            }
        }

        protected void PerdrePointsDeVie(int pointsDevie, int PointsDeDefence)
        {
            this.PointsDeVie -= pointsDevie;
            this.PointsDeVie += PointsDeDefence;
            if (this.PointsDeVie <= 0)
            {
                this.PointsDeVie = 0;
            }
        }

        public bool EstMort()
        {
            return this.PointsDeVie <= 0;
        }

        public void DisplayMort()
        {
            Console.WriteLine(this.Nom + " est mort");
        }

        public void ResumeCaracteristic(Entite entiteVictime, int degats)
        {
            Console.WriteLine(this.Nom + "(" + this.PointsDeVie + ")" + " attaque : " + entiteVictime.Nom);
            Console.WriteLine(entiteVictime.Nom + " a perdu " + degats + " points de vie");
            Console.WriteLine("Il reste " + entiteVictime.PointsDeVie + " points de vie à " + entiteVictime.Nom);
        }
    }
}

