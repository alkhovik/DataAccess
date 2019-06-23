using Autofac;
using DataAccess.Context;
using NUnit.Framework;

namespace DataAccess.Tests
{
    [TestFixture]
    public class BaseTestFixture
    {
        protected UnitOfWork Uow { get; private set; }

        [SetUp]
        public void Initialize()
        {
            Uow = new UnitOfWork(DiContainerConfiguration.Container.Resolve<CustomContext>());
            EffortConnectionFactory.ResetDatabase();
        }

        [TearDown]
        public void Cleanup()
        {
            Uow.Dispose();
        }
    }
}
