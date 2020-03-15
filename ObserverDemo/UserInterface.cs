using System.Collections.Generic;
using System.Linq;

namespace ObserverDemo
{
    class UserInterface : IObserver
    {
        List<ISubject> subjects = new List<ISubject>();

        public UserInterface(ISubject subject)
        {
            subjects.Add(subject);
        }

        public void Update(ISubject subject)
        {
            var publisher = subjects.FirstOrDefault(s => s.GetType() == subject.GetType());
            var payload = "";
            if (publisher != null)
            {
                payload = (string)subject.GetPayload() ?? "";
            }
            System.Console.WriteLine($"Hey user, look at this data: {payload.ToUpper()}");
        }
    }
}
