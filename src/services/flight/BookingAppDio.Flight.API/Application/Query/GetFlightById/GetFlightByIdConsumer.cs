using BookingAppDio.Core.Contracts;
using BookingAppDio.Flight.Infra.Context;
using Mapster;
using MapsterMapper;
using MassTransit;
using MediatR;

namespace BookingAppDio.Flight.API.Application.Query.GetFlightById
{
    public class GetFlightByIdConsumer : IConsumer<Core.Contracts.GetFlightById>
    {
        private readonly IMapper _mapper;
        private FlightDbContext _context;
        private IMediator _mediator;

        public GetFlightByIdConsumer(FlightDbContext context, IMediator mediator, IMapper mapper)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<Core.Contracts.GetFlightById> context)
        {
            var query = new GetFlightByIdQuery(context.Message.FlightId);
            var flight = await _mediator.Send(query);

            var result = flight.Adapt<FlightResponse>();

            await context.RespondAsync<FlightResponse>(result);
        }
    }
}
