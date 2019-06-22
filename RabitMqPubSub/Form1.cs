
namespace RabitMqPubSub
{
    using System;
    using System.Windows.Forms;
    using RabitMqPubSub.Applibs;
    using RabitMqPubSub.Model;

    public partial class Form1 : Form
    {
        delegate void PrintHandler(TextBox tb, string text);

        delegate void MarqueeHandler(Label lb, string text);

        public Form1()
        {
            InitializeComponent();
            this.cbTopic.SelectedIndex = 0;
            this.lbMarquee.Text = string.Empty;
            this.trMargueeMessaage.Start();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            var msg = this.tbMessage.Text;
            if (!string.IsNullOrEmpty(msg))
            {
                RabbitMqProducer.Publish(this.cbTopic.SelectedItem.ToString(), new SendMessage() { Content = msg });
            }

            this.tbMessage.Text = string.Empty;
        }

        public void PrintMessage(string message)
        {
            Print(this.tbOutput, message);
        }

        public void Print(TextBox tb, string text)
        {
            if (tb.InvokeRequired)
            {
                PrintHandler ph = new PrintHandler(Print);
                tb.Invoke(ph, tb, text);
            }
            else
            {
                tb.Text += $"{text}\r\n";
            }
        }

        public void MarqueeBocast(string marquee)
        {
            Marquee(this.lbMarquee, marquee);
        }

        public void Marquee(Label lb, string text)
        {
            if (lb.InvokeRequired)
            {
                var mh = new MarqueeHandler(Marquee);
                lb.Invoke(mh, lb, text);
            }
            else
            {
                lb.Text = text;
            }
        }

        private void trMargueeMessaage_Tick(object sender, EventArgs e)
        {
            RabbitMqProducer.Publish(ConfigHelper.QueueId, new MarqueeMessage() { Content = DateTime.Now.ToString() });
        }
    }
}