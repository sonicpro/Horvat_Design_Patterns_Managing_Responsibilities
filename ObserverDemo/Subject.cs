using System.Collections.Generic;

namespace ObserverDemo
{
    public class Subject : ISubject
    {
        protected string message;

        private List<IObserver> observers = new List<IObserver>();

        public virtual void Attach(IObserver observer)
        {
            observers.Add(observer);
        }

        public virtual void Detach(IObserver observer)
        {
            observers.Remove(observer);
        }

        public virtual void Notify(string message)
        {
            observers.ForEach(o => o.UpdateWithTheOriginalMessage(this, message));
        }

        public virtual void NotifyOfTheDataAppending(string completeMessage, string addedPart)
        {
            observers.ForEach(o => o.UpdateMessage(this, message, addedPart));
        }
    }
}
