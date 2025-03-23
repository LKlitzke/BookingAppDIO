using BookingAppDio.Core.CQRS;
using BookingAppDio.Flight.API.Dtos;

namespace BookingAppDio.Flight.API.Application.Query.GetAvailableFlights
{
    public record GetAvailableFlightsQuery : IQuery<IEnumerable<FlightResponseDto>>
    {}
}