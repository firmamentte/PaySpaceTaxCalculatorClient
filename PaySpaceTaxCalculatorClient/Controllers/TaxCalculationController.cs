using Microsoft.AspNetCore.Mvc;
using PaySpaceTaxCalculatorClient.BLL.BLL;
using PaySpaceTaxCalculatorClient.BLL.DataContract;
using PaySpaceTaxCalculatorClient.Controllers.ControllerHelpers;
using PaySpaceTaxCalculatorClient.Filters;
using PaySpaceTaxCalculatorClient.Models.TaxCalculation;

namespace PaySpaceTaxCalculatorClient.Controllers
{
    [ResponseCache(NoStore = true, Duration = 0, Location = ResponseCacheLocation.None, VaryByHeader = "*")]
    [SessionTimeOut]
    public class TaxCalculationController : Controller
    {
        private readonly ApplicationUserBLL ApplicationUserBLL;
        private readonly PostalCodeBLL PostalCodeBLL;
        private readonly TaxCalculationBLL TaxCalculationBLL;
        private readonly PostalCodeHelper PostalCodeHelper;
        private readonly TaxCalculationHelper TaxCalculationHelper;

        public TaxCalculationController(IHttpClientFactory httpClientFactory)
        {
            ApplicationUserBLL = new(httpClientFactory);
            PostalCodeBLL = new(httpClientFactory);
            TaxCalculationBLL = new(httpClientFactory);
            PostalCodeHelper = new();
            TaxCalculationHelper = new();
        }

        private async Task<string?> GetAccessTokenFromSession()
        {
            DateTime _accessTokenExpiryDate = Convert.ToDateTime(HttpContext.Session.GetString("AccessTokenExpiryDate")).Date;

            if (_accessTokenExpiryDate < DateTime.Now.Date)
            {
                AuthenticateResp _authenticateResp = await ApplicationUserBLL.Authenticate(GetEmailAddressFromSession!, GetUserPasswordFromSession!);
                HttpContext.Session.SetString("AccessToken", _authenticateResp.AccessToken);
                HttpContext.Session.SetString("AccessTokenExpiryDate", _authenticateResp.AccessTokenExpiryDate.ToString("yyyyy/MMMM/dd"));

                return _authenticateResp.AccessToken;
            }
            else
            {
                return HttpContext.Session.GetString("AccessToken");
            }
        }

        private string? GetEmailAddressFromSession
        {
            get
            {
                return HttpContext.Session.GetString("EmailAddress") ?? null;
            }
        }

        private string? GetUserPasswordFromSession
        {
            get
            {
                return HttpContext.Session.GetString("UserPassword") ?? null;
            }
        }

        [HttpGet]
        public async Task<IActionResult> ManageTaxCalculation()
        {
            PartialView("AnnualIncomeTaxGrid",
            TaxCalculationHelper.FillAnnualIncomeTaxGridModel(
            await TaxCalculationBLL.GetAnnualIncomeTaxes(await GetAccessTokenFromSession(), GetEmailAddressFromSession!)));

            return View();
        }

        [HttpGet]
        public async Task<ActionResult> CreateAnnualIncomeTax()
        {
            ViewBag.PostalCodes = PostalCodeHelper.FillPostalCodes(
            await PostalCodeBLL.GetPostalCodes(await GetAccessTokenFromSession(), GetEmailAddressFromSession!), "Select Postal Code");

            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAnnualIncomeTax(CreateAnnualIncomeTaxModel model)
        {
            return PartialView("AnnualIncomeTaxGridRow", TaxCalculationHelper.FillAnnualIncomeTaxGridModel(
            await TaxCalculationBLL.CreateAnnualIncomeTax(
            await GetAccessTokenFromSession(), GetEmailAddressFromSession!,
            new AnnualIncomeTaxReq()
            {
                PostalCode = model.PostalCode!,
                AnnualIncome = model.AnnualIncome
            })));
        }
    }
}
