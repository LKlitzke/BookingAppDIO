using BookingAppDio.Core.CQRS;
using BookingAppDio.Flight.API.Dtos;

namespace BookingAppDio.Flight.API.Application.Query.GetAvailableSeats
{
    public record GetAvailableSeatsQuery(long FlightId) : IQuery<IEnumerable<SeatResponseDto>>;
}
