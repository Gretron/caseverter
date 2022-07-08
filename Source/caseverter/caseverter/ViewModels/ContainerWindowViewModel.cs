using caseverter.Core;
using Gma.System.MouseKeyHook;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;

namespace caseverter
{
    /// <summary>
    /// ViewModel for ContainerWindow
    /// </summary>
    public class ContainerWindowViewModel : BaseViewModel
    {
        #region Private Members

        /// <summary>
        /// Height of the Title Bar (int)
        /// </summary>
        private int mTitleBarHeight = 32;

        #endregion


        #region Public Properties

        /// <summary>
        /// Margin for Drop Shadow (int)
        /// </summary>
        public int ShadowMargin => 12;

        /// <summary>
        /// Margin for Drop Shadow (Thickness)
        /// </summary>
        public Thickness ShadowMarginThickness => new Thickness(ShadowMargin);


        /// <summary>
        /// Radius for Window Rounded Corners (int)
        /// </summary>
        public int WindowRadius => 16;

        /// <summary>
        /// Radius for Window Rounded Corners (CornerRadius)
        /// </summary>
        public CornerRadius WindowCornerRadius => new CornerRadius(WindowRadius);


        /// <summary>
        /// Height of the Title Bar (int)
        /// </summary>
        public int TitleBarHeight => mTitleBarHeight + ShadowMargin;

        /// <summary>
        /// Height of the Title Bar (GridLength)
        /// </summary>
        public GridLength TitleBarGridHeight => new GridLength(mTitleBarHeight);

        #endregion


        #region Commands

        /// <summary>
        /// Command to Open Settings Page
        /// </summary>
        public ICommand SettingsCommand { get; set; }

        /// <summary>
        /// Command to Minimize Window
        /// </summary>
        public ICommand MinimizeCommand { get; set; }

        /// <summary>
        /// Command to Close Window
        /// </summary>
        public ICommand CloseCommand { get; set; }

        #endregion


        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="window"></param>
        public ContainerWindowViewModel()
        {           
            // Set Command Actions
            SettingsCommand = new RelayCommand(() => ShowSettingsPage());
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Show Settings Page in Window
        /// </summary>
        public void ShowSettingsPage()
        {
            IoC.Get<ApplicationViewModel>().CurrentPage = ApplicationPage.Settings;

            HotkeyHelper.Instance.Dispose();

            SettingsCommand = new RelayCommand(() => ShowActionsPage());
        }

        /// <summary>
        /// Show Actions Page in Window
        /// </summary>
        public void ShowActionsPage()
        {
            IoC.Get<ApplicationViewModel>().CurrentPage = ApplicationPage.Actions;

            // Restart Window for Hotkeys to Reload
            Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }

        #endregion
    }
}
