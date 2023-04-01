using System.Linq;
using System.Windows;
using ERC.Model;
using ERC.Model.Calculations;

namespace ERC
{
    /// <summary>
    /// Расчеты услуг.
    /// </summary>
    public class Calculations
    {
        /// <summary>
        /// Текущие показания.
        /// </summary>
        public Indicator currentIndicators;

        /// <summary>
        /// Предыдущие показания.
        /// </summary>
        private Indicator lastIndicators;

        private Calculation cwc;
        private Calculation hwcCoolant;
        private Calculation hwcThermalEnergy;
        private Calculation eeDay;
        private Calculation eeNight;
        private Calculation ee;

        public float Total
        {
            get
            {
                return CWC.Price + HWCCoolant.Price + HWCThermalEnergy.Price + EE.Price;
            }
        }

        public Calculation CWC
        {
            get { return cwc; }
            set { cwc= value; }
        }

        public Calculation HWCCoolant
        {
            get { return hwcCoolant; }
            set { hwcCoolant = value; }
        }

        public Calculation HWCThermalEnergy
        {
            get { return hwcThermalEnergy; }
            set { hwcThermalEnergy = value; }
        }        
        
        public Calculation EEDay
        {
            get { return eeDay; }
            set { eeDay= value;}
        }        
        
        public Calculation EENight
        {
            get { return eeNight; }
            set { eeNight= value;}
        }
        
        public Calculation EE
        {
            get { return ee; }
            set { ee= value;}
        }

        public Calculations(float countPeopleInd, float cwcInd, float hwcInd, float eeDayInd, float eeNightInd)
        {
            currentIndicators = new Indicator(countPeopleInd, cwcInd, hwcInd, eeDayInd, eeNightInd, Authorization.authClient);
            InitLastIndicators();
            CalculateAllCalculations();
        }
        
        /// <summary>
        /// Рассчитать все услуги.
        /// </summary>
        private void CalculateAllCalculations()
        {
            CWC = new CWC(ServicesReference.CWC, currentIndicators.CWC, lastIndicators.CWC, currentIndicators.CountPeople, Switches.IsEnabledCWC);
            HWCCoolant = new HWCCoolant(ServicesReference.HWCCoolant, currentIndicators.HWC, lastIndicators.HWC, currentIndicators.CountPeople, Switches.IsEnabledHWC);
            HWCThermalEnergy = new HWCThermalEnergy(ServicesReference.HWCThermalEnergy, lastIndicators.HWC, currentIndicators.HWC, currentIndicators.CountPeople, HWCCoolant, Switches.IsEnabledHWC);
            EEDay = new EEDay(ServicesReference.EEDay, currentIndicators.EEDay, lastIndicators.EEDay, currentIndicators.CountPeople, Switches.IsEnabledEE);
            EENight = new EENight(ServicesReference.EENight, currentIndicators.EENight, lastIndicators.EENight, currentIndicators.CountPeople, Switches.IsEnabledEE);
            EE = new EE(ServicesReference.EE, EEDay, EENight, currentIndicators.CountPeople, Switches.IsEnabledEE);
        }

        /// <summary>
        /// Инициализация последних показаний клиента.
        /// </summary>
        private void InitLastIndicators()
        {
            var lastInd = DataBase.db.Indicators.Where(x => x.Client == Authorization.authClient).ToArray();
            if (lastInd.Length == 0) // Если не существует клиента, то создаем показания.
            {
                lastIndicators = new Indicator(Authorization.authClient);
                DataBase.db.Indicators.Add(lastIndicators);
                DataBase.db.SaveChanges();
            }
            else // Если существует, то присваем полю последних показаний.
            {
                lastIndicators = lastInd[0];
            }
        }

        /// <summary>
        /// Сохранение новых показаний.
        /// </summary>
        public void SaveIndicators()
        {
            lastIndicators.CWC = currentIndicators.CWC;
            lastIndicators.HWC = currentIndicators.HWC;
            lastIndicators.EEDay = currentIndicators.EEDay;
            lastIndicators.EENight = currentIndicators.EENight;
            lastIndicators.CountPeople = lastIndicators.CountPeople;
        }
    }
}
