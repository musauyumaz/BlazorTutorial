using Application.Commons.Abstractions.Repositories;
using Application.Features.Results;
using Domain.Entities;
using Mapster;
using Mediator;

namespace Application.Features.Commands.Orders.Create;

public record CreateOrderCommandRequest(string CreateUserId, string SupplierId, string Name, string Description, DateTime ExpireDate) : IRequest<IDataResult<OrderDTO>>;
public class CreateOrderCommandHandler(IOrderRepository _orderRepository) : IRequestHandler<CreateOrderCommandRequest, IDataResult<OrderDTO>>
{
    public async ValueTask<IDataResult<OrderDTO>> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
    {
        Order? addedOrder = await _orderRepository.AddAsync(request.Adapt<Order>());
        await _orderRepository.SaveAsync();
        return new DataResult<OrderDTO>(true, addedOrder.Adapt<OrderDTO>());
    }
}



