using BookingAppDio.Core.Contracts;
using MapsterMapper;
using MassTransit;
using MediatR;

namespace BookingAppDio.Flight.API.Application.Query.GetAvailableSeats
{
    public class GetAvailableSeatsConsumer : IConsumer<GetAvailableSeatsById>
    {
        private readonly IMapper _mapper;
        private IMediator _mediator;

        public GetAvailableSeatsConsumer(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        public async Task Consume(ConsumeContext<GetAvailableSeatsById> context)
        {
            var flighId = context.Message.FlightId;
            var query = new GetAvailableSeatsQuery(flighId);
            var seatList = await _mediator.Send(query);

            var message = seatList.First(); // pega o primeiro assento vazio

            await context.RespondAsync<SeatResponse>(message);
        }
    }
}
