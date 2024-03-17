using Domain.Entities.Commons;
using Domain.Entities.Identity;

namespace Domain.Entities
{
    public class Order : BaseEntity
    {
        public Guid CreatedUserId { get; set; }
        public Guid SupplierId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ExpireDate { get; set; }

        public virtual User CreatedUser { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
