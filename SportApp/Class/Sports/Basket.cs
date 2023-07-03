using SportApp.Interface;
using static SportApp.Enum.EquipementEnum;
using static SportApp.Class.Sport;

namespace SportApp.Class.Sports
{
    internal class Basket : Sport
    {
        public Basket() : base("Basket")
        {
        }

        public void DisplayPoints()
        {
            throw new NotImplementedException();
        }

        public override void DisplayRules()
        {
            Console.WriteLine(@"Contrary to popular belief, Lorem Ipsum is not simply random text.
                It has roots in a piece of classical Latin literature from 45 BC,
                making it over 2000 years old. Richard McClintock,
                a Latin professor at Hampden-Sydney College in Virginia, looked");
        }
    }
}
