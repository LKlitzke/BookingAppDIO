using BookingAppDio.Core.CQRS;
using BookingAppDio.Flight.API.Dtos;

namespace BookingAppDio.Flight.API.Application.Commands.ReserveSeat
{
    public record ReserveSeatCommand(long FlightId, string SeatNumber) : ICommand<SeatResponseDto>;
}
