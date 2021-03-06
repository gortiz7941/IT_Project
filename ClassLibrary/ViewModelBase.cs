using System.ComponentModel;


namespace IT_Project.ClassLibrary
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// The PropertyChanged Event to raise to any UI object
        /// The event is only invoked if data binding is used
        /// </summary>
        /// <param name="propertyName">The property name that is changing</param>
        protected void RaisePropertyChanged(string propertyName)
        {
            // Get handler
            PropertyChangedEventHandler handler = this.PropertyChanged;
            // Make sure handler exists
            if (handler != null)
            {
                PropertyChangedEventArgs args = new PropertyChangedEventArgs(propertyName);

                // Raise the PropertyChanged event.
                handler(this, args);
            }
        }
        #endregion

        public virtual void Close(bool wasCancelled = true)
        {
            Messanger.Instance.SendMessage(Messages.CLOSE_USER_CONTROL, wasCancelled);
        }
    }
}
