
namespace RabitMqPubSub.Applibs
{
    using System;
    using System.Text;
    using Newtonsoft.Json;
    using RabbitMQ.Client;
    using RabitMqPubSub.Model;

    internal static class RabbitMqProducer
    {
        public static void Publish<T>(string exchangeName, T data)
        {
            var channel = RabbitMqFactory.GetChannel(exchangeName);
            var es = new RabbitMqEventStream(
                typeof(T).Name,
                JsonConvert.SerializeObject(data),
                TimeStampHelper.ToUtcTimeStamp(DateTime.Now));
            
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(es));
            channel.BasicPublish(
                exchangeName,
                exchangeName,
                null,
                body);
        }
    }
}
