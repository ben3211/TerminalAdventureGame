using static SportApp.Enum.EquipementEnum;

namespace SportApp.Interface
{
    internal interface ISport
    {
        string SportName { get; set; }
        //public List<SportEquipement> RequiredMateriel { get; set; }
        void DisplayRules();
        void DisplayPoints();
        void DisplayEquipement();
    }
}
