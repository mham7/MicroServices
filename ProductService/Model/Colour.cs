using System;
using System.Collections.Generic;

namespace ProductService.Model;

public partial class Colour
{
    public int ColorId { get; set; }

    public string ColorName { get; set; } = null!;

    public virtual ICollection<Productt> Productts { get; set; } = new List<Productt>();
}
