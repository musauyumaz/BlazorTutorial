using Application.Commons.Abstractions.Repositories;
using Application.Features.Results;
using Domain.Entities;
using Mapster;
using Mediator;

namespace Application.Features.Commands.Suppliers.Delete;

public record DeleteSupplierCommandRequest(Guid Id) : IRequest<IDataResult<SupplierDTO>>;
public class DeleteSupplierCommandHandler(ISupplierRepository _supplierRepository) : IRequestHandler<DeleteSupplierCommandRequest, IDataResult<SupplierDTO>>
{
    public async ValueTask<IDataResult<SupplierDTO>> Handle(DeleteSupplierCommandRequest request, CancellationToken cancellationToken)
    {
        Supplier? deletedSupplier = await _supplierRepository.DeleteAsync(request.Id);
        await _supplierRepository.SaveAsync();
        return new DataResult<SupplierDTO>(true,deletedSupplier.Adapt<SupplierDTO>());
    }
}



