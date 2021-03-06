﻿
namespace RabitMqPubSub.Applibs
{
    using System;
    using System.Text;
    using Newtonsoft.Json;
    using RabbitMQ.Client;
    using RabitMqPubSub.Model;

    internal static class RabbitMqProducer
    {
        public static void PublishDirect<T>(string topicName, T data)
        {
            var channel = RabbitMqFactory.GetChannel(topicName, ExchangeType.Direct);
            var es = new RabbitMqEventStream(
                typeof(T).Name,
                JsonConvert.SerializeObject(data),
                TimeStampHelper.ToUtcTimeStamp(DateTime.Now));
            
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(es));
            var prop = channel.CreateBasicProperties();
            prop.Expiration = ConfigHelper.RmqExpiration;

            channel.BasicPublish(
                $"Exchange-{ExchangeType.Direct}-{topicName}",
                string.Empty,
                prop,
                body);
        }

        public static void PublishFanout<T>(string topicName, T data)
        {
            var channel = RabbitMqFactory.GetChannel(topicName, ExchangeType.Fanout);
            var es = new RabbitMqEventStream(
                typeof(T).Name,
                JsonConvert.SerializeObject(data),
                TimeStampHelper.ToUtcTimeStamp(DateTime.Now));

            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(es));
            var prop = channel.CreateBasicProperties();
            prop.Expiration = ConfigHelper.RmqExpiration;

            channel.BasicPublish(
                $"Exchange-{ExchangeType.Fanout}-{topicName}",
                string.Empty,
                prop,
                body);
        }
    }
}
