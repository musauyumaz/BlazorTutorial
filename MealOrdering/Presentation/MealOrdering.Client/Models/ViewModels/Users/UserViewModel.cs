namespace MealOrdering.Client.Models.ViewModels.Users;

public record UserViewModel(string Id, string FirstName, string LastName, string EmailAddress, bool IsActive, DateTime CreatedDate, string FullName);

