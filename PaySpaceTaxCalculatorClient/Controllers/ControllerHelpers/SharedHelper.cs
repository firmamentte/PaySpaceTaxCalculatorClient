using PaySpaceTaxCalculatorClient.Models.Shared;
using System.ComponentModel;

namespace PaySpaceTaxCalculatorClient.Controllers.ControllerHelpers
{
    public class SharedHelper
    {
        public OkModel FillOkModel(string message, string messageSymbol)
        {
            return new OkModel() { OkMessage = message, MessageSymbol = messageSymbol };
        }

        public string GetEnumDescription(Enum enumValue)
        {
            return FirmamentUtilities.Utilities.GetEnumDescription(enumValue);
        }
    }
}
