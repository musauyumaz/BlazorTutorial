using Application.Features.Commands.Responses.Suppliers;
using Application.Features.Results;
using MediatR;

namespace Application.Features.Commands.Requests.Suppliers
{
    public class DeleteSupplierCommandRequest : IRequest<IDataResult<DeleteSupplierCommandResponse>>
    {
        public string Id { get; set; }
    }
}



