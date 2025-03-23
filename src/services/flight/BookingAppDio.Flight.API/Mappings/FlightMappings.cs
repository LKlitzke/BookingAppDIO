using BookingAppDio.Flight.API.Application.Query.GetFlightById;
using BookingAppDio.Flight.API.Dtos;
using Mapster;

namespace BookingAppDio.Flight.API.Mappings
{
    public class FlightMappings : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Domain.Flights.Models.Flight, FlightResponseDto>();
            config.NewConfig<GetFlightByIdQuery, FlightResponseDto>();

        }
    }
}
