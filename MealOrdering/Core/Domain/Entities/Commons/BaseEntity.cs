namespace Domain.Entities.Commons
{
    public abstract class BaseEntity : IUpdatedDate, IIsActive
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
