using Application.Features.Commands.Responses.Suppliers;
using Application.Features.Results;
using MediatR;

namespace Application.Features.Commands.Requests.Suppliers
{
    public class CreateSupplierCommandRequest : IRequest<IDataResult<CreateSupplierCommandResponse>>
    {
        public string Name { get; set; }
        public string WebURL { get; set; }
    }
}



