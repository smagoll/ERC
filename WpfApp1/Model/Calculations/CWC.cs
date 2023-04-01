namespace ERC.Model.Calculations
{
    /// <summary>
    /// Расчет "ГВС".
    /// </summary>
    public class CWC : Calculation
    {
        public CWC(Service service, float currInd, float lastInd, float countPeople, bool isEnabled) : base(service, currInd, lastInd, countPeople, isEnabled)
        {
        }
    }
}
