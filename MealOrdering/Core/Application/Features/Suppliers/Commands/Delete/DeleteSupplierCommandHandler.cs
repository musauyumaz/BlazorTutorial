using Application.Commons.Abstractions.Repositories;
using Application.Commons.Results;
using Application.Features.Suppliers.DTOs;
using Domain.Entities;
using Mapster;
using Mediator;

namespace Application.Features.Suppliers.Commands.Delete;

public record DeleteSupplierCommandRequest(string Id) : IRequest<IDataResult<SupplierDTO>>;
public class DeleteSupplierCommandHandler(ISupplierRepository _supplierRepository) : IRequestHandler<DeleteSupplierCommandRequest, IDataResult<SupplierDTO>>
{
    public async ValueTask<IDataResult<SupplierDTO>> Handle(DeleteSupplierCommandRequest request, CancellationToken cancellationToken)
    {
        Supplier? deletedSupplier = await _supplierRepository.DeleteAsync(Guid.Parse(request.Id));
        await _supplierRepository.SaveAsync();
        return new DataResult<SupplierDTO>(true, deletedSupplier.Adapt<SupplierDTO>());
    }
}



