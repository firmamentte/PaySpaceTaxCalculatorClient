using Microsoft.AspNetCore.Mvc;
using PaySpaceTaxCalculatorClient.Controllers.ControllerHelpers;

namespace NetcareDoctorsClient.Controllers
{
    public class SharedController : Controller
    {
        private readonly SharedHelper SharedHelper;

        public SharedController()
        {
            SharedHelper = new();
        }

        [HttpGet]
        public ActionResult Ok(string okMessage, string messageSymbol)
        {
            return PartialView("_Ok", SharedHelper.FillOkModel(okMessage, messageSymbol));
        }

        [HttpGet]
        public ActionResult UserAccount()
        {
            return PartialView("_UserAccount");
        }
    }
}
