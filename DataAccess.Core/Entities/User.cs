using DataAccess.Core.Interfaces;

namespace DataAccess.Core.Entities
{
    public class User : IEntity<long>
    {
        public long Id { get; set; }

        public string Name { get; set; }
    }
}
