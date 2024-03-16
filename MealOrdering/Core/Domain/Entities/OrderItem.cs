using Domain.Entities.Commons;
using Domain.Entities.Identity;

namespace Domain.Entities
{
    public class OrderItem : BaseEntity
    {
        public string CreatedUserId { get; set; }
        public Guid OrderId { get; set; }
        public string Description { get; set; }

        public virtual Order Order { get; set; }
        public virtual AppUser CreatedUser { get; set; }
    }
}
