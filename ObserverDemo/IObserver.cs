namespace ObserverDemo
{
    public interface IObserver
    {
        void Update(ISubject subject);
    }
}
