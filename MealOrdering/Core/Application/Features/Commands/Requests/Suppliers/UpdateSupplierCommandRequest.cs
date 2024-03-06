using Application.Features.Results;
using MediatR;

namespace Application.Features.Commands.Requests.Suppliers
{
    public class UpdateSupplierCommandRequest : IRequest<IDataResult<UpdateSupplierCommandRequest>>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string WebURL { get; set; }
        public bool IsActive { get; set; }
    }
}



