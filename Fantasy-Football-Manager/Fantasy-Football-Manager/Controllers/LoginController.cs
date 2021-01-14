using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fantasy_Football_Manager.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Redirect()
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;

            if (currentUser.IsInRole("User"))
            {
                return RedirectToAction("GetLeaguesNoUser", "Ligi");
            }
            else
            {
                return RedirectToAction("Index", "Jucatori2");
            }
        }
    }
}
