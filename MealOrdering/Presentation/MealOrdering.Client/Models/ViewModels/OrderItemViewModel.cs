namespace MealOrdering.Client.Models.ViewModels;

public record OrderItemViewModel(
    string Id, 
    string CreatedUserId, 
    string OrderId, 
    string Description, 
    DateTime CreatedDate,
    string OrderName,
    string CreatedUserFullName);

