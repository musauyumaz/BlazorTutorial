using MealOrdering.Client.Models.ViewModels.Users;

namespace MealOrdering.Client.Models.ViewModels.Auths;

public record LoginResponseViewModel(TokenViewModel Token, UserViewModel User);
public record TokenViewModel(string AccessToken, string RefreshToken, DateTime Expiration);
