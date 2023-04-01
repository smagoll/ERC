using System.Linq;

namespace ERC
{
    /// <summary>
    /// Авторизация.
    /// </summary>
    public static class Authorization
    {
        private static int idClient = 1;
        public static Client authClient;

        static Authorization()
        {
            authClient = DataBase.db.Clients.Where(x => x.Id == idClient).ToArray().First();
        }
    }
}
