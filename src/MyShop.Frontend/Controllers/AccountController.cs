using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyShop.Frontend.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult SignIn()
        {
            return Challenge(new AuthenticationProperties { RedirectUri = "/" }, "oidc");
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
