using caseverter.Core;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;

namespace caseverter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ContainerWindow : Window
    {
        #region Constructor 

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ContainerWindow()
        {
            InitializeComponent();

            DataContext = new ContainerWindowViewModel();

            // Set Minimize & Close Commands
            var viewModel = (ContainerWindowViewModel)DataContext;
            viewModel.MinimizeCommand = new RelayCommand(() => WindowState = WindowState.Minimized);
            viewModel.CloseCommand = new RelayCommand(() => Close());
        }

        #endregion


        #region Event Handlers

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
 
            HotkeyHelper.Instance = new HotkeyHelper(this, null);

            // Set CurrentPage to Actions Page
            IoC.Get<ApplicationViewModel>().CurrentPage = ApplicationPage.Actions;
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            HotkeyHelper.Instance.Dispose();
        }

        #endregion
    }
}
