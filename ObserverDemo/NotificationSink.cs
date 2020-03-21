using System;

namespace ObserverDemo
{
    class NotificationSink<T> : IObserver<T>
    {
        // Each combination of object and T represents unique notifier + type of notification data combination.
        private Action<object, T> action;

        public NotificationSink(Action<object, T> handler)
        {
            action = handler;
        }

        public void Update(object sender, T data)
        {
            this.action(sender, data);
        }
    }
}
