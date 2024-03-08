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

        public IActionResult Index(string searchTerm = null, int page = 1, int pageSize = 5)
        {
            var data = _recipeData.Recipes;

            if (!string.IsNullOrEmpty(searchTerm))
            {
                data = data.Where( r => r.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList(); 
            }

            int totalItems = data.Count;
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            var recipes = data.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var model = new PaginationViewModel
            {
                Recipes = recipes,
                PageNumber = page,
                PageSize = pageSize,
                TotalItems = totalItems,
                TotalPages = totalPages
            };

            ViewBag.SearchTerm = searchTerm;

            return View(model);            
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
        public IActionResult Search(string searchTerm, int page = 1, int pageSize = 5)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index", new { searchTerm, page, pageSize });
        }
    }
}
