namespace MealOrdering.Client.Models.ViewModels.Users;

public record UpdateUserViewModel(string Id, string Firstname, string Lastname, string EmailAddress, bool IsActive);