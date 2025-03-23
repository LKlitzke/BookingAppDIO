using BookingAppDio.Booking.API.Application.Commands.CreateBooking;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingAppDio.Booking.API.Controllers
{
    [ApiController]
    [Route("api/reservas")]
    public class BookingController : ControllerBase
    {

        private readonly IMediator _mediator;

        public BookingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[Authorize]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateReservation([FromBody] CreateBookingCommand command,
       CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);

            return Ok(result);
        }
    }
}
