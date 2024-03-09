﻿using Application.Commons.Abstractions.Repositories;
using Application.Features.Commands.OrderItems;
using Application.Features.Results;
using Domain.Entities;
using Mapster;
using Mediator;

namespace Application.Features.Queries.OrderItems.GetById;

public record GetByIdOrderItemQueryRequest(string Id) : IRequest<IDataResult<OrderItemDTO>>;
public class GetByIdOrderItemQueryHandler(IOrderItemRepository _orderItemRepository) : IRequestHandler<GetByIdOrderItemQueryRequest, IDataResult<OrderItemDTO>>
{
    public async ValueTask<IDataResult<OrderItemDTO>> Handle(GetByIdOrderItemQueryRequest request, CancellationToken cancellationToken)
    {
        OrderItem? orderItem = await _orderItemRepository.GetAsync(Guid.Parse(request.Id));
        return new DataResult<OrderItemDTO>(true, orderItem.Adapt<OrderItemDTO>());
    }
}



