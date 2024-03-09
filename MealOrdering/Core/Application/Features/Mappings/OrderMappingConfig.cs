using Application.Features.Commands.Orders;
using Domain.Entities;
using Mapster;

namespace Application.Features.Mappings
{
    public class OrderMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Order, OrderDTO>()
                .Map(dest => dest.SupplierName, src => src.Supplier.Name)
                .Map(dest => dest.CreateUserFullName, src => $"{src.CreateUser.FirstName} {src.CreateUser.LastName}");
        }
    }
}



