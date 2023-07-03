using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SportApp.Enum.EquipementEnum;

namespace SportApp.Class.Sports
{
    internal class Football : Sport
    {

        public Football() : base("Football")
        {
        }


        public void DisplayPoints()
        {
            throw new NotImplementedException();
        }

        public override void DisplayRules()
        {
            Console.WriteLine(@"0s with the release of Letraset sheets 
                containing Lorem Ipsum passages, 
                and more recently with desktop publishing software 
                like Aldus PageMaker including versions");
        }
    }
}
