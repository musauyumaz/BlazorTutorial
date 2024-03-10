using Application.Commons.Abstractions.Repositories;
using Application.Commons.Results;
using Application.Features.OrderItems.DTOs;
using Mapster;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.OrderItems.Queries.GetAll;

public record GetAllOrderItemQueryRequest() : IRequest<IDataResult<List<OrderItemDTO>>>;
public class GetAllOrderItemQueryHandler(IOrderItemRepository _orderItemRepository) : IRequestHandler<GetAllOrderItemQueryRequest, IDataResult<List<OrderItemDTO>>>
{
    public async ValueTask<IDataResult<List<OrderItemDTO>>> Handle(GetAllOrderItemQueryRequest request, CancellationToken cancellationToken)
    {
        List<OrderItemDTO>? orderItems = await _orderItemRepository.GetAllAsync().Result.ProjectToType<OrderItemDTO>().ToListAsync();
        return new DataResult<List<OrderItemDTO>>(true, orderItems);
    }
}



