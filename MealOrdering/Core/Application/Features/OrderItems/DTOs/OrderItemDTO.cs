namespace Application.Features.OrderItems.DTOs
{
    public record OrderItemDTO(string Id, DateTime CreatedDate, string CreatedUserFullName, string OrderName, string Description);
}



