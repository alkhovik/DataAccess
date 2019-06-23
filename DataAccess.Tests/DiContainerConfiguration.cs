using Autofac;

namespace DataAccess.Tests
{
    public static class DiContainerConfiguration
    {
        public static IContainer Container { get; private set; }

        public static void BuildDiContainer()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<TestModule>();
            Container = containerBuilder.Build();
        }
    }
}
