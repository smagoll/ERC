using ERC.Model;
using ERC.Model.Calculations;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace ERC.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private float countPeople;
        private float cwc;
        private float hwc;
        private float eeDay;
        private float eeNight;
        private float total;

        private Calculations calculation;
        private bool isCalculate = false;

        private ObservableCollection<Calculation> calculationsPrint;

        public ObservableCollection<Calculation> CalculationsPrint
        {
            get { return calculationsPrint; }
            set { calculationsPrint= value; OnPropertyChanged(); }
        }

        public Calculations Calculation
        {
            get { return calculation; }
            set { calculation = value; OnPropertyChanged(); }
        }

        public float CountPeople
        {
            get { return countPeople; }
            set
            {
                    countPeople = value;
                    OnPropertyChanged();
            }
        }

        public float CWC
        {
            get { return cwc; }
            set
            {
                cwc = value;
                OnPropertyChanged();
            }
        }

        public float HWC
        {
            get { return hwc; }
            set
            {
                hwc = value;
                OnPropertyChanged();
            }
        }

        public float EEDay
        {
            get { return eeDay; }
            set
            {
                eeDay = value;
                OnPropertyChanged();
            }
        }

        public float EENight
        {
            get { return eeNight; }
            set
            {
                eeNight = value;
                OnPropertyChanged();
            }
        }

        public float Total
        {
            get { return total; }
            set 
            { 
                total = value; 
                OnPropertyChanged(); 
            }
        }

        /// <summary>
        /// Команда расчета услуг.
        /// </summary>
        public RelayCommand buttonCalculate
        {
            get
            {
                return new RelayCommand((o) =>
                {
                    Calculation = new Calculations(countPeople, cwc, hwc, eeDay, eeNight);
                    Total = calculation.Total;
                    InitCalculationPrint();
                    isCalculate = true;
                }, (o) =>
                {
                    return countPeople > 0;
                });
            }
        }
        
        /// <summary>
        /// Команда сохранения данных.
        /// </summary>
        public RelayCommand buttonSave
        {
            get
            {
                return new RelayCommand((o) =>
                {
                    UpdateIndicators();
                    DataBase.db.SaveChanges();
                }, (o) =>
                {
                    return isCalculate;
                });
            }
        }

        /// <summary>
        /// Обновление показаний в базе данных.
        /// </summary>
        private void UpdateIndicators()
        {
            calculation.SaveIndicators();
            DataBase.db.SaveChanges();
            Reset();
        }

        /// <summary>
        /// Сброс всех данных.
        /// </summary>
        private void Reset()
        {
            IsColdWater_Checked= false;
            IsHotWater_Checked= false;
            IsElectricity_Checked= false;
            isCalculate= false;
            CountPeople= 0;
            Total = 0;
            calculationsPrint.Clear();
        }

        public bool IsColdWater_Checked
        {
            get { return Switches.IsEnabledCWC; }
            set
            {
                if (value == false)
                {
                    CWC = 0;
                }
                Switches.IsEnabledCWC = value;
                OnPropertyChanged();
            }
        }

        public bool IsHotWater_Checked
        {
            get { return Switches.IsEnabledHWC; }
            set
            {
                if (value == false)
                {
                    HWC = 0;
                }
                Switches.IsEnabledHWC = value;
                OnPropertyChanged();
            }
        }
        
        public bool IsElectricity_Checked
        {
            get { return Switches.IsEnabledEE; }
            set
            {
                if (value == false)
                {
                    EEDay = 0;
                    EENight = 0;
                }
                Switches.IsEnabledEE = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Инициализация расчетов для вывода.
        /// </summary>
        public void InitCalculationPrint()
        {
            if (IsElectricity_Checked)
            {
                CalculationsPrint = new ObservableCollection<Calculation>
                {
                    calculation.CWC,
                    calculation.HWCCoolant,
                    calculation.HWCThermalEnergy,
                    calculation.EEDay,
                    calculation.EENight,
                    calculation.EE
                };
            }
            else
            {
                CalculationsPrint = new ObservableCollection<Calculation>
                {
                    calculation.CWC,
                    calculation.HWCCoolant,
                    calculation.HWCThermalEnergy,
                    calculation.EE
                };
            }
        }
    }
}
