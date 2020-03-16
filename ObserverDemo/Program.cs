using System;

namespace ObserverDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var doer = new Doer();
            doer.Attach(new UserInterface());
            doer.Attach(new Logger());
            doer.DoSomethingWith("my data");
            doer.DoMore("new message for the logger");
            Console.ReadLine();
        }
    }
}
