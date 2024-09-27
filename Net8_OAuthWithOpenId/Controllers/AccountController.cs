using Microsoft.AspNetCore.Mvc;

namespace Net8_OAuthWithOpenId.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
