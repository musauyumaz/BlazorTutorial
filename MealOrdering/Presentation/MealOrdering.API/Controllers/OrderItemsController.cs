using Application.Commons.Results;
using Application.Features.OrderItems.Commands.Create;
using Application.Features.OrderItems.Commands.Delete;
using Application.Features.OrderItems.Commands.Update;
using Application.Features.OrderItems.DTOs;
using Application.Features.OrderItems.Queries.GetAll;
using Application.Features.OrderItems.Queries.GetById;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace MealOrdering.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromRoute] GetAllOrderItemQueryRequest getAllOrderItemQueryRequest)
        {
            IDataResult<List<OrderItemDTO>>? response = await _mediator.Send(getAllOrderItemQueryRequest);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] GetByIdOrderItemQueryRequest getByIdOrderItemQueryRequest)
        {
            IDataResult<OrderItemDTO>? response = await _mediator.Send(getByIdOrderItemQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateOrderItemCommandRequest createOrderItemCommandRequest)
        {
           IDataResult<OrderItemDTO>? response = await _mediator.Send(createOrderItemCommandRequest);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateOrderItemCommandRequest updateOrderItemCommandRequest)
        {
            IDataResult<OrderItemDTO>? response = await _mediator.Send(updateOrderItemCommandRequest);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteOrderItemCommandRequest deleteOrderItemCommandRequest)
        {
            IDataResult<OrderItemDTO>? response = await _mediator.Send(deleteOrderItemCommandRequest);
            return Ok(response);
        }

    }
}
