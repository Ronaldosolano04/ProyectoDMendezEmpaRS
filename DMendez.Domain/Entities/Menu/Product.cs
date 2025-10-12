using DMendez.Domain.Common;
using DMendez.Domain.Entities.Orders;

namespace DMendez.Domain.Entities.Menu
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public bool IsAvailable { get; set; } = true;
        public int CategoryId { get; set; }

        // Navigation Properties
        public virtual Category Category { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public virtual ICollection<ComboProduct> ComboProducts { get; set; } = new List<ComboProduct>();
    }
}