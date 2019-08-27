
namespace RabitMqPubSub.Applibs
{
    using System;
    using System.Collections.Generic;
    using RabbitMQ.Client;

    internal static class RabbitMqFactory
    {
        private static ConnectionFactory factory;

        private static IConnection connection;

        private static Dictionary<string, IModel> models = new Dictionary<string, IModel>();

        private static bool TryAddModel(string topicName, string exchangeType)
        {
            if (!models.ContainsKey($"{topicName}-{exchangeType}"))
            {
                var chennel = connection.CreateModel();
                chennel.ExchangeDeclare($"Exchange-{exchangeType}-{topicName}", exchangeType);
                models.Add($"{topicName}-{exchangeType}", chennel);

                return true;
            }

            return false;
        }

        public static IModel GetChannel(string topicName, string exchangeType)
        {
            TryAddModel(topicName, exchangeType);
            return models[$"{topicName}-{exchangeType}"];
        }

        public static void Start(string hostUri)
        {
            factory = new ConnectionFactory()
            {
                AutomaticRecoveryEnabled = true,
                NetworkRecoveryInterval = TimeSpan.FromSeconds(5)
            };
            
            connection = factory.CreateConnection(AmqpTcpEndpoint.ParseMultiple(ConfigHelper.RabbitMqUri));
        }

        public static void Stop()
        {
            foreach (var model in models)
            {
                model.Value.Abort();
                model.Value.Close();
            }

            models = new Dictionary<string, IModel>();
            connection.Abort();
            connection.Close();
            factory = null;
        }
    }
}
