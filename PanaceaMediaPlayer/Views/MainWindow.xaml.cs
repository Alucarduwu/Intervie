using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using PanaceaMediaPlayer.ViewModels;

namespace PanaceaMediaPlayer.Views
{
    public partial class MainWindow : Window
    {
        private static readonly HttpClient client = new HttpClient();

        private CancellationTokenSource _downloadCts;
        private string _currentTempFile;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void MediaList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var vm = DataContext as MainViewModel;
            if (vm == null) return;

            var item = vm.SelectedItem;

            if (item == null || string.IsNullOrEmpty(item.StreamUrl))
            {
                StopAndClearPlayer();
                return;
            }

            _downloadCts?.Cancel();
            _downloadCts = new CancellationTokenSource();

            try
            {
                StopAndClearPlayer();

                var tempFile = await DownloadProtectedToTempFileAsync(
                    item.StreamUrl,
                    vm.BearerToken,
                    _downloadCts.Token
                );

                if (!string.IsNullOrEmpty(tempFile))
                {
                    _currentTempFile = tempFile;
                    MainPlayer.Source = new Uri(tempFile);
                    MainPlayer.Play();
                }
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Descarga cancelada");
            }
            catch (Exception ex)
            {
                vm.StatusMessage = "Error reproduciendo: " + ex.Message;
                Console.WriteLine("ERROR GENERAL: " + ex.ToString());
            }
        }

        private async Task<string> DownloadProtectedToTempFileAsync(string url, string token, CancellationToken ct)
        {
            try
            {
                // 🔥 LIMPIAR HEADER ANTES (MUY IMPORTANTE)
                client.DefaultRequestHeaders.Authorization = null;

                if (!string.IsNullOrEmpty(token))
                {
                    client.DefaultRequestHeaders.Authorization =
                        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                }

                Console.WriteLine("URL: " + url);
                Console.WriteLine("TOKEN: " + token);

                using (var resp = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead, ct))
                {
                    var responseText = await resp.Content.ReadAsStringAsync();

                    // 🔥 DEBUG COMPLETO
                    Console.WriteLine("STATUS: " + resp.StatusCode);
                    Console.WriteLine("RESPUESTA: " + responseText);

                    if (!resp.IsSuccessStatusCode)
                    {
                        throw new Exception($"Error API: {resp.StatusCode} - {responseText}");
                    }

                    var contentType = resp.Content.Headers.ContentType?.MediaType;

                    string ext = ".mp4";

                    if (contentType == "video/webm")
                        ext = ".webm";
                    else if (contentType == "video/ogg")
                        ext = ".ogg";

                    var path = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ext);

                    using (var fs = new FileStream(path, FileMode.Create))
                    {
                        await resp.Content.CopyToAsync(fs);
                    }

                    return path;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR EN DESCARGA:");
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        private void StopAndClearPlayer()
        {
            try
            {
                MainPlayer.Stop();
                MainPlayer.Source = null;

                if (!string.IsNullOrEmpty(_currentTempFile) && File.Exists(_currentTempFile))
                {
                    File.Delete(_currentTempFile);
                    _currentTempFile = null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error limpiando player: " + ex.Message);
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            _downloadCts?.Cancel();
            StopAndClearPlayer();
        }
    }
}