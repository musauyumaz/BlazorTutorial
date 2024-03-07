using Application.Features.Commands.Suppliers;
using Application.Features.Commands.Suppliers.Create;
using Application.Features.Commands.Suppliers.Delete;
using Application.Features.Commands.Suppliers.Update;
using Application.Features.Queries.Suppliers.GetAll;
using Application.Features.Queries.Suppliers.GetById;
using Application.Features.Results;
using Mediator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MealOrdering.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll(GetAllSupplierQueryRequest getAllSupplierQueryRequest)
        {
            IDataResult<List<GetAllSupplierQueryResponse>>? response = await _mediator.Send(getAllSupplierQueryRequest);
            return Ok(response);
        }

        [HttpGet("Id")]
        public async Task<IActionResult> Get(GetByIdSupplierRequest getByIdSupplierRequest)
        {
            IDataResult<GetByIdSupplierResponse>? response = await _mediator.Send(getByIdSupplierRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateSupplierCommandRequest createSupplierCommandRequest)
        {
            IDataResult<SupplierDTO>? response = await _mediator.Send(createSupplierCommandRequest);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateSupplierCommandRequest updateSupplierCommandRequest)
        {
            IDataResult<SupplierDTO>? response = await _mediator.Send(updateSupplierCommandRequest);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteSupplierCommandRequest deleteSupplierCommandRequest)
        {
            IDataResult<SupplierDTO>? response = await _mediator.Send(deleteSupplierCommandRequest);
            return Ok(response);
        }

    }
}
