using System.ComponentModel.DataAnnotations;

namespace InventoryService.Model
{
    public class Inventory
    {
        [Key]
        public int InventoryHistoryId { get; set; }
        public int ProductId { get; set; }
        public DateTime ChangeDate { get; set; }
        public int QuantityChange { get; set; }

    }
}
