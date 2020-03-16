namespace ObserverDemo
{
    public interface ISubject
    {
        void Notify(string message);

        void NotifyOfTheDataAppending(string completeMessage, string addedPart);

        void Attach(IObserver observer);

        void Detach(IObserver observer);
    }
}
