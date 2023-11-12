using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PaySpaceTaxCalculatorClient.Filters
{
    public class SessionTimeOut : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (string.IsNullOrWhiteSpace(context.HttpContext.Session.GetString("EmailAddress")))
            {
                context.Result = new RedirectResult("~/ApplicationUser/UserSignOut", true);
            }
            base.OnActionExecuting(context);
        }
    }
}
