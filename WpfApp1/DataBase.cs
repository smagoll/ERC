using Microsoft.EntityFrameworkCore;

namespace ERC
{
    static class DataBase
    {
        public static ApplicationContext db = new();

        static DataBase()
        {
            db.Database.EnsureCreated();
        }
    }
}
