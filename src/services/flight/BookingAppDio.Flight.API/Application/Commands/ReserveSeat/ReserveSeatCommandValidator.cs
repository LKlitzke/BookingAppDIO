using FluentValidation;

namespace BookingAppDio.Flight.API.Application.Commands.ReserveSeat
{
    public class ReserveSeatCommandValidator : AbstractValidator<ReserveSeatCommand>
    {
        public ReserveSeatCommandValidator()
        {
            // para de executar o validador assim que uma regra falha
            ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.FlightId).NotEmpty().WithMessage("FlightId não deve ser vazio!");
            RuleFor(x => x.SeatNumber).NotEmpty().WithMessage("SeatNumber não deve ser vazio!");
        }
    }
}
