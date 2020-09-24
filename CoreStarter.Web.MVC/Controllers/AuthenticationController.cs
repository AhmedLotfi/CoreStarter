using Microsoft.AspNetCore.Mvc;

namespace CoreStarter.Web.MVC.Controllers
{
    public class AuthenticationController : Controller
    {
        public IActionResult Login() => View();

        public IActionResult Register() => View();
    }
}