using System.ComponentModel;

namespace caseverter.Core
{
    /// <summary>
    /// Base ViewModel Using PropertyChanged Event
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Public Events

        /// <summary>
        /// PropertyChanged Event Fired When Property Value Changes
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        #endregion


        #region Public Methods

        /// <summary>
        /// Call <see cref="PropertyChanged"/> Event From Within Class
        /// </summary>
        /// <param name="name"></param>
        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}