using Microsoft.AspNetCore.Mvc;
using MyDemo.UI.Data;

namespace MyDemo.UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserData _userData;

        public LoginController(ILogger<HomeController> logger, UserData userData)
        {
            _logger = logger;
            _userData = userData;
        }
        public IActionResult Index()
        {
            var users = _userData.Users;
            return View();
        }
    }
}
