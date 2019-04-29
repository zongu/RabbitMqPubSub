
namespace RabitMqPubSub.Event
{
    using System;
    using Newtonsoft.Json;
    using RabitMqPubSub.Applibs;
    using RabitMqPubSub.Model;

    public class SendMessageHandler : IRabbitMqPubSubHamdler
    {
        public void Handle(RabbitMqEventStream stream)
        {
            try
            {
                var @event = JsonConvert.DeserializeObject<SendMessage>(stream.Data);
                ConfigHelper.BasicForm.PrintMessage(@event.Content);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SendMessageHandler Exception:{ex.Message}");
            }
        }
    }
}
