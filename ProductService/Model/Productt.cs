using System;
using System.Collections.Generic;

namespace ProductService.Model;

public partial class Productt
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int Price { get; set; }

    public int CategoryId { get; set; }

    public int? SizeId { get; set; }

    public int? ColorId { get; set; }

    public string? ImageUrl { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual Colour? Color { get; set; }

    public virtual Size? Size { get; set; }
}
