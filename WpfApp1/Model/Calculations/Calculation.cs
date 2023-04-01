using System;
using System.Linq;

namespace ERC.Model.Calculations
{
    /// <summary>
    /// Расчет.
    /// </summary>
    public class Calculation
    {
        public string? Name { get; set; }
        public string? Unit { get; set; }
        public float Rate { get; set; }
        public float Standard { get; set; }
        public float CurrentIndicator { get; set; }
        public float LastIndicator { get; set; }
        public float CountPeople { get; set; }
        public bool IsEnabled { get; set; }

        public virtual float Price
        {
            get 
            {
                return CalculationGeneral(Size, Rate);
            }
            set
            {
                Price = value;
            }
        }

        public virtual float Size
        {
            get
            {
                if (IsEnabled)
                {
                    return GetSizeByIndicators(CurrentIndicator, LastIndicator);
                }
                else
                {
                    return GetSizeWithoutIndicators(CountPeople, Standard);
                }
            }
        }

        public Calculation() { }

        public Calculation(Service service, float currInd, float lastInd, float countPeople, bool isEnabled)
        {
            Name = service.Name;
            Unit = service.Unit;
            Rate = service.Rate;
            Standard = service.Standard;
            CurrentIndicator = currInd;
            LastIndicator = lastInd;
            CountPeople = countPeople;
            IsEnabled = isEnabled;
        }

        public Calculation(Service service, float countPeople, bool isEnabled)
        {
            Name= service.Name;
            Unit = service.Unit;
            Rate = service.Rate;
            Standard = service.Standard;
            CountPeople = countPeople;
            IsEnabled = isEnabled;
        }

        /// <summary>
        /// Общий расчет начислений за услугу.
        /// </summary>
        /// <param name="size">Объем.</param>
        /// <param name="rate">Тариф.</param>
        /// <returns>Сумма за услугу.</returns>
        public static float CalculationGeneral(float size, float rate)
        {
            return size * rate;
        }

        /// <summary>
        /// Расчет объема услуги с прибором учета.
        /// </summary>
        /// <param name="currInd">Текущие показания.</param>
        /// <param name="lastInd">Предыдущие показания.</param>
        /// <returns>Объем по показаниям.</returns>
        public static float GetSizeByIndicators(float currInd, float lastInd)
        {
            return currInd - lastInd;
        }

        /// <summary>
        /// Расчет объема услуги без прибора учета.
        /// </summary>
        /// <param name="countPeople">Количество людей, проживающих в помещении.</param>
        /// <param name="standard">Норматив потребления услуги на одного человека.</param>
        /// <returns>Объем без показаний.</returns>
        public static float GetSizeWithoutIndicators(float countPeople, float standard)
        {
            return countPeople * standard;
        }

    }
}
