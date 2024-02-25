using Domain.Entities.Commons;

namespace Domain.Entities
{
    public class OrderItem : BaseEntity
    {
        public Guid CreatedUserId { get; set; }
        public Guid OrderId { get; set; }
        public string Description { get; set; }

        public virtual Order Order { get; set; }
        public virtual User CreatedUser { get; set; }
    }
}
