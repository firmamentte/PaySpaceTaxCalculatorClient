using Microsoft.AspNetCore.Mvc.Rendering;
using PaySpaceTaxCalculatorClient.BLL.DataContract;

namespace PaySpaceTaxCalculatorClient.Controllers.ControllerHelpers
{
    public class PostalCodeHelper
    {
        public List<SelectListItem> FillPostalCodes(List<PostalCodeResp> postalCodeResp, string selectedText)
        {
            List<SelectListItem> _selectListItems = new() {
                new SelectListItem()
                {
                    Value = "",
                    Text = selectedText,
                    Selected = true
                }
            };

            foreach (var item in postalCodeResp.OrderBy(title => title.PostalCode))
            {
                _selectListItems.Add(new SelectListItem
                {
                    Value = item.PostalCode,
                    Text = item.PostalCode
                });
            }

            return _selectListItems;
        }
    }
}
