
using PaySpaceTaxCalculatorClient.BLL;

namespace PaySpaceTaxCalculatorClient
{
    public static class PaySpaceTaxCalculatorClientApp
    {
        public static void InitializeApplicationSettings(this WebApplication app)
        {
            StaticClass.InitializeApplicationSettings(app.Configuration);
        }
    }
}
