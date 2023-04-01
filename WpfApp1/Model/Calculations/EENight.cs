namespace ERC.Model.Calculations
{
    /// <summary>
    /// Расчет "ЭЭ ночь".
    /// </summary>
    public class EENight : Calculation
    {
        public EENight(Service service, float currInd, float lastInd, float countPeople, bool isEnabled) : base(service, currInd, lastInd, countPeople, isEnabled)
        {
        }
    }
}
