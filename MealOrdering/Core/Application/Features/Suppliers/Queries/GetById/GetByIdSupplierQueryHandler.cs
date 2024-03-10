using Application.Commons.Abstractions.Repositories;
using Application.Commons.Results;
using Domain.Entities;
using Mapster;
using Mediator;

namespace Application.Features.Suppliers.Queries.GetById;

public record GetByIdSupplierRequest(string Id) : IRequest<IDataResult<GetByIdSupplierResponse>>;
public record GetByIdSupplierResponse(string Id, string Name, string WebUrl, bool IsActive, DateTime UpdatedDate);
public class GetByIdSupplierQueryHandler(ISupplierRepository _supplierRepository) : IRequestHandler<GetByIdSupplierRequest, IDataResult<GetByIdSupplierResponse>>
{
    public async ValueTask<IDataResult<GetByIdSupplierResponse>> Handle(GetByIdSupplierRequest request, CancellationToken cancellationToken)
    {
        Supplier? supplier = await _supplierRepository.GetAsync(Guid.Parse(request.Id));
        return new DataResult<GetByIdSupplierResponse>(true, supplier.Adapt<GetByIdSupplierResponse>());
    }
}



