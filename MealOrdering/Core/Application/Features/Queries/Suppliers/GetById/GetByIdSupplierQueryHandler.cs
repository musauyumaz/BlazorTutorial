using Application.Commons.Abstractions.Repositories;
using Application.Features.Results;
using Domain.Entities;
using Mapster;
using Mediator;

namespace Application.Features.Queries.Suppliers.GetById;

public record GetByIdSupplierRequest(Guid Id) : IRequest<IDataResult<GetByIdSupplierResponse>>;
public record GetByIdSupplierResponse(string Id, string Name, string WebURL, bool IsActive, DateTime UpdatedDate);
public class GetByIdSupplierQueryHandler(ISupplierRepository _supplierRepository) : IRequestHandler<GetByIdSupplierRequest, IDataResult<GetByIdSupplierResponse>>
{
    public async ValueTask<IDataResult<GetByIdSupplierResponse>> Handle(GetByIdSupplierRequest request, CancellationToken cancellationToken)
    {
        Supplier? supplier = await _supplierRepository.GetAsync(request.Id);
        return new DataResult<GetByIdSupplierResponse>(true, supplier.Adapt<GetByIdSupplierResponse>());
    }
}



