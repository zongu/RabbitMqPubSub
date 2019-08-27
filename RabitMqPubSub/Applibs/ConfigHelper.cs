

namespace RabitMqPubSub.Applibs
{
    using System.Collections.Generic;
    using System.Configuration;

    internal static class ConfigHelper
    {
        public static Form1 BasicForm { get; set; }

        public static readonly string RabbitMqUri = ConfigurationManager.AppSettings["RabbitMqUri"].ToString();

        public static readonly IEnumerable<string> SubQueueNames = ConfigurationManager.AppSettings["SubQueueNames"].ToString().Split(',');

        public static readonly IEnumerable<string> SubExchangeTypes = ConfigurationManager.AppSettings["SubExchangeTypes"].ToString().Split(',');

        public static readonly string QueueId = ConfigurationManager.AppSettings["QueueId"].ToString();

        public static readonly string RmqExpiration = ConfigurationManager.AppSettings["RmqExpiration"].ToString();
    }
}
