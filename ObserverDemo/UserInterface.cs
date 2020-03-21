namespace ObserverDemo
{
    class UserInterface
    {
        public readonly IObserver<string> OriginalMessageNotificationSink;

        public UserInterface()
        {
            this.OriginalMessageNotificationSink = new NotificationSink<string>(
                (sender, data) => this.UpdateWithTheOriginalMessage(sender, data));
        }

        public void UpdateWithTheOriginalMessage(object sender, string message)
        {
            System.Console.WriteLine($"Hey user, look at this data: {message.ToUpper()}");
        }
    }
}
