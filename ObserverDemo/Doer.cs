namespace ObserverDemo
{
    public class Doer
    {
        private string message;

        // You can replace these two fields with the events ot types EventHandler<string> and EventHandler<(string Message, string NewData)> respectively.
        // Drop the MulticastNotifier<T> class and IObserver<T> interface once you do so.
        public MulticastNotifier<string> AfterDoSomethingWith;

        public MulticastNotifier<(string Message, string NewData)> AfterDoMore;

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

        #region Helper methods

        private void OnAfterDoSomethingWith(string data)
        {
            if (AfterDoSomethingWith != null)
            {
                AfterDoSomethingWith.Notify(message);
            }
        }

        private void OnAfterDoMore(string updatedData, string newData)
        {
            if (AfterDoMore != null)
            {
                AfterDoMore.Notify((message, newData));
            }
        }

        #endregion
    }
}
