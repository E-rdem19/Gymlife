using System.Dynamic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

namespace GymLife.Web.Services
{
    public class APIService
    {
        private readonly HttpClient _httpClient;

        // HttpClient parametreli constructor
        public APIService(HttpClient httpClient)
        {
            _httpClient = httpClient;

            // BaseAddress’i burada ayarlayabilirsin
            if (_httpClient.BaseAddress == null)
            {
                _httpClient.BaseAddress = new Uri("http://localhost:5003/");
            }
        }

        public async Task<List<T>> GetAllAsync<T>(string endpoint)
        {
            var response = await _httpClient.GetFromJsonAsync<List<T>>(endpoint);
            return response!;
        }

        public async Task<List<T>> GetContactsAsync<T>(string endpoint = "api/ContectApi/GetContact")
        {
            var response = await _httpClient.GetFromJsonAsync<List<T>>(endpoint);
            return response!;
        }
        public async Task<List<T>> GetBranchCategoryAsync<T>(string endpoint, int category)
        {
            var response = await _httpClient.GetFromJsonAsync<List<T>>($"{endpoint}/Category/{category}");
            return response!;
        }
        public async Task<List<T>> GetProgramAsync<T>(string endpoint = "api/CourseApi/Program")
        {
            var response = await _httpClient.GetFromJsonAsync<List<T>>(endpoint);
            return response!;
        }
        

        public async Task<T> GetByIdAsync<T>(string endpoint, int id)
        {
            var response = await _httpClient.GetFromJsonAsync<T>($"{endpoint}/{id}");
            return response!;
        }

        public async Task<HttpResponseMessage> CreateAsync<T>(string endpoint, T entity)
        {
            return await _httpClient.PostAsJsonAsync(endpoint, entity);
        }

        public async Task<HttpResponseMessage> UpdateAsync<T>(string endpoint, int id, T data)
        {
            return await _httpClient.PutAsJsonAsync($"{endpoint}/{id}", data);
        }

        public async Task<HttpResponseMessage> DeleteAsync(string endpoint, int id)
        {
            return await _httpClient.DeleteAsync($"{endpoint}/{id}");
        }
        public async Task<List<T>> GetBlogDetailsAsync<T>(string endpoint, int id)
        {
            var response = await _httpClient.GetFromJsonAsync<List<T>>($"{endpoint}/BlogDetails/{id}");
            return response!;
        }

    }
}