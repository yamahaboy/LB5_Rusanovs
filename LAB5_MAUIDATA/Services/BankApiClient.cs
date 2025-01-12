using LAB5_MAUIDATA.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB5_MAUIDATA.Services
{
    public class BankApiClient : IBankApiClient
    {
        private readonly HttpClient _httpClient;

        public static string BaseAddress = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5253" : "http://localhost:5253";

        public BankApiClient()
        {
            _httpClient = new HttpClient();
        }

        public async Task<T[]> GetItemsAsync<T>(string url) where T : class
        {
            try
            {
                var fullUrl = $"{BaseAddress}/{url}";

                var request = new HttpRequestMessage(HttpMethod.Get, fullUrl);
                var response = await _httpClient.SendAsync(request);


                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<T[]>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetItemsAsync: {ex}");
                throw;
            }
        }



        public async Task DeleteItemAsync(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, $"{BaseAddress}/{url}");
            var response = await _httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateItem<T>(string url, T entity) where T : class
        {
            var request = new HttpRequestMessage(HttpMethod.Put, $"{BaseAddress}/{url}");

            var content = new StringContent(JsonConvert.SerializeObject(entity), null, "application/json");

            request.Content = content;

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }
        }
    }
