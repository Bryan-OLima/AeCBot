using AeCBot.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace AeCBot.DAL
{
    public class AeCDAL : IAeCAPIContext
    {
        private readonly HttpClient _httpClient;
        public AeCDAL(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<T> GetConsult<T>(string url)
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var responseData = await response.Content.ReadFromJsonAsync<T>();
            return responseData;
        }
        public async Task<IAeCAPIContext> PostConsult<IAeCAPIContext>(string url, IAeCAPIContext data)
        {
            var response = await _httpClient.PostAsJsonAsync(url, data);
            response.EnsureSuccessStatusCode();
            var responseData = await response.Content.ReadFromJsonAsync<IAeCAPIContext>();
            return responseData;
        }
    }
}
