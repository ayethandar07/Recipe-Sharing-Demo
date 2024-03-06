using Microsoft.AspNetCore.Mvc;
using MyDemo.UI.Data;
using MyDemo.UI.Models;
using System.Diagnostics;

namespace MyDemo.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RecipeData _recipeData;

        public HomeController(ILogger<HomeController> logger, RecipeData recipeData)
        {
            _logger = logger;
            _recipeData = recipeData;
        }

        public IActionResult Index()
        {
            return View(_recipeData);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
