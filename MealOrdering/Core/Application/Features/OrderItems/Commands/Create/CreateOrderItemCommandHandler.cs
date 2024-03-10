using Application.Commons.Abstractions.Repositories;
using Application.Commons.Results;
using Application.Features.OrderItems.DTOs;
using Domain.Entities;
using Mapster;
using Mediator;

namespace Application.Features.OrderItems.Commands.Create;

public record CreateOrderItemCommandRequest() : IRequest<IDataResult<OrderItemDTO>>;
public class CreateOrderItemCommandHandler(IOrderItemRepository _orderItemRepository) : IRequestHandler<CreateOrderItemCommandRequest, IDataResult<OrderItemDTO>>
{
    public async ValueTask<IDataResult<OrderItemDTO>> Handle(CreateOrderItemCommandRequest request, CancellationToken cancellationToken)
    {
        OrderItem? addedOrderItem = await _orderItemRepository.AddAsync(request.Adapt<OrderItem>());
        await _orderItemRepository.SaveAsync();
        return new DataResult<OrderItemDTO>(true, addedOrderItem.Adapt<OrderItemDTO>());
    }
}



