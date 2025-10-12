using DMendez.Domain.Common;

namespace DMendez.Domain.Entities.Menu
{
    public class Combo : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; } = true;

        // Navigation Properties
        public virtual ICollection<ComboProduct> ComboProducts { get; set; } = new List<ComboProduct>();
    }
}  