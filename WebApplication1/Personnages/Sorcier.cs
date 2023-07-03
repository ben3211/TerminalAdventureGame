namespace WebApplication1.Personnages
{
    public class Sorcier : Personnage
    {
        public Sorcier(string nom) : base(nom, 80)
        {
            DegatsMax = 25;
            DegatsMin = 10;
            PointsDeDefence = 0;
        }
    }
}
