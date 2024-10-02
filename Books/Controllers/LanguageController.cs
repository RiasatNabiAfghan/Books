using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
namespace MIS.Controllers
{
    public class LanguageController : Controller
    {
        [HttpGet]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            if (string.IsNullOrEmpty(culture))
            {
                return LocalRedirect(returnUrl);
            }
            CultureInfo cInfo = new CultureInfo(culture);
            CultureInfo cInfoInvarian = new CultureInfo("en-GB");
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture))
            );
            return LocalRedirect(returnUrl);
        }
    }
}
