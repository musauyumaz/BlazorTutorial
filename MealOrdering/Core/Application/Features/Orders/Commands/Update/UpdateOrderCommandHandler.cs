using Application.Commons.Abstractions.Repositories;
using Application.Commons.Results;
using Application.Features.Orders.DTOs;
using Domain.Entities;
using Mapster;
using Mediator;

namespace Application.Features.Orders.Commands.Update;

public record UpdateOrderCommandRequest(string CreateUserId, string SupplierId, string Name, string Description, DateTime ExpireDate) : IRequest<IDataResult<OrderDTO>>;
public class UpdateOrderCommandHandler(IOrderRepository _orderRepository) : IRequestHandler<UpdateOrderCommandRequest, IDataResult<OrderDTO>>
{
    public async ValueTask<IDataResult<OrderDTO>> Handle(UpdateOrderCommandRequest request, CancellationToken cancellationToken)
    {
        Order? updatedOrder = await _orderRepository.UpdateAsync(request.Adapt<Order>());
        await _orderRepository.SaveAsync();
        return new DataResult<OrderDTO>(true, updatedOrder.Adapt<OrderDTO>());
    }
}



