using System;

namespace ObserverDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var doer = new Doer();
            doer.AfterDoSomethingWith += new UserInterface().OriginalMessageNotificationSink;
            doer.AfterDoSomethingWith += new Logger().OriginalMessageNotificationSink;
            doer.AfterDoMore += new Logger().UpdateMessageNotificationSink;
            doer.DoSomethingWith("my data");
            doer.DoMore("new message for the logger");
            Console.ReadLine();
        }
    }
}
