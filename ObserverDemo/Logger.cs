using System;

namespace ObserverDemo
{
    class Logger
    {
        public void UpdateWithTheOriginalMessage(object sender, string message)
        {
            Console.WriteLine($"Writing down the data: {message.ToUpper()}");
        }

        public void UpdateMessage(object sender, Tuple<string, string> data)
        {
            Console.WriteLine($"Writing down appended data: {data.Item2.ToUpper()}.");
        }
    }
}
