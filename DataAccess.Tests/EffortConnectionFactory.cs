using System.Data.Common;
using System.Data.Entity.Infrastructure;
using Effort;

namespace DataAccess.Tests
{
    public class EffortConnectionFactory : IDbConnectionFactory
    {
        private static readonly object Locker = new object();

        private static DbConnection connection;

        public static void ResetDatabase()
        {
            lock (Locker)
            {
                connection = null;
            }
        }

        public DbConnection CreateConnection(string nameOrConnectionString)
        {
            lock (Locker)
            {
                if (connection == null)
                {
                    connection = DbConnectionFactory.CreateTransient();
                }

                return connection;
            }
        }
    }
}
