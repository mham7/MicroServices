using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductService.Model;

public partial class Colour
{
    [Required]
    public int ColorId { get; set; }

    [Required]
    public string ColorName { get; set; } = null!;

    
    public virtual ICollection<Productt> Productts { get; set; } = new List<Productt>();
}
