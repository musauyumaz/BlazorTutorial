using Application.Features.Orders.DTOs;
using Domain.Entities;
using Mapster;

namespace Application.Features.Orders.Mappings
{
    public class OrderMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Order, OrderDTO>()
                .Map(dest => dest.SupplierName, src => src.Supplier.Name)
                .Map(dest => dest.CreateUserFullName, src => $"{src.CreatedUser.FirstName} {src.CreatedUser.LastName}");
        }
    }
}



