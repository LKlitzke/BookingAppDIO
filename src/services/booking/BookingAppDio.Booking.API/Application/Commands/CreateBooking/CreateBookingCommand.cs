using BookingAppDio.Booking.API.Dtos;
using BookingAppDio.Core.CQRS;

namespace BookingAppDio.Booking.API.Application.Commands.CreateBooking
{
    public record CreateBookingCommand(long PassengerId, long FlightId, string Description) : ICommand<CreateReservationResponseDto>
    {
        public Guid Id { get; init; } = Guid.NewGuid();
    }
}
