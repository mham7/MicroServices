using System;
using System.Collections.Generic;

namespace OrderService.Model;

public partial class Order
{
    public int OrderId { get; set; }

    public int CustomerId { get; set; }

    public int? StoreId { get; set; }

    public DateOnly OrderDate { get; set; }

    public int TotalAmount { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
