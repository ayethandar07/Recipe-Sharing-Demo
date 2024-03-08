using Microsoft.AspNetCore.Mvc;
using MyDemo.UI.Data;
using MyDemo.UI.Models;

namespace MyDemo.UI.Controllers
{
    public class DetailController : Controller
    {
        private readonly RecipeData _recipeData;

        public DetailController(RecipeData recipeData)
        {
            _recipeData = recipeData;
        }

        public IActionResult Index(int id)
        {
            var recipe = _recipeData.Recipes.FirstOrDefault( r => r.Id == id );

            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }
    }
}
