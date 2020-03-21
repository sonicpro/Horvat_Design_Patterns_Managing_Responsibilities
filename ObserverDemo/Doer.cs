using System;

namespace ObserverDemo
{
    public class Doer
    {
        private string message;

        public event EventHandler<string> AfterDoSomethingWith;

        public event EventHandler<Tuple<string, string>> AfterDoMore;

        public void DoSomethingWith(string data)
        {
            this.message = data;
            OnAfterDoSomethingWith(message);
        }

        public void DoMore(string newData)
        {
            this.message += newData;
            OnAfterDoMore(message, newData);
        }

        #region "Raise events" methods

        private void OnAfterDoSomethingWith(string data)
        {
            if (AfterDoSomethingWith != null)
            {
                AfterDoSomethingWith?.Invoke(this, message);
            }
        }

        private void OnAfterDoMore(string updatedData, string newData)
        {
            if (AfterDoMore != null)
            {
                AfterDoMore?.Invoke(this, Tuple.Create(updatedData, newData));
            }
        }

        #endregion
    }
}
