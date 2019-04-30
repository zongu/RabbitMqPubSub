
namespace RabitMqPubSub.Applibs
{
    using System.Collections.Generic;
    using RabbitMQ.Client;

    internal static class RabbitMqFactory
    {
        private static ConnectionFactory factory;

        private static IConnection connection;

        private static Dictionary<string, IModel> models = new Dictionary<string, IModel>();

        private static bool TryAddModel(string topicName)
        {
            if (!models.ContainsKey(topicName))
            {
                var chennel = connection.CreateModel();
                chennel.ExchangeDeclare(topicName, "topic");
                models.Add(topicName, chennel);

                return true;
            }

            return false;
        }

        public static IModel GetChannel(string topicName)
        {
            TryAddModel(topicName);
            return models[topicName];
        }

        public static void Start(string hostUri)
        {
            factory = new ConnectionFactory();

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
