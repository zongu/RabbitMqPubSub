
namespace RabitMqPubSub
{
    using System;
    using System.Windows.Forms;
    using RabitMqPubSub.Applibs;
    using RabitMqPubSub.Model;

    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {   
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AutoFacConfig.Register();
            RabbitMqFactory.Start(ConfigHelper.RabbitMqUri);

            var consumer = new RabbitMqConsumer(
                ConfigHelper.SubExchangeTypes,
                ConfigHelper.SubQueueNames,
                new PubSubDispatcher<RabbitMqEventStream>(AutoFacConfig.Container),
                ConfigHelper.QueueId);
            consumer.Register();

            ConfigHelper.BasicForm = new Form1();
            Application.Run(ConfigHelper.BasicForm);
            RabbitMqFactory.Stop();
        }
    }
}
