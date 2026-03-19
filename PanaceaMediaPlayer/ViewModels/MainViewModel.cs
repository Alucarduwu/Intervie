using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using PanaceaMediaPlayer.Models;
using PanaceaMediaPlayer.Services;

namespace PanaceaMediaPlayer.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly ApiService _apiService;

        private ObservableCollection<MediaItem> _mediaItems;
        private MediaItem _selectedItem;
        private bool _isLoading;
        private string _statusMessage;
        private string _bearerToken;

        public MainViewModel(string token)
        {
            _apiService = new ApiService();
            MediaItems = new ObservableCollection<MediaItem>();

            BearerToken = token;

            LoadDataCommand = new RelayCommand(async _ => await LoadDataAsync());

            _ = LoadDataAsync();
        }

        public ObservableCollection<MediaItem> MediaItems
        {
            get => _mediaItems;
            set { _mediaItems = value; OnPropertyChanged(); }
        }

        public MediaItem SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(HasSelectedMedia));
                OnPropertyChanged(nameof(NotHasSelectedMedia));
            }
        }

        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(NotLoading));
            }
        }

        public bool NotLoading => !IsLoading;

        public string StatusMessage
        {
            get => _statusMessage;
            set { _statusMessage = value; OnPropertyChanged(); }
        }

        public string BearerToken
        {
            get => _bearerToken;
            set
            {
                _bearerToken = value;
                OnPropertyChanged();
            }
        }

        public bool HasSelectedMedia => SelectedItem != null;
        public bool NotHasSelectedMedia => SelectedItem == null;

        public ICommand LoadDataCommand { get; }

        public async Task LoadDataAsync()
        {
            IsLoading = true;
            StatusMessage = "Trayendo contenido...";

            try
            {
                Console.WriteLine("TOKEN USADO: " + BearerToken);

                if (string.IsNullOrEmpty(BearerToken))
                {
                    StatusMessage = "⚠️ Token no configurado";
                    return;
                }

                _apiService.SetToken(BearerToken);

                var items = await _apiService.GetMediaItemsAsync();

                MediaItems.Clear();

                foreach (var item in items)
                {
                    MediaItems.Add(item);
                }

                StatusMessage = items.Count > 0
                    ? $"Listo: {items.Count} videos encontrados."
                    : "No se encontró nada.";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
                Console.WriteLine("ERROR VM: " + ex.ToString());
            }
            finally
            {
                IsLoading = false;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;

        public RelayCommand(Action<object> execute) => _execute = execute;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter) => _execute(parameter);

        public event EventHandler CanExecuteChanged { add { } remove { } }
    }
}