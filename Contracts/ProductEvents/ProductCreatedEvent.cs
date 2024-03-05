using System.ComponentModel.DataAnnotations;

namespace Contracts.ProductEvents
{
    public class ProductCreatedEvent
    {
        public int ProductId { get; set; }
        [Required]
        public required string Name { get; set; }

        [Required]
        public required string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        

    }
}
