﻿
namespace RabitMqPubSub.Applibs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Newtonsoft.Json;
    using RabbitMQ.Client.Events;
    using RabitMqPubSub.Model;

    internal class RabbitMqConsumer
    {
        private IPubSubDispatcher<RabbitMqEventStream> dispatcher;

        private IEnumerable<string> queueNames;

        private string queueId;

        public RabbitMqConsumer(IEnumerable<string> queueNames, IPubSubDispatcher<RabbitMqEventStream> dispatcher, string queueId)
        {
            this.queueNames = queueNames;
            this.dispatcher = dispatcher;
            this.queueId = queueId;
        }

        public void Register()
        {
            this.queueNames.ToList().ForEach(topicName =>
            {
                var channel = RabbitMqFactory.GetChannel(topicName);
                //// generate queue
                var queueName = channel.QueueDeclare(topicName, false, false, false, null).QueueName;

                //// bind queue to exchange
                channel.QueueBind(queueName, topicName, topicName, null);
                var consumer = new EventingBasicConsumer(channel);

                consumer.Received += (model, ea) =>
                {
                    var @event = JsonConvert.DeserializeObject<RabbitMqEventStream>(Encoding.UTF8.GetString(ea.Body));
                    if (this.dispatcher.DispatchMessage(@event))
                    {

                    }
                };

                var consumerTag = channel.BasicConsume(queueName, true, $"{Environment.MachineName}", false, false, null, consumer);
            });
        }
    }
}
