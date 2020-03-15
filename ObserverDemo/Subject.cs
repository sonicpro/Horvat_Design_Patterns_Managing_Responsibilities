using System.Collections.Generic;

namespace ObserverDemo
{
    public class Subject : ISubject
    {
        protected object payload;

        protected List<IObserver> observers = new List<IObserver>();

        public virtual void Attach(IObserver observer)
        {
            observers.Add(observer);
        }

        public virtual void Detach(IObserver observer)
        {
            observers.Remove(observer);
        }

        public virtual void Notify()
        {
            observers.ForEach(o => o.Update(this));
        }

        public object GetPayload() => payload;
    }
}
