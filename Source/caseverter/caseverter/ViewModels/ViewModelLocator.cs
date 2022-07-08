using caseverter.Core;

namespace caseverter
{
    /// <summary>
    /// Locator to Find ViewModels in IoC for XAML
    /// </summary>
    public class ViewModelLocator
    {
        #region Public Properties

        /// <summary>
        /// Instance of ViewModelLocator
        /// </summary>
        public static ViewModelLocator Instance { get; private set; } = new ViewModelLocator();

        #endregion


        #region Public Members

        /// <summary>
        /// Singleton ApplicationViewModel
        /// </summary>
        public static ApplicationViewModel ApplicationViewModel => IoC.Get<ApplicationViewModel>(); 

        #endregion
    }
}
