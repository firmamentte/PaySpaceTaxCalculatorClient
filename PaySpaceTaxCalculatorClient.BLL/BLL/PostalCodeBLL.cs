using PaySpaceTaxCalculatorClient.BLL.DataContract;

namespace PaySpaceTaxCalculatorClient.BLL.BLL
{
    public class PostalCodeBLL : SharedBLL
    {
        private readonly IHttpClientFactory HttpClientFactory;

        public PostalCodeBLL(IHttpClientFactory httpClientFactory)
        {
            HttpClientFactory = httpClientFactory;
        }

        public async Task<List<PostalCodeResp>> GetPostalCodes(string accessToken, string emailAddress)
        {
            using HttpClient _httpClient = CreatePaySpaceTaxCalculatorWebAPIHttpClient(HttpClientFactory);
            _httpClient.DefaultRequestHeaders.Add("AccessToken", accessToken);
            _httpClient.DefaultRequestHeaders.Add("EmailAddress", emailAddress);

            using HttpResponseMessage _httpResponseMessage = await _httpClient.GetAsync($"api/PostalCode/V1/GetPostalCodes");

            if (!_httpResponseMessage.IsSuccessStatusCode)
                throw new Exception(ConstructClientError(await _httpResponseMessage.Content.ReadAsAsync<ApiErrorResp>()));

            return await _httpResponseMessage.Content.ReadAsAsync<List<PostalCodeResp>>();
        }
    }
}
