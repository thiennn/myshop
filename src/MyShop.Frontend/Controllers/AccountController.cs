using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Frontend.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult SignOut()
        {
            return SignOut("Cookies", "oidc");
        }
    }
}
