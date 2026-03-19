using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using PanaceaMediaPlayer.Services;

namespace PanaceaMediaPlayer.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private readonly ApiService _apiService;

        private string _roomNumber;
        private string _pin;
        private string _status;

        public event Action<string> LoginSuccess;

        public LoginViewModel()
        {
            _apiService = new ApiService();
            LoginCommand = new RelayCommand(async _ => await Login());
        }

        public string RoomNumber
        {
            get => _roomNumber;
            set { _roomNumber = value; OnPropertyChanged(); }
        }

        public string Pin
        {
            get => _pin;
            set { _pin = value; OnPropertyChanged(); }
        }

        public string Status
        {
            get => _status;
            set { _status = value; OnPropertyChanged(); }
        }

        public ICommand LoginCommand { get; }

        private async Task Login()
        {
            try
            {
                Status = "Iniciando sesión...";

                var token = await _apiService.LoginAsync(RoomNumber, Pin);

                if (!string.IsNullOrWhiteSpace(token))
                {
                    Status = "Login exitoso";
                    LoginSuccess?.Invoke(token);
                }
                else
                {
                    Status = "No se recibió token.";
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Unknown authentication strategy"))
                {
                    Status = "El servidor de autenticación respondió con un error interno. La ruta existe, pero el backend parece mal configurado.";
                }
                else
                {
                    Status = "Error: " + ex.Message;
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}