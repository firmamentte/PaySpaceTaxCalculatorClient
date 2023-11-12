
namespace PaySpaceTaxCalculatorClient.BLL.DataContract
{
    public class ApiErrorResp
    {
        public string Message { get; set; } = string.Empty;
        public IEnumerable<string> Errors { get; set; } =   Enumerable.Empty<string>();
    }
}
