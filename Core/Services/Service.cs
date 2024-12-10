using Core.Utilities;
using System.Net;
using System.Net.Http.Json;

namespace Core.Services
{
    public class Service
    {
        private readonly IHttpClientFactory _clientFactory;

        public Service(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<PagedList<T>> GetEntities<T>()
            where T : class
        {
            var client = _clientFactory.CreateClient("Backend");

            var response = await client.GetAsync("/bugs");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<PagedList<T>>();

                return result!;
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new Exception("Requires login.");
            }

            return new PagedList<T>();
        }
    }
}
