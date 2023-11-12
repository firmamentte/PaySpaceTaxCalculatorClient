using System.ComponentModel;

namespace PaySpaceTaxCalculatorClient.Controllers.ControllerHelpers
{
    public static class EnumHelper
    {
        public enum MessageSymbol
        {
            [Description("i")]
            Information,
            [Description("x")]
            Error
        }

        public enum CurrencyCode
        {
            [Description("ZAR")]
            Code
        }
    }
}
