using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ProductEvents
{
    public class ProductUpdatedEvent
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public required int QuantityChange { get; set; }

        
        
    }
}
