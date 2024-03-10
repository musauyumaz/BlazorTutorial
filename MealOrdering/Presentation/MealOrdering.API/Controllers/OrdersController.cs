using Application.Commons.Results;
using Application.Features.Orders.Commands.Create;
using Application.Features.Orders.Commands.Delete;
using Application.Features.Orders.Commands.Update;
using Application.Features.Orders.DTOs;
using Application.Features.Orders.Queries.GetAll;
using Application.Features.Orders.Queries.GetById;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace MealOrdering.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromRoute] GetAllOrderQueryRequest getAllOrderQueryRequest)
        {
            IDataResult<List<OrderDTO>>? response = await _mediator.Send(getAllOrderQueryRequest);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] GetByIdOrderQueryRequest getByIdOrderQueryRequest)
        {
            IDataResult<OrderDTO>? response = await _mediator.Send(getByIdOrderQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateOrderCommandRequest createOrderCommandRequest)
        {
            IDataResult<OrderDTO>? response = await _mediator.Send(createOrderCommandRequest);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateOrderCommandRequest updateOrderCommandRequest)
        {
            IDataResult<OrderDTO>? response = await _mediator.Send(updateOrderCommandRequest);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteOrderCommandRequest deleteOrderCommandRequest)
        {
            IDataResult<OrderDTO>? response = await _mediator.Send(deleteOrderCommandRequest);
            return Ok(response);
        }

    }
}
