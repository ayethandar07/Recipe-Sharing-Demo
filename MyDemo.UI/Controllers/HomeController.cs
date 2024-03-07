using Microsoft.AspNetCore.Mvc;
using MyDemo.UI.Data;
using MyDemo.UI.Models;
using System.Diagnostics;
using System.Linq;

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

        public IActionResult Index(RecipeData recipeData = null)
        {
            if (recipeData == null)
            {
                return View(_recipeData);
            }
            else
            {
                return View(recipeData);
            }
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

        [HttpGet]
        public IActionResult Search(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return RedirectToAction("Index");
            }

            var filteredRecipes = _recipeData.Recipes
                                .Where(r => r.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                                            r.Method.Any(m => m.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)))
                                .ToList();

            var filteredRecipeData = new RecipeData { Recipes = filteredRecipes };

            return View("Index", filteredRecipeData);
        }
    }
}
