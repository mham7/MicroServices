using System;
using System.Collections.Generic;

namespace ProductService.Model;

public partial class Category
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<Productt> Productts { get; set; } = new List<Productt>();
}
