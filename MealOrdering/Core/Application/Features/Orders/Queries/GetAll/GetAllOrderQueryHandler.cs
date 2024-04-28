using Application.Commons.Abstractions.Repositories;
using Application.Commons.Results;
using Application.Features.Orders.DTOs;
using Domain.Entities;
using Mapster;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Orders.Queries.GetAll;

public record GetAllOrderQueryRequest() : IRequest<IDataResult<List<OrderDTO>>>;

public class GetAllOrderQueryHandler(IBaseRepository<Order> _orderRepository) : IRequestHandler<GetAllOrderQueryRequest, IDataResult<List<OrderDTO>>>
{
    public async ValueTask<IDataResult<List<OrderDTO>>> Handle(GetAllOrderQueryRequest request, CancellationToken cancellationToken)
    {
        List<OrderDTO>? orders = await _orderRepository.GetAllAsync().Result.ProjectToType<OrderDTO>().ToListAsync();
        return new DataResult<List<OrderDTO>>(true, orders);
    }
}



