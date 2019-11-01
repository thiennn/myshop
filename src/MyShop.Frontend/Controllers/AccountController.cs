using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyShop.Frontend.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult SignIn(string returnUrl)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Challenge("oidc");
            }
            else
            {
                if (string.IsNullOrWhiteSpace(returnUrl))
                {
                    return Redirect("~/");
                }

                return Redirect(returnUrl);
            }
        }

        public IActionResult SignOut()
        {
            return SignOut("Cookies", "oidc");
        }

        [Authorize]
        public ActionResult MyProfile()
        {
            return View();
        }
    }
}
