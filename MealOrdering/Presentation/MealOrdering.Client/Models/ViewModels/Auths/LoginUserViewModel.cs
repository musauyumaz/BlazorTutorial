namespace MealOrdering.Client.Models.ViewModels.Auths;

public record LoginUserViewModel
{
    public string EmailOrUsername { get; set; }
    public string Password { get; set; }
}

