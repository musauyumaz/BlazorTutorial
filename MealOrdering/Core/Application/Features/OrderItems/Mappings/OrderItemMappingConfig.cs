using Application.Features.OrderItems.DTOs;
using Domain.Entities;
using Mapster;

namespace Application.Features.OrderItems.Mappings
{
    public class OrderItemMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<OrderItem, OrderItemDTO>()
                .Map(dest => dest.OrderName, src => src.Order.Name)
                .Map(dest => dest.CreatedUserFullName, src => $"{src.CreatedUser.FirstName} {src.CreatedUser.LastName}");
        }
    }
}



