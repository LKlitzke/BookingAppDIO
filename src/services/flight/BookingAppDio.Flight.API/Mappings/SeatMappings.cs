using BookingAppDio.Flight.API.Dtos;
using BookingAppDio.Flight.Domain.Seats;
using Mapster;

namespace BookingAppDio.Flight.API.Mappings
{
    public class SeatMappings : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Seat, SeatResponseDto>();
        }
    }
}
