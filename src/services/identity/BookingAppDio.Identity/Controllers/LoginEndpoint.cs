using BookingAppDio.Identity.Application.Command.RegisterNewUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingAppDio.Identity.Controllers
{
    [Route("api/register-user")]
    [ApiController]
    public class LoginEndpoint : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoginEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        // [Authorize]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //  [SwaggerOperation(Summary = "Register new user", Description = "Register new user")]
        public async Task<ActionResult> RegisterNewUser([FromBody] RegisterNewUserCommand command,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);

            return Ok(result);
        }
    }
}
