namespace Application.Features.Orders.DTOs;

public record OrderDTO(string Id, string CreateUserFullName, string SupplierName, string Name, string Description, DateTime ExpireDate, DateTime CreatedDate);



