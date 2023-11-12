using Microsoft.Extensions.Configuration;
using System.ComponentModel;
using System.Net.Http.Headers;

namespace PaySpaceTaxCalculatorClient.BLL
{
    public static class StaticClass
    {
        public static MediaTypeWithQualityHeaderValue MediaTypeWithQualityHeaderValue
        {
            get
            {
                return new MediaTypeWithQualityHeaderValue("application/json");
            }
        }

        public static string? PaySpaceTaxCalculatorClientWebAPIBaseAddress { get; set; }

        public static void InitializeApplicationSettings(IConfiguration configuration)
        {
            PaySpaceTaxCalculatorClientWebAPIBaseAddress ??= configuration["AppSettings:WebAPIUrls:PaySpaceTaxCalculatorClientWebAPIBaseAddress"]!;
        }
    }
}
