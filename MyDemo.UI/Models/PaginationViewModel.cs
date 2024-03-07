namespace MyDemo.UI.Models
{
    public class PaginationViewModel
    {
        public List<Recipe> Recipes { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
    }
}
