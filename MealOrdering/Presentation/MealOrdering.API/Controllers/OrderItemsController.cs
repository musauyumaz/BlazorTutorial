using Application.Features.Commands.OrderItems;
using Application.Features.Commands.OrderItems.Create;
using Application.Features.Commands.OrderItems.Delete;
using Application.Features.Commands.OrderItems.Update;
using Application.Features.Queries.OrderItems.GetAll;
using Application.Features.Queries.OrderItems.GetById;
using Application.Features.Results;
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
