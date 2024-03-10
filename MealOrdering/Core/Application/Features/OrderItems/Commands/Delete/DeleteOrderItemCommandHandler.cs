using Application.Commons.Abstractions.Repositories;
using Application.Commons.Results;
using Application.Features.OrderItems.DTOs;
using Domain.Entities;
using Mapster;
using Mediator;

namespace Application.Features.OrderItems.Commands.Delete;

public record DeleteOrderItemCommandRequest(string Id) : IRequest<IDataResult<OrderItemDTO>>;
public class DeleteOrderItemCommandHandler(IOrderItemRepository _orderItemRepository) : IRequestHandler<DeleteOrderItemCommandRequest, IDataResult<OrderItemDTO>>
{
    public async ValueTask<IDataResult<OrderItemDTO>> Handle(DeleteOrderItemCommandRequest request, CancellationToken cancellationToken)
    {
        OrderItem? deletedOrderItem = await _orderItemRepository.DeleteAsync(Guid.Parse(request.Id));
        await _orderItemRepository.SaveAsync();
        return new DataResult<OrderItemDTO>(true, deletedOrderItem.Adapt<OrderItemDTO>());
    }
}



