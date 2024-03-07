using Microsoft.AspNetCore.Mvc;

namespace MyDemo.UI.Controllers
{
    public class DetailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
