using Autofac;
using DataAccess.Context;
using DataAccess.Context.Repositories;
using DataAccess.Core.Interfaces;

namespace DataAccess.Tests
{
    public class TestModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CustomContext>().AsSelf().InstancePerDependency();

            builder.RegisterGeneric(typeof(BaseReadOnlyRepository<,>)).As(typeof(IReadOnlyRepository<,>)).InstancePerDependency();
            builder.RegisterGeneric(typeof(BaseReadWriteRepository<,>)).As(typeof(IReadWriteRepository<,>)).InstancePerDependency();

            base.Load(builder);
        }
    }
}
