using AGL.Api.ApplicationCore.Interfaces;

namespace AGL.Api.ApplicationCore.Services
{
    public class ApiClient : IApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public HttpClient HttpClient
        {
            get
            {
                return _httpClient;
            }
        }
    }
}
