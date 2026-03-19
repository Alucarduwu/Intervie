using System.Net;
using System.Windows;
using PanaceaMediaPlayer.Views;
using PanaceaMediaPlayer.ViewModels;

namespace PanaceaMediaPlayer
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            ServicePointManager.SecurityProtocol =
                SecurityProtocolType.Tls12 |
                SecurityProtocolType.Tls11 |
                SecurityProtocolType.Tls;

            base.OnStartup(e);

            var loginWindow = new LoginWindow();
            var loginVM = new LoginViewModel();

            loginWindow.DataContext = loginVM;

            loginVM.LoginSuccess += (token) =>
            {
                var mainWindow = new MainWindow();
                mainWindow.DataContext = new MainViewModel(token);
                mainWindow.Show();

                loginWindow.Close();
            };

            loginWindow.Show();
        }
    }
}