using System;

namespace ObserverDemo
{
    class Logger : IObserver
    {
        public void UpdateWithTheOriginalMessage(ISubject subject, string message)
        {
            Console.WriteLine($"Writing down the data: {message.ToUpper()}");
        }

        public void UpdateMessage(ISubject subject, string message, string addedPart)
        {
            Console.WriteLine($"Writing down appended data: {addedPart.ToUpper()}.");
        }
    }
}
