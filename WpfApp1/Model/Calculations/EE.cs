namespace ERC.Model.Calculations
{
    /// <summary>
    /// Расчет "ЭЭ".
    /// </summary>
    public class EE : Calculation
    {
        private Calculation eeDay;
        private Calculation eeNight;
        public float price;

        public override float Size
        {
            get
            {
                if (eeDay.CurrentIndicator + eeNight.CurrentIndicator == 0)
                {
                    return GetSizeWithoutIndicators(CountPeople, Standard);
                }
                else
                {
                    return eeDay.Size + eeNight.Size;
                }
            }
        }

        public override float Price
        {
            get
            {
                if (IsEnabled)
                {
                    return eeDay.Price + eeNight.Price;
                }
                else
                {
                    return CalculationGeneral(Size, Rate);
                }
            }
        }

        public EE(Service service, Calculation eeDay, Calculation eeNight, float countPeople, bool isEnabled) : base(service, countPeople, isEnabled)
        {
            this.eeDay = eeDay;
            this.eeNight = eeNight;
            
        }
    }
}
