using Application.Commons.Abstractions.Repositories;
using Application.Commons.Results;
using Application.Features.OrderItems.DTOs;
using Domain.Entities;
using Mapster;
using Mediator;

namespace Application.Features.OrderItems.Queries.GetById;

public record GetByIdOrderItemQueryRequest(string Id) : IRequest<IDataResult<OrderItemDTO>>;
public class GetByIdOrderItemQueryHandler(IBaseRepository<OrderItem> _orderItemRepository) : IRequestHandler<GetByIdOrderItemQueryRequest, IDataResult<OrderItemDTO>>
{
    public async ValueTask<IDataResult<OrderItemDTO>> Handle(GetByIdOrderItemQueryRequest request, CancellationToken cancellationToken)
    {
        OrderItem? orderItem = await _orderItemRepository.GetAsync(Guid.Parse(request.Id));
        return new DataResult<OrderItemDTO>(true, orderItem.Adapt<OrderItemDTO>());
    }
}



