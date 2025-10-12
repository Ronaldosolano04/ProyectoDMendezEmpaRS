using DMendez.Domain.Common;

namespace DMendez.Domain.Entities.Menu
{
    public class ComboProduct : BaseEntity
    {
        public int ComboId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        // Navigation Properties
        public virtual Combo Combo { get; set; }
        public virtual Product Product { get; set; }
    }
}