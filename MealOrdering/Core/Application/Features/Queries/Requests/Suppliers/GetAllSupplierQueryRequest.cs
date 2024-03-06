using Application.Features.Queries.Responses.Suppliers;
using Application.Features.Results;
using MediatR;

namespace Application.Features.Queries.Requests.Suppliers
{
    public class GetAllSupplierQueryRequest : IRequest<IDataResult<List<GetAllSupplierQueryResponse>>>
    {
    }
}



