using System;

namespace ObserverDemo
{
    public class Doer : Subject
    {
        public void DoSomethingWith(string data)
        {
            payload = data;
            Notify();
        }
    }
}
