using SportApp.Enum;
using static SportApp.Enum.EquipementEnum;

namespace SportApp.Class.Sports
{
    internal class Rugby : Sport
    {
        public Rugby() : base("Rugby")
        {
            AddEqui(SportEquipement.ProtégeDents);
        }

        public override void DisplayRules()
        {
            Console.WriteLine(@"orem Ipsum is simply dummy
                text of the printing and typesetting industry. 
                Lorem Ipsum has been the industry's standard dummy 
                text ever since the 1500s, when an unknown printer took a
                galley of type and scrambled it to make a type specimen book. 
                It has survived not only five centuries, but also the lea");
        }
    }
}
