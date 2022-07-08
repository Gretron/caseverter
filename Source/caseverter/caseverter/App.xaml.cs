using caseverter.Core;
using System.Windows;

namespace caseverter
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Overriden Startup to Load IoC
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            // Base Method
            base.OnStartup(e);

            // Setup IoC
            IoC.Setup();

            var window = new ContainerWindow();

            // Setup FocusHelper
            FocusHelper.Setup(window);

            // Show ContainerWindow
            Current.MainWindow = window;

            Current.MainWindow.Show();
        }
    }
}
