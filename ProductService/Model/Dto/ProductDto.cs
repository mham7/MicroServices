using System.ComponentModel.DataAnnotations;

namespace ProductService.Model.Dto
{
    public class ProductDto
    {
        [Required]
        public required string Name { get; set; }

        [Required]
        public required string Description { get; set; }
        [Required]
        public decimal Price { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int SizeId { get; set; }
        [Required]
        public int ColorId { get; set; }

        [Required]
        public required string ImageUrl {  get; set; }
    }
}
