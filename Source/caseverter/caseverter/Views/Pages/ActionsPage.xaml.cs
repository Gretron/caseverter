using System.Windows;
using System.Windows.Controls;

namespace caseverter
{
    /// <summary>
    /// Interaction logic for ActionsPage.xaml
    /// </summary>
    public partial class ActionsPage : BasePage<ActionsViewModel>
    {
        #region Private Members

        /// <summary>
        /// Context Menu Attached to the ActionsPage
        /// </summary>
        private ContextMenu mContextMenu;
        
        #endregion


        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ActionsPage()
        {
            InitializeComponent();

            // Set Application ContextMenu
            mContextMenu = Application.Current.TryFindResource("ApplicationMenu") as ContextMenu;
            mContextMenu.DataContext = DataContext;

            var viewModel = (ActionsViewModel)DataContext;
            viewModel.ShowMenuCommand = new RelayCommand(() => mContextMenu.IsOpen = true);
        }

        #endregion
    }
}
