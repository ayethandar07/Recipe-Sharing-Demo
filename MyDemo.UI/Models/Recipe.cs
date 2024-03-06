namespace MyDemo.UI.Models
{
    public class Recipe
    {
        public string Title { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<string> Method { get; set; }
        public string ImageURL { get; set; }
    }
}
