using System;
using System.Collections.Generic;

namespace ObserverDemo
{
    public class MulticastNotifier<T>
    {
        private IList<IObserver<T>> invocationList;

        private MulticastNotifier(IObserver<T> observer)
        {
            invocationList = new[] { observer };
        }

        public MulticastNotifier(MulticastNotifier<T> notifier, IObserver<T> observer)
        {
            this.invocationList = new List<IObserver<T>>(notifier.invocationList);
            this.invocationList.Add(observer);
        }

        public virtual void Attach(IObserver<T> observer)
        {
            invocationList.Add(observer);
        }

        public virtual void Detach(IObserver<T> observer)
        {
            invocationList.Remove(observer);
        }

        public virtual void Notify(T message)
        {
            foreach (var o in invocationList)
            {
                o.Update(this, message);
            }
        }

        public static MulticastNotifier<T> operator+(MulticastNotifier<T> notifier, IObserver<T> observer)
        {
            if (notifier == null)
            {
                return new MulticastNotifier<T>(observer);
            }
            return new MulticastNotifier<T>(notifier, observer);
        }
    }
}
