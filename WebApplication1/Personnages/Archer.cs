namespace WebApplication1.Personnages
{
    public class Archer : Personnage
    {
        public Archer(string nom) : base(nom, 105)
        {
            DegatsMax = 20;
            DegatsMin = 15;
            PointsDeDefence = 2;

        }
    }
}
