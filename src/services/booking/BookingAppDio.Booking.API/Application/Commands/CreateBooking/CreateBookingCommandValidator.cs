using FluentValidation;

namespace BookingAppDio.Booking.API.Application.Commands.CreateBooking
{
    public class CreateBookingCommandValidator : AbstractValidator<CreateBookingCommand>
    {
        public CreateBookingCommandValidator()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.FlightId).NotNull().WithMessage("FlightId é obrigatório!");
            RuleFor(x => x.PassengerId).NotNull().WithMessage("PassengerId é obrigatório!");
        }
    }
}
