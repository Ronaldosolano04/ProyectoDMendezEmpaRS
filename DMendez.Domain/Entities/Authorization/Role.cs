using DMendez.Domain.Common;
using DMendez.Domain.Entities.Authorization;

namespace DMendez.Domain.Entities.Auth
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        // Navigation Properties
        public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
