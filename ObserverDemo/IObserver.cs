namespace ObserverDemo
{
    public interface IObserver
    {
        void UpdateWithTheOriginalMessage(ISubject subject, string message);

        void UpdateMessage(ISubject subject, string message, string addedPart);
    }
}
