using Application.Commons.Abstractions.Repositories;
using Application.Commons.Results;
using Application.Features.Orders.DTOs;
using Domain.Entities;
using Mapster;
using Mediator;

namespace Application.Features.Orders.Commands.Delete;

public record DeleteOrderCommandRequest(string Id) : IRequest<IDataResult<OrderDTO>>;
public class DeleteOrderCommandHandler(IBaseRepository<Order> _orderRepository) : IRequestHandler<DeleteOrderCommandRequest, IDataResult<OrderDTO>>
{
    public async ValueTask<IDataResult<OrderDTO>> Handle(DeleteOrderCommandRequest request, CancellationToken cancellationToken)
    {
        Order? deletedOrder = await _orderRepository.DeleteAsync(Guid.Parse(request.Id));
        await _orderRepository.SaveAsync();
        return new DataResult<OrderDTO>(true, deletedOrder.Adapt<OrderDTO>());
    }
}



