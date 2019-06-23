using System.Linq;
using DataAccess.Core.Entities;
using NUnit.Framework;

namespace DataAccess.Tests.Context
{
    [TestFixture]
    public class UnitOfWorkTests : BaseTestFixture
    {
        [Test]
        public void UserRepository_CreateNewEntities_NewEntitiesReturned()
        {
            var user = new User
            {
                Name = "Test User",
                Id = 1
            };

            Uow.UserRepository.Add(user);

            Uow.Save();

            var users = Uow.UserRepository.Get();

            Assert.AreEqual(1, users.Count());
        }

        [Test]
        public void UserRepository_RollBackTransaction_NoNewEntitiesAdded()
        {
            var user = new User
            {
                Name = "Test User",
                Id = 1
            };

            using (var transaction = Uow.BeginTransaction())
            {
                Uow.UserRepository.Add(user);

                Uow.Save();

                transaction.Rollback();
            }

            var users = Uow.UserRepository.Get();

            Assert.AreEqual(0, users.Count());
        }
    }
}
