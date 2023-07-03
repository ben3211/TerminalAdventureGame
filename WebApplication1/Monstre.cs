using WebApplication1.Monstres;

namespace WebApplication1
{
    public class Monstre : Entite
    {
        public Monstre(string nom) : base(nom)
        {
        }

        public int GiveExperience(Entite uneEntite)
        {
            int experienceWin = this.Experience;
            return Experience += experienceWin;
        }
    }
}
