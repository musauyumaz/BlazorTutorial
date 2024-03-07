using Application.Commons.Abstractions.Repositories;
using Application.Features.Results;
using Domain.Entities;
using Mapster;
using Mediator;

namespace Application.Features.Commands.Suppliers.Create;

public record CreateSupplierCommandRequest(string Name, string WebUrl) : IRequest<IDataResult<SupplierDTO>>;

public class CreateSupplierCommandHandler(ISupplierRepository _supplierRepository) : IRequestHandler<CreateSupplierCommandRequest, IDataResult<SupplierDTO>>
{
    public async ValueTask<IDataResult<SupplierDTO>> Handle(CreateSupplierCommandRequest request, CancellationToken cancellationToken)
    {
        Supplier? createdSupplier = await _supplierRepository.AddAsync(request.Adapt<Supplier>());
        await _supplierRepository.SaveAsync();
        return new DataResult<SupplierDTO>(true,createdSupplier.Adapt<SupplierDTO>());
    }
}



