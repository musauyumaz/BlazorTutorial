using Application.Features.Commands.Users;
using Application.Features.Commands.Users.Create;
using Application.Features.Commands.Users.Delete;
using Application.Features.Commands.Users.Update;
using Application.Features.Queries.Users.GetAll;
using Application.Features.Queries.Users.GetById;
using Application.Features.Results;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace MealOrdering.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromRoute] GetAllUserQueryRequest getAllUserQueryRequest)
        {
            IDataResult<List<UserDTO>>? response = await _mediator.Send(getAllUserQueryRequest);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] GetByIdUserQueryRequest getByIdUserQueryRequest)
        {
            IDataResult<UserDTO>? response = await _mediator.Send(getByIdUserQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateUserCommandRequest createUserCommandRequest)
        {
            IDataResult<UserDTO>? response = await _mediator.Send(createUserCommandRequest);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserCommandRequest updateUserCommandRequest)
        {
            IDataResult<UserDTO>? response = await _mediator.Send(updateUserCommandRequest);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteUserCommandRequest deleteUserCommandRequest)
        {
            IDataResult<UserDTO>? response = await _mediator.Send(deleteUserCommandRequest);
            return Ok(response);
        }
    }
}
