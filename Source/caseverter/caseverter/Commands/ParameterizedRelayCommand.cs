using System;
using System.Windows.Input;

namespace caseverter
{
    /// <summary>
    /// Parameterized Command That Can Always Execute
    /// </summary>
    public class ParameterizedRelayCommand : ICommand
    {
        #region Private Members

        /// <summary>
        /// The Action to Run
        /// </summary>
        private Action<object> mAction;

        #endregion

        #region Public Events

        /// <summary>
        /// Event That Fires When the <see cref="CanExecute(object)"/> Value Has Changed
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e) => { };

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="action"></param>
        public ParameterizedRelayCommand(Action<object> action)
        {
            mAction = action;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// A Relay Command Can Always Execute
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter) { return true; }

        /// <summary>
        /// Executes the Command Action
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            mAction(parameter);
        }

        #endregion
    }
}
