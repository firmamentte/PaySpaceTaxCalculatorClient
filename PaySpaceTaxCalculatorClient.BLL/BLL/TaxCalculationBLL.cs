
using PaySpaceTaxCalculatorClient.BLL.DataContract;

namespace PaySpaceTaxCalculatorClient.BLL.BLL
{
    public class TaxCalculationBLL : SharedBLL
    {
        private readonly IHttpClientFactory HttpClientFactory;
        public TaxCalculationBLL(IHttpClientFactory httpClientFactory)
        {
            HttpClientFactory = httpClientFactory;
        }

        public async Task<List<AnnualIncomeTaxResp>> GetAnnualIncomeTaxes(string accessToken, string emailAddress)
        {
            using HttpClient _httpClient = CreatePaySpaceTaxCalculatorWebAPIHttpClient(HttpClientFactory);
            _httpClient.DefaultRequestHeaders.Add("AccessToken", accessToken);
            _httpClient.DefaultRequestHeaders.Add("EmailAddress", emailAddress);

            using HttpResponseMessage _httpResponseMessage = await _httpClient.GetAsync($"api/TaxCalculation/V1/GetTaxCalculationsByEmailAddress");

            if (!_httpResponseMessage.IsSuccessStatusCode)
                throw new Exception(ConstructClientError(await _httpResponseMessage.Content.ReadAsAsync<ApiErrorResp>()));

            return await _httpResponseMessage.Content.ReadAsAsync<List<AnnualIncomeTaxResp>>();
        }

        public async Task<AnnualIncomeTaxResp> CreateAnnualIncomeTax(string accessToken, string emailAddress, AnnualIncomeTaxReq annualIncomeTaxReq)
        {
            using HttpClient _httpClient = CreatePaySpaceTaxCalculatorWebAPIHttpClient(HttpClientFactory);
            _httpClient.DefaultRequestHeaders.Add("AccessToken", accessToken);
            _httpClient.DefaultRequestHeaders.Add("EmailAddress", emailAddress);

            using HttpResponseMessage _httpResponseMessage = await _httpClient.PostAsJsonAsync("api/TaxCalculation/V1/CreateAnnualIncomeTax", annualIncomeTaxReq);

            if (!_httpResponseMessage.IsSuccessStatusCode)
                throw new Exception(ConstructClientError(await _httpResponseMessage.Content.ReadAsAsync<ApiErrorResp>()));

            return await _httpResponseMessage.Content.ReadAsAsync<AnnualIncomeTaxResp>();
        }
    }
}
