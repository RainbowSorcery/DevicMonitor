using DevicMonitor.View;
using DevicMonitor.ViewModel;
using System.Configuration;
using System.Data;
using System.Windows;

namespace DevicMonitor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            HomeWindows homeWindow = new HomeWindows();
            MainWindow mainWindow = new MainWindow();

            if (mainWindow.ShowDialog() == true)
            {
                homeWindow.ShowDialog();
            }

            Application.Current.Shutdown();
        }
}

}
