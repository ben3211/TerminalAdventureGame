using SportApp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SportApp.Enum.EquipementEnum;

namespace SportApp.Class
{
    internal class SportManager :Sport
    {
        public SportManager(string sportName) : base(sportName) 
        {
        }

        public static List<Sport> GetSportByObject(SportEquipement equipement, List<Sport> sports)
        {
            // Créé une ouvelle liste pour ajouter les sports qui match 
            List<Sport> matchingSports = new List<Sport>();

            
            foreach (Sport sport in sports)
            {
                // Si équipement présent dans list sport, add to matchingSports list

                if (sport.RequiredMateriel.Contains(equipement))
                {
                    matchingSports.Add(sport);
                }
            }

            return matchingSports;
        }

        public override void DisplayRules()
        {
            throw new NotImplementedException();
        }
    }
}
