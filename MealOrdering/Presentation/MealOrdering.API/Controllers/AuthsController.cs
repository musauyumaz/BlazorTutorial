using Application.Commons.Results;
using Application.Features.Auths.Commands;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace MealOrdering.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController(IMediator _mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Get(LoginUserCommandRequest loginUserCommandRequest)
        {
            IDataResult<LoginUserCommandResponse>? response = await _mediator.Send(loginUserCommandRequest);
            return Ok(response);
        }
    }
}
