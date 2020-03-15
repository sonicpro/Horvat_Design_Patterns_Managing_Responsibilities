namespace ObserverDemo
{
    public interface ISubject
    {
        void Notify();

        void Attach(IObserver observer);

        void Detach(IObserver observer);

        object GetPayload();
    }
}
