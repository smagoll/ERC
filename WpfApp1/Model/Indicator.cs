using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERC
{
    /// <summary>
    /// Показания.
    /// </summary>
    public class Indicator
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        public int Id { get; set; }
        public float CountPeople { get; set; }
        public float CWC { get; set; }
        public float HWC { get; set; }
        public float EEDay { get; set; }
        public float EENight { get; set; }

        [ForeignKey("Client")]
        public int ClientId { get; set; }
        public virtual Client? Client { get; set; }

        public Indicator() { }

        public Indicator(Client client) 
        {
            Client = client;
        }

        public Indicator(float countPeople, float cwc, float hwc, float eeDay, float eeNight, Client client) 
        {
            CountPeople = countPeople;
            CWC = cwc;
            HWC = hwc;
            EEDay = eeDay;
            EENight = eeNight;
            Client = client;
        }
    }
}
