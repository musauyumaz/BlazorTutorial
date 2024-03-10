using Application.Commons.Results;
using Application.Features.Suppliers.Commands.Create;
using Application.Features.Suppliers.Commands.Delete;
using Application.Features.Suppliers.Commands.Update;
using Application.Features.Suppliers.DTOs;
using Application.Features.Suppliers.Queries.GetAll;
using Application.Features.Suppliers.Queries.GetById;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace MealOrdering.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromRoute] GetAllSupplierQueryRequest getAllSupplierQueryRequest)
        {
            IDataResult<List<GetAllSupplierQueryResponse>>? response = await _mediator.Send(getAllSupplierQueryRequest);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] GetByIdSupplierRequest getByIdSupplierRequest)
        {
            IDataResult<GetByIdSupplierResponse>? response = await _mediator.Send(getByIdSupplierRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateSupplierCommandRequest createSupplierCommandRequest)
        {
            IDataResult<SupplierDTO>? response = await _mediator.Send(createSupplierCommandRequest);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateSupplierCommandRequest updateSupplierCommandRequest)
        {
            IDataResult<SupplierDTO>? response = await _mediator.Send(updateSupplierCommandRequest);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteSupplierCommandRequest deleteSupplierCommandRequest)
        {
            IDataResult<SupplierDTO>? response = await _mediator.Send(deleteSupplierCommandRequest);
            return Ok(response);
        }

    }
}
