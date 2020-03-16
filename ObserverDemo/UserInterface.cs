namespace ObserverDemo
{
    class UserInterface : IObserver
    {
        public void UpdateWithTheOriginalMessage(ISubject subject, string message)
        {
            System.Console.WriteLine($"Hey user, look at this data: {message.ToUpper()}");
        }

        public void UpdateMessage(ISubject subject, string message, string addedPart)
        {
            // noop is here for the UserInterface observer.
        }
    }
}
