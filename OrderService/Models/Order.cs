namespace OrderService.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public required string ShippingAddress { get; set; } 
        public required List<OrderItem> OrderItems { get; set; }

    }
}
