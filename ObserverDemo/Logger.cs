using System;

namespace ObserverDemo
{
    class Logger
    {
        public readonly IObserver<string> OriginalMessageNotificationSink;

        public readonly IObserver<(string, string)> UpdateMessageNotificationSink;

        public Logger()
        {
            this.OriginalMessageNotificationSink = new NotificationSink<string>(
                (sender, data) => this.UpdateWithTheOriginalMessage(sender, data));
            this.UpdateMessageNotificationSink = new NotificationSink<(string Message, string NewData)>(
                (sender, data) => this.UpdateMessage(sender, data.Message, data.NewData));
        }

        public void UpdateWithTheOriginalMessage(object sender, string message)
        {
            Console.WriteLine($"Writing down the data: {message.ToUpper()}");
        }

        public void UpdateMessage(object sender, string message, string addedPart)
        {
            Console.WriteLine($"Writing down appended data: {addedPart.ToUpper()}.");
        }
    }
}
