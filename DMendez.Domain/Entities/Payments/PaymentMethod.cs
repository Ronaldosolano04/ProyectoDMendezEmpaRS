using DMendez.Domain.Common;

namespace DMendez.Domain.Entities.Payments
{
    public class PaymentMethod : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; } = true;

        // Navigation Properties
        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}