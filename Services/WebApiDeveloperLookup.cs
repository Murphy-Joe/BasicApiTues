using System.Net.Http.Headers;

namespace BasicApi.Services
{
    public class WebApiDeveloperLookup : ILookupOnCallDevelopers
    {
        private readonly HttpClient _httpClient;

        public WebApiDeveloperLookup(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "agents-api");
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<OnCallDeveloperInformation> GetOnCallDeveloperAsync()
        {
            var response = await _httpClient.GetAsync("/");
            if (!response.IsSuccessStatusCode)
            {
                throw new DeveloperApiException();
            }
            else
            {
                var content = await response.Content.ReadFromJsonAsync<OnCallDeveloperInformation>();
                return content;
            }
        }
    }
}
