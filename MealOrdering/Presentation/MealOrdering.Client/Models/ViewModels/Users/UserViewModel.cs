namespace MealOrdering.Client.Models.ViewModels.Users
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public string FullName => $"{FirstName} {LastName}";
    }
}
