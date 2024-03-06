namespace MealOrdering.Client.Models.ViewModels.Users
{
    public class UpdateUserViewModel
    {
        public string Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string EmailAddress { get; set; }
        public bool IsActive { get; set; }
    }
}
