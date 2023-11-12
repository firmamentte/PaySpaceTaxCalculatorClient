
namespace PaySpaceTaxCalculatorClient.BLL.DataContract
{
    public class AuthenticateResp
    {
        public string AccessToken { get; set; } = string.Empty;
        public DateTime AccessTokenExpiryDate { get; set; }
    }
}
