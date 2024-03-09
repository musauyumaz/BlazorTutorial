using Application.Commons.Abstractions.Repositories;
using Application.Features.Commands.Orders;
using Application.Features.Results;
using Domain.Entities;
using Mapster;
using Mediator;

namespace Application.Features.Queries.Orders.GetById;

public record GetByIdOrderQueryRequest(string Id) : IRequest<IDataResult<OrderDTO>>;
public class GetByIdOrderHandler(IOrderRepository _orderRepository) : IRequestHandler<GetByIdOrderQueryRequest, IDataResult<OrderDTO>>
{
    public async ValueTask<IDataResult<OrderDTO>> Handle(GetByIdOrderQueryRequest request, CancellationToken cancellationToken)
    {
        Order? order = await _orderRepository.GetAsync(Guid.Parse(request.Id));
        return new DataResult<OrderDTO>(true, order.Adapt<OrderDTO>());
    }
}



