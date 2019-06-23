using Effort.Provider;
using NUnit.Framework;

namespace DataAccess.Tests
{
    [SetUpFixture]
    public class TestInitializer
    {
        [OneTimeSetUp]
        public void Initialize()
        {
            EffortProviderConfiguration.RegisterProvider();
            DiContainerConfiguration.BuildDiContainer();
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            DiContainerConfiguration.Container.Dispose();
        }
    }
}
