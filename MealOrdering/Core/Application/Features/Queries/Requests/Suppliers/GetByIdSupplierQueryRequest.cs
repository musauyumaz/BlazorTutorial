using Application.Features.Queries.Responses.Suppliers;
using Application.Features.Results;
using MediatR;

namespace Application.Features.Queries.Requests.Suppliers
{
    public class GetByIdSupplierQueryRequest : IRequest<IDataResult<GetByIdSupplierQueryResponse>>
    {
        public string Id { get; set; }
    }
}



