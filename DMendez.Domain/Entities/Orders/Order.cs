using DMendez.Domain.Common;
using DMendez.Domain.Entities.Auth;
using DMendez.Domain.Entities.Payments;

namespace DMendez.Domain.Entities.Orders
{
    public class Order : BaseEntity
    {
        public string OrderNumber { get; set; }
        public int UserId { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Tax { get; set; }
        public decimal TotalAmount { get; set; }
        public int OrderStatusId { get; set; }
        public int? DeliveryAddressId { get; set; }
        public string Notes { get; set; }
        public DateTime? DeliveredAt { get; set; }

        // Navigation Properties
        public virtual User User { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
        public virtual DeliveryAddress DeliveryAddress { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}