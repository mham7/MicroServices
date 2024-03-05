using System;
using System.Collections.Generic;

namespace ProductService.Model;

public partial class Size
{
    public int SizeId { get; set; }

    public string SizeName { get; set; } = null!;

    public virtual ICollection<Productt> Productts { get; set; } = new List<Productt>();
}
