namespace ERC.Model.Calculations
{
    /// <summary>
    /// Расчет "ГВС Теплоноситель".
    /// </summary>
    public class HWCCoolant : Calculation
    {
        public HWCCoolant(Service service, float currInd, float lastInd, float countPeople, bool isEnabled) : base(service, currInd, lastInd, countPeople, isEnabled)
        {
        }
    }
}
