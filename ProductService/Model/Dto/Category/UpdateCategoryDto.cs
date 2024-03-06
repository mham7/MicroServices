namespace ProductService.Model.Dto.Category
{
    public class UpdateCategoryDto
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = null!;
    }
}
