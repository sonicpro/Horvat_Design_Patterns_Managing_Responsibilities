namespace ObserverDemo
{
    class UserInterface
    {
        public void UpdateWithTheOriginalMessage(object sender, string message)
        {
            System.Console.WriteLine($"Hey user, look at this data: {message.ToUpper()}");
        }
    }
}
