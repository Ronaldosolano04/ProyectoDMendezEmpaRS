using DMendez.Domain.Common;

namespace DMendez.Domain.Entities.Orders
{
    public class DeliveryAddress : BaseEntity
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string AdditionalInfo { get; set; }

        // Navigation Properties
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}