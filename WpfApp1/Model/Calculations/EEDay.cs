namespace ERC.Model.Calculations
{
    /// <summary>
    /// Расчет "ЭЭ день"
    /// </summary>
    public class EEDay : Calculation
    {
        public EEDay(Service service, float currInd, float lastInd, float countPeople, bool isEnabled) : base(service, currInd, lastInd, countPeople, isEnabled)
        {
        }
    }
}
