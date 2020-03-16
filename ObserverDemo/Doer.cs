using System;

namespace ObserverDemo
{
    public class Doer : Subject
    {
        public void DoSomethingWith(string data)
        {
            this.message = data;
            Notify(message);
        }

        public void DoMore(string newData)
        {
            this.message += newData;
            NotifyOfTheDataAppending(message, newData);
        }
    }
}
