using System;
using System.Runtime.InteropServices;

namespace ObserverDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var doer = new Doer();
            doer.Attach(new UserInterface(doer));
            doer.Attach(new Logger(doer));
            doer.DoSomethingWith("my data");
        }
    }
}
