using DMendez.Domain.Common;

namespace DMendez.Domain.Entities.Orders
{
    public class OrderStatus : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        // Navigation Properties
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}