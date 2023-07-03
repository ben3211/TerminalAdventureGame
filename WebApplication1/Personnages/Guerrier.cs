namespace WebApplication1.Personnages
{
    public class Guerrier : Personnage
    {
        public Guerrier(string nom) : base(nom, 120)
        {
            DegatsMax = 15;
            DegatsMin = 10;
            PointsDeDefence = 4;

        }
    }
}
