using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class ProductDeleteEvent
    {
        [Required]
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
