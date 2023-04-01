using ERC.Model;
using Microsoft.EntityFrameworkCore;

namespace ERC
{
    class ApplicationContext : DbContext
    {
        public DbSet<Service> Services { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Indicator> Indicators { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = utilities.db");
        }
    }
}
