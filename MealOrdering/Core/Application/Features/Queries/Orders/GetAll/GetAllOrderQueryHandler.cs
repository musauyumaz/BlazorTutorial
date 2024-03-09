using Application.Commons.Abstractions.Repositories;
using Application.Features.Commands.Orders;
using Application.Features.Results;
using Mapster;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Queries.Orders.GetAll;

public record GetAllOrderQueryRequest() : IRequest<IDataResult<List<OrderDTO>>>;

public class GetAllOrderQueryHandler(IOrderRepository _orderRepository) : IRequestHandler<GetAllOrderQueryRequest, IDataResult<List<OrderDTO>>>
{
    public async ValueTask<IDataResult<List<OrderDTO>>> Handle(GetAllOrderQueryRequest request, CancellationToken cancellationToken)
    {
        List<OrderDTO>? orders = await _orderRepository.GetAllAsync().Result.ProjectToType<OrderDTO>().ToListAsync();
        return new DataResult<List<OrderDTO>>(true, orders);
    }
}



