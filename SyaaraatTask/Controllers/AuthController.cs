using Microsoft.AspNetCore.Mvc;

namespace SyaaraatTask.WEB.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
