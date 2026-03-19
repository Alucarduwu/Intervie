using System.Windows;
using PanaceaMediaPlayer.ViewModels;

namespace PanaceaMediaPlayer.Views
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as LoginViewModel;

            if (vm != null)
            {
                vm.Pin = PasswordBox.Password;
            }
        }
    }
}