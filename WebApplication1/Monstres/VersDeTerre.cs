namespace WebApplication1.Monstres
{
    public class VersDeTerre : Monstre
    {
        public VersDeTerre(string nom) : base(nom)
        {
            this.PointsDeVie = random.Next(20, 40);
            DegatsMax = 7;
            DegatsMin = 1;
            Experience = 5;
            PointsDeDefence = 2;
        }
    }
}
