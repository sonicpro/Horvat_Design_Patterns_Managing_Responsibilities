using System;

namespace ObserverDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var doer = new Doer();
            var logger = new Logger();
            doer.AfterDoSomethingWith += new UserInterface().UpdateWithTheOriginalMessage;
            doer.AfterDoSomethingWith += logger.UpdateWithTheOriginalMessage;
            doer.AfterDoMore += logger.UpdateMessage;
            doer.DoSomethingWith("my data");
            doer.DoMore("new message for the logger");
            Console.ReadLine();
        }
    }
}
