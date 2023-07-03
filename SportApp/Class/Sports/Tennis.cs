using static SportApp.Enum.EquipementEnum;

namespace SportApp.Class.Sports
{
    internal class Tennis : Sport
    {
        public Tennis() : base("Tennis")
        {
            AddEqui(SportEquipement.Raquette);
            RemoveEquipement(SportEquipement.Maillot);
        }

        public void DisplayPoints()
        {
            throw new NotImplementedException();
        }

        public override void DisplayRules()
        {
            Console.WriteLine(@"ture, discovered the undoubtable source. 
                Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of 
                de Finibus Bonorum et Malorum (The Extremes of Good and Evil) 
                by Cicero, written in 45 BC. This book is a treatise on t");
        }
    }
}
