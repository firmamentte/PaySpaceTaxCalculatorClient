using PaySpaceTaxCalculatorClient.BLL.DataContract;

namespace PaySpaceTaxCalculatorClient.BLL.BLL
{
    public class ApplicationUserBLL : SharedBLL
    {
        private readonly IHttpClientFactory HttpClientFactory;

        public ApplicationUserBLL(IHttpClientFactory httpClientFactory)
        {
            HttpClientFactory = httpClientFactory;
        }

        public async Task SignUp(string emailAddress, string password)
        {
            using HttpClient _httpClient = CreatePaySpaceTaxCalculatorWebAPIHttpClient(HttpClientFactory);
            _httpClient.DefaultRequestHeaders.Add("EmailAddress", emailAddress);
            _httpClient.DefaultRequestHeaders.Add("UserPassword", password);

            using HttpResponseMessage _httpResponseMessage = await _httpClient.PostAsJsonAsync("api/ApplicationUser/V1/SignUp", string.Empty);

            if (!_httpResponseMessage.IsSuccessStatusCode)
                throw new Exception(ConstructClientError(await _httpResponseMessage.Content.ReadAsAsync<ApiErrorResp>()));
        }

        public async Task<AuthenticateResp> Authenticate(string emailAddress, string password)
        {
            using HttpClient _httpClient = CreatePaySpaceTaxCalculatorWebAPIHttpClient(HttpClientFactory);
            _httpClient.DefaultRequestHeaders.Add("EmailAddress", emailAddress);
            _httpClient.DefaultRequestHeaders.Add("UserPassword", password);

            using HttpResponseMessage _httpResponseMessage = await _httpClient.PostAsJsonAsync("api/ApplicationUser/V1/Authenticate", string.Empty);

            if (!_httpResponseMessage.IsSuccessStatusCode)
                throw new Exception(ConstructClientError(await _httpResponseMessage.Content.ReadAsAsync<ApiErrorResp>()));

            _httpResponseMessage.Headers.TryGetValues("AccessToken", out IEnumerable<string> _accessToken);
            _httpResponseMessage.Headers.TryGetValues("AccessTokenExpiryDate", out IEnumerable<string> _accessTokenExpiryDate);

            return new AuthenticateResp()
            {
                AccessToken = _accessToken?.FirstOrDefault()!,
                AccessTokenExpiryDate = Convert.ToDateTime(_accessTokenExpiryDate?.FirstOrDefault()!)
            };
        }
    }
}
