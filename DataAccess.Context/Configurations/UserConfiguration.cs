using System.Data.Entity.ModelConfiguration;
using DataAccess.Core.Entities;

namespace DataAccess.Context.Configurations
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            ToTable("Users", "dbo");
        }
    }
}
