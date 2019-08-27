
namespace RabitMqPubSub.Applibs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Newtonsoft.Json;
    using RabbitMQ.Client;
    using RabbitMQ.Client.Events;
    using RabitMqPubSub.Model;

    internal class RabbitMqConsumer
    {
        private IPubSubDispatcher<RabbitMqEventStream> dispatcher;

        private IEnumerable<string> exchangeTypes;

        private IEnumerable<string> queueNames;

        private string queueId;

        public RabbitMqConsumer(IEnumerable<string> exchangeTypes, IEnumerable<string> queueNames, IPubSubDispatcher<RabbitMqEventStream> dispatcher, string queueId)
        {
            this.exchangeTypes = exchangeTypes;
            this.queueNames = queueNames;
            this.dispatcher = dispatcher;
            this.queueId = queueId;
        }

        public void Register()
        {
            this.exchangeTypes.ToList().ForEach(exchangeType =>
            {

                this.queueNames.ToList().ForEach(topicName =>
                {
                    var channel = RabbitMqFactory.GetChannel(topicName, exchangeType);
                    //// generate queue
                    var queueName = channel.QueueDeclare($"{this.queueId}-{topicName}", false, false, false, null).QueueName;

                    //// bind queue to exchange
                    channel.QueueBind(queueName, $"Exchange-{exchangeType}-{topicName}", string.Empty, null);
                    var consumer = new EventingBasicConsumer(channel);

                    consumer.Received += (model, ea) =>
                    {
                        var @event = JsonConvert.DeserializeObject<RabbitMqEventStream>(Encoding.UTF8.GetString(ea.Body));
                        if (this.dispatcher.DispatchMessage(@event))
                        {
                            channel.BasicAck(ea.DeliveryTag, true);
                        }
                        else
                        {
                            channel.BasicNack(ea.DeliveryTag, true, true);
                        }
                    };

                    var consumerTag = channel.BasicConsume(queueName, false, $"{Environment.MachineName}", false, false, null, consumer);
                });
            });
        }
    }
}
