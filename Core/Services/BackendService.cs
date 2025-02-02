using Core.Models;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Json;
using System.Text.Json;

namespace Core.Services
{
    public class BackendService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly JsonSerializerOptions _jsonOptions;
        private readonly IHttpContextAccessor _contextAccessor;

        public BackendService(IHttpClientFactory clientFactory, IHttpContextAccessor contextAccessor)
        {
            _clientFactory = clientFactory;
            _contextAccessor = contextAccessor;

            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<ApiResponseModel<T>> Get<T>(string requestUri)
            where T : class, new()
        {
            HttpClient client = CreateBackendClient();

            var response = await client.GetAsync(requestUri);

            return await ParseResponse<T>(response);
        }

        public async Task<ApiResponseModel<T>> Post<T>(string requestUri, object model)
            where T : class, new()
        {
            HttpClient client = CreateBackendClient();

            var content = JsonContent.Create(model);

            var response = await client.PostAsync(requestUri, content);

            return await ParseResponse<T>(response);
        }

        public async Task<ApiResponseModel<T>> Patch<T>(string requestUri, object model)
            where T : class, new()
        {
            HttpClient client = CreateBackendClient();

            var content = JsonContent.Create(model);

            var response = await client.PatchAsync(requestUri, content);

            return await ParseResponse<T>(response);
        }

        public async Task<ApiResponseModel<T>> Put<T>(string requestUri, object model)
            where T : class, new()
        {
            HttpClient client = CreateBackendClient();

            var content = JsonContent.Create(model);

            var response = await client.PutAsync(requestUri, content);

            return await ParseResponse<T>(response);
        }

        public async Task<ApiResponseModel<T>> Delete<T>(string requestUri)
            where T : class, new()
        {
            HttpClient client = CreateBackendClient();

            var response = await client.DeleteAsync(requestUri);

            return await ParseResponse<T>(response);
        }

        private HttpClient CreateBackendClient()
        {
            var client = _clientFactory.CreateClient("Backend");

            var tokenClaim = _contextAccessor.HttpContext.User.FindFirst(c => c.Type == "Token");

            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {tokenClaim?.Value}");

            return client;
        }

        private async Task<ApiResponseModel<T>> ParseResponse<T>(HttpResponseMessage response) where T : class, new()
        {
            string contentString = await response.Content.ReadAsStringAsync();

            T resource;

            if (!string.IsNullOrWhiteSpace(contentString))
            {
                resource = JsonSerializer.Deserialize<T>(contentString, _jsonOptions!);
            }
            else
            {
                resource = new T();
            }

            return new ApiResponseModel<T>
            {
                StatusCode = response.StatusCode,
                Resource = resource
            };
        }
    }
}
