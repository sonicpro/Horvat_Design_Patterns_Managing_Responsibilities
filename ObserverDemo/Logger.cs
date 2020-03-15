using System.Collections.Generic;
using System.Linq;

namespace ObserverDemo
{
    class Logger : IObserver
    {
        List<ISubject> subjects = new List<ISubject>();

        public Logger(ISubject subjectImInterestedIn)
        {
            subjects.Add(subjectImInterestedIn);
        }

        public void Update(ISubject subject)
        {
            var publisher = subjects.FirstOrDefault(s => s.GetType() == subject.GetType());
            var payload = "";
            if (publisher != null)
            {
                payload = (string)subject.GetPayload() ?? "";
            }
            System.Console.WriteLine($"Writing down the data: {payload.ToUpper()}");
        }
    }
}
