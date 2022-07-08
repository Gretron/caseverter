using caseverter.Core;
using System.Windows.Controls;

namespace caseverter
{
    /// <summary>
    /// Base Page for All Pages to Gain Base Functionality From
    /// </summary>
    public class BasePage<T> : Page
        where T : BaseViewModel, new()
    {
        #region Private Members

        /// <summary>
        /// ViewModel Associated to this Page
        /// </summary>
        private T mViewModel;

        #endregion


        #region Public Properties

        /// <summary>
        /// ViewModel Associated to this Page
        /// </summary>
        private T ViewModel
        {
            get => mViewModel;
            set
            {
                // If Value Is No Different, Return
                if (mViewModel == value)
                    return;

                // Set New Value
                mViewModel = value;

                // Set DataContext to New Value
                DataContext = mViewModel;
            }
        }

        #endregion


        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public BasePage()
        {
            // Set DataContext to Generic ViewModel
            DataContext = new T();
        }

        #endregion
    }
}
