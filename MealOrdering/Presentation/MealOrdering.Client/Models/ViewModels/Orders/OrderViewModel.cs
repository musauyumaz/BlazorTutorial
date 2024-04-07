namespace MealOrdering.Client.Models.ViewModels.Orders;

public record OrderViewModel(
    string Id,
    string CreateUserId,
    string SupplierId,
    string Name,
    string Description,
    DateTime ExpireDate,
    DateTime CreatedDate,
    string CreatedUserFullName,
    string SupplierName
    );

