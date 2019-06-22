
namespace RabitMqPubSub.Event
{
    using System;
    using Newtonsoft.Json;
    using RabitMqPubSub.Applibs;
    using RabitMqPubSub.Model;

    public class MarqueeMessageHandler : IRabbitMqPubSubHamdler
    {
        public void Handle(RabbitMqEventStream stream)
        {
            try
            {
                var @event = JsonConvert.DeserializeObject<MarqueeMessage>(stream.Data);
                ConfigHelper.BasicForm.MarqueeBocast(@event.Content);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"MarqueeMessageHandler Exception:{ex.Message}");
            }
        }
    }
}
