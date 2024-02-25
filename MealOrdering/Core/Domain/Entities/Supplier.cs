using Domain.Entities.Commons;

namespace Domain.Entities
{
    public class Supplier : BaseEntity
    {
        public string Name { get; set; }
        public string WebURL { get; set; }
    }
}
