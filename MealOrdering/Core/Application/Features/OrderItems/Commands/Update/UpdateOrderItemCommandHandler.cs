using Application.Commons.Abstractions.Repositories;
using Application.Commons.Results;
using Application.Features.OrderItems.DTOs;
using Domain.Entities;
using Mapster;
using Mediator;

namespace Application.Features.OrderItems.Commands.Update;

public record UpdateOrderItemCommandRequest() : IRequest<IDataResult<OrderItemDTO>>;
public class UpdateOrderItemCommandHandler(IOrderItemRepository _orderItemRepository) : IRequestHandler<UpdateOrderItemCommandRequest, IDataResult<OrderItemDTO>>
{
    public async ValueTask<IDataResult<OrderItemDTO>> Handle(UpdateOrderItemCommandRequest request, CancellationToken cancellationToken)
    {
        var updatedOrderItem = await _orderItemRepository.UpdateAsync(request.Adapt<OrderItem>());
        await _orderItemRepository.SaveAsync();
        return new DataResult<OrderItemDTO>(true, updatedOrderItem.Adapt<OrderItemDTO>());
    }
}



