using DMendez.Domain.Common;

namespace DMendez.Domain.Entities.Payments
{
    public class PaymentStatus : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        // Navigation Properties
        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}