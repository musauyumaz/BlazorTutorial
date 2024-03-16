using Domain.Entities.Commons;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Identity
{
    public class AppUser : IdentityUser, IIsActive, IUpdatedDate
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime UpdatedDate { get; set; }


        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }

    }
}
