using System.ComponentModel.DataAnnotations;

namespace ProductService.Model
{
        public class Product
        {
            public int ProductId { get; set; }
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
