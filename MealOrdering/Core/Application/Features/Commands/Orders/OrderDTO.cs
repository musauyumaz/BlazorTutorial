namespace Application.Features.Commands.Orders;

public record OrderDTO(string Id, string CreateUserFullName, string SupplierName, string Name, string Description, DateTime ExpireDate, DateTime CreatedDate);



