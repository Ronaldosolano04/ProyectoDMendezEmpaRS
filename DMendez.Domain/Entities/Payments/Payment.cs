using DMendez.Domain.Common;
using DMendez.Domain.Entities.Orders;

namespace DMendez.Domain.Entities.Payments
{
    public class Payment : BaseEntity
    {
        public int OrderId { get; set; }
        public string TransactionId { get; set; }
        public decimal Amount { get; set; }
        public int PaymentMethodId { get; set; }
        public int PaymentStatusId { get; set; }
        public DateTime? PaidAt { get; set; }
        public string PaymentGatewayResponse { get; set; }

        // Navigation Properties
        public virtual Order Order { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
        public virtual PaymentStatus PaymentStatus { get; set; }
    }
}