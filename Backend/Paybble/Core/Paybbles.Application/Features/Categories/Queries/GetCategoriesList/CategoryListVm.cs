namespace Paybble.Application.Features.Categories.Queries.GetCategoriesList
{
    public class CategoryListVm
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Icon { get; set; }
        public string? Color { get; set; }
    }
}
