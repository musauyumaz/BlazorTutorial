using Application.Commons.Abstractions.Repositories;
using Application.Commons.Results;
using Application.Features.Orders.DTOs;
using Domain.Entities;
using Mapster;
using Mediator;

namespace Application.Features.Orders.Queries.GetById;

public record GetByIdOrderQueryRequest(string Id) : IRequest<IDataResult<OrderDTO>>;
public class GetByIdOrderHandler(IOrderRepository _orderRepository) : IRequestHandler<GetByIdOrderQueryRequest, IDataResult<OrderDTO>>
{
    public async ValueTask<IDataResult<OrderDTO>> Handle(GetByIdOrderQueryRequest request, CancellationToken cancellationToken)
    {
        Order? order = await _orderRepository.GetAsync(Guid.Parse(request.Id));
        return new DataResult<OrderDTO>(true, order.Adapt<OrderDTO>());
    }
}



