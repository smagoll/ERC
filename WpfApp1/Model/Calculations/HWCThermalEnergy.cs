namespace ERC.Model.Calculations
{
    /// <summary>
    /// Расчет "ГВС Тепловая энергия".
    /// </summary>
    public class HWCThermalEnergy : Calculation
    {
        private Calculation HWCCoolant { get; set; }
        public HWCThermalEnergy(Service service, float currInd, float lastInd, float countPeople, Calculation hwcCoolant, bool isEnabled) : base(service, currInd, lastInd, countPeople, isEnabled)
        {
            HWCCoolant = hwcCoolant;
        }

        public override float Size
        {
            get
            {
                return HWCCoolant.Size * Standard;
            }
        }
    }
}
