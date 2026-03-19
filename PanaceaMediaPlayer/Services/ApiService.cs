using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PanaceaMediaPlayer.Models;

namespace PanaceaMediaPlayer.Services
{
    public class ApiService
    {
        private static readonly HttpClient client = CreateClient();
        private const string BaseUrl = "https://api.i3panacea.com";

        

        private static HttpClient CreateClient()
        {
            var handler = new HttpClientHandler();

            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;

            var httpClient = new HttpClient(handler)
            {
                Timeout = TimeSpan.FromSeconds(20)
            };

            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            return httpClient;
        }

        public void SetToken(string token)
        {
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
        }

        public void ClearToken()
        {
            client.DefaultRequestHeaders.Authorization = null;
        }

        public async Task<string> LoginAsync(string roomNumber, string pin)
        {
            try
            {
                ClearToken();

                var url = "https://api.i3panacea.com/login"; // o la ruta que te respondió 500 y no 404

                var data = new
                {
                    room_number = roomNumber,
                    pin = pin
                };

                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(url, content);
                var resultJson = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                    throw new Exception($"Error login ({(int)response.StatusCode}): {resultJson}");

                var result = JsonConvert.DeserializeObject<LoginResponse>(resultJson);
                return result?.Token;
            }
            catch (Exception ex)
            {
                throw new Exception("Fallo en LoginAsync: " + ex.ToString(), ex);
            }
        }

        public async Task<List<MediaItem>> GetMediaItemsAsync()
        {
            try
            {
                var response = await client.GetAsync($"{BaseUrl}/content");
                var json = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                    throw new Exception($"Error obteniendo contenido ({(int)response.StatusCode}): {json}");

                var result = JsonConvert.DeserializeObject<ContentResponse>(json);
                return result?.Items ?? new List<MediaItem>();
            }
            catch (Exception ex)
            {
                throw new Exception("Fallo en GetMediaItemsAsync: " + ex.ToString(), ex);
            }
        }
    }
}