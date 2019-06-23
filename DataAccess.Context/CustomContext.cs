using System;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;

namespace DataAccess.Context
{
    public class CustomContext : DbContext
    {
        public CustomContext(string nameOrConnectionString, int? commandTimeout, bool lazyLoadingEnabled)
            : base(nameOrConnectionString)
        {
            Database.CreateIfNotExists();
            Database.CommandTimeout = commandTimeout;
            Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
            Configuration.AutoDetectChangesEnabled = false;
            Configuration.ValidateOnSaveEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public CustomContext()
            : this("ConnectionString", 900, false)
        {
        }

        public CustomContext(string nameOrConnectionString, int? commandTimeout)
            : this(nameOrConnectionString, commandTimeout, false)
        {
        }

        public CustomContext(DbConnection connection)
            : base(connection, true)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var configurations = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(type => !string.IsNullOrEmpty(type.Namespace))
                .Where(type => type.BaseType != null &&
                               type.BaseType.IsGenericType &&
                               type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));

            foreach (var configuration in configurations)
            {
                dynamic configurationInstance = Activator.CreateInstance(configuration);
                modelBuilder.Configurations.Add(configurationInstance);
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
