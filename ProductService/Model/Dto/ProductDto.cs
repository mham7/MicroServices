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
        public int Stock { get; set; }

        
    }
}
