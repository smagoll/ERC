
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ERC
{
    /// <summary>
    /// Справка о нормативах и тарифах услуг.
    /// </summary>
    public struct ServicesReference
    {
        private static Service cwc;
        private static Service hwcCoolant;
        private static Service hwcThermalEnergy;
        private static Service ee;
        private static Service eeDay;
        private static Service eeNight;

        public static Service CWC
        {
            get { return cwc; }
            set { cwc = value; }
        }

        public static Service HWCCoolant
        {
            get { return hwcCoolant; }
            set { hwcCoolant = value; }
        }

        public static Service HWCThermalEnergy
        {
            get { return hwcThermalEnergy; }
            set { hwcThermalEnergy = value; }
        }

        public static Service EE
        {
            get { return ee; }
            set { ee = value; }
        }

        public static Service EEDay
        {
            get { return eeDay; }
            set { eeDay = value; }
        }

        public static Service EENight
        {
            get { return eeNight; }
            set { eeNight = value; }
        }

        static ServicesReference()
        {
            try
            {
                var services = DataBase.db.Services.Select(x => x).ToArray();
                foreach (var service in services)
                {
                    switch (service.Name)
                    {
                        case "ХВС":
                            CWC = service;
                            break;
                        case "ГВС Теплоноситель":
                            HWCCoolant = service;
                            break;
                        case "ГВС Тепловая энергия":
                            HWCThermalEnergy = service;
                            break;
                        case "ЭЭ":
                            EE = service;
                            break;
                        case "ЭЭ день":
                            EEDay = service;
                            break;
                        case "ЭЭ ночь":
                            EENight = service;
                            break;
                    }
                }
            }
            catch
            {
                Console.WriteLine("");
            }           
        }
    }
}
