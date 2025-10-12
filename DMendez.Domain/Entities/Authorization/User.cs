using DMendez.Domain.Common;
using DMendez.Domain.Entities.Authorization;
using DMendez.Domain.Entities.Orders;

namespace DMendez.Domain.Entities.Auth
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool IsActive { get; set; } = true;

        // Navigation Properties
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
        public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}