namespace WebApplication1.Monstres
{
    public class Plante : Monstre
    {
        public Plante(string nom) : base(nom)
        {
            this.PointsDeVie = random.Next(30, 50);
            DegatsMax = 11;
            DegatsMin = 4;
            PointsDeDefence = 5;
            Experience = 10;
        }
    }
}
