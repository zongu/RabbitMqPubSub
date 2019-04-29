
namespace RabitMqPubSub.Applibs
{
    using System.Linq;
    using System.Reflection;
    using Autofac;
    using RabitMqPubSub.Model;

    internal static class AutoFacConfig
    {
        public static IContainer Container;

        public static void Register()
        {
            var builder = new ContainerBuilder();

            var asm = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(asm)
                .Where(t => t.IsAssignableTo<IRabbitMqPubSubHamdler>())
                .Named<IPubSubHandler<RabbitMqEventStream>>(t => t.Name.Replace("Handler", string.Empty))
                .SingleInstance();

            Container = builder.Build();
        }
    }
}
