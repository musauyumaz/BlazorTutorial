using Application.Commons.Abstractions.Repositories;
using Application.Features.Results;
using Domain.Entities;
using Mapster;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Queries.Suppliers.GetAll;

public record GetAllSupplierQueryRequest : IRequest<IDataResult<List<GetAllSupplierQueryResponse>>>;
public record GetAllSupplierQueryResponse(string Id, string Name, string WebURL, bool IsActive);
public class GetAllSupplierQueryHandler(ISupplierRepository _supplierRepository) : IRequestHandler<GetAllSupplierQueryRequest, IDataResult<List<GetAllSupplierQueryResponse>>>
{
    public async ValueTask<IDataResult<List<GetAllSupplierQueryResponse>>> Handle(GetAllSupplierQueryRequest request, CancellationToken cancellationToken)
    {
        List<Supplier>? suppliers = await _supplierRepository.GetAllAsync().Result.ToListAsync();
        var data = suppliers.Adapt<List<GetAllSupplierQueryResponse>>();
        return new DataResult<List<GetAllSupplierQueryResponse>>(true, data);
    }
}



