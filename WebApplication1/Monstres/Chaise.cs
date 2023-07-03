namespace WebApplication1
{
    public class Chaise : Monstre
    {
        public Chaise(string nom) : base(nom)
        {
            this.PointsDeVie = random.Next(40, 60);
            DegatsMax = 15;
            DegatsMin = 6;
            Experience = 15;
            PointsDeDefence = 20;

        }
    }
}
