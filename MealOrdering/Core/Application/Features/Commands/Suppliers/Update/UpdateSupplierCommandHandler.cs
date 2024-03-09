using Application.Commons.Abstractions.Repositories;
using Application.Features.Results;
using Domain.Entities;
using Mapster;
using Mediator;

namespace Application.Features.Commands.Suppliers.Update;

public record UpdateSupplierCommandRequest(Guid Id, string Name, string WebUrl, bool IsActive) : IRequest<IDataResult<SupplierDTO>>;
public class UpdateSupplierCommandHandler(ISupplierRepository _supplierRepository) : IRequestHandler<UpdateSupplierCommandRequest, IDataResult<SupplierDTO>>
{
    public async ValueTask<IDataResult<SupplierDTO>> Handle(UpdateSupplierCommandRequest request, CancellationToken cancellationToken)
    {
        Supplier? updatedSupplier = await _supplierRepository.UpdateAsync(request.Adapt<Supplier>());
        await _supplierRepository.SaveAsync();
        return new DataResult<SupplierDTO>("Güncellendi",true, updatedSupplier.Adapt<SupplierDTO>());
    }
}



