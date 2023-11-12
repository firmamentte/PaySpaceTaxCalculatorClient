using Microsoft.AspNetCore.Mvc;
using PaySpaceTaxCalculatorClient.BLL.BLL;
using PaySpaceTaxCalculatorClient.BLL.DataContract;
using PaySpaceTaxCalculatorClient.Controllers.ControllerHelpers;
using PaySpaceTaxCalculatorClient.Models.ApplicationUser;

namespace NetcareDoctorsClient.Controllers
{
    [ResponseCache(NoStore = true, Duration = 0, Location = ResponseCacheLocation.None, VaryByHeader = "*")]
    public class ApplicationUserController : Controller
    {
        private readonly ApplicationUserBLL ApplicationUserBLL;
        private readonly SharedHelper SharedHelper;

        public ApplicationUserController(IHttpClientFactory httpClientFactory)
        {
            ApplicationUserBLL = new(httpClientFactory);
            SharedHelper = new();
        }

        [HttpGet]
        public IActionResult Home()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SignUp(SignUpModel model)
        {
            await ApplicationUserBLL.SignUp(model.EmailAddress, model.UserPassword);

            return PartialView("_Ok", SharedHelper.
            FillOkModel("Congrats...! You have Signed Up successful, please use your Email Address and Password to Sign in",
            SharedHelper.GetEnumDescription(EnumHelper.MessageSymbol.Information)));
        }

        [HttpGet]
        public ActionResult SignIn()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SignIn(SignInModel model)
        {
            AuthenticateResp _authenticateResp = await ApplicationUserBLL.Authenticate(model.EmailAddress, model.UserPassword);

            HttpContext.Session.SetString("EmailAddress", model.EmailAddress);
            HttpContext.Session.SetString("UserPassword", model.UserPassword);
            HttpContext.Session.SetString("AccessToken", _authenticateResp.AccessToken);
            HttpContext.Session.SetString("AccessTokenExpiryDate", _authenticateResp.AccessTokenExpiryDate.ToString("yyyyy/MMMM-dd"));

            return Json(new { RedirectToUrl = Url.Action("ManageTaxCalculation", "TaxCalculation") });
        }

        [HttpGet]
        public ActionResult UserSignOut()
        {
            HttpContext.Session.Clear();

            return RedirectToActionPermanent("Home", "ApplicationUser");
        }
    }
}