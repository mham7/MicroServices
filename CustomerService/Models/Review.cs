using System;
using System.Collections.Generic;

namespace CustomerService.Models;

public partial class Review
{
    public int ReviewId { get; set; }

    public int ProductId { get; set; }

    public int CustomerId { get; set; }

    public double Rating { get; set; }

    public virtual Customer Customer { get; set; } = null!;
}
