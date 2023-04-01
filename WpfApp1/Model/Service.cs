using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ERC
{
    /// <summary>
    /// Услуга.
    /// </summary>
    public class Service
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        public int Id { get; set; }
        public string? Name { get; set; }
        public float Rate { get; set; }
        public float Standard { get; set; }
        public string? Unit { get; set; }
    }
}
