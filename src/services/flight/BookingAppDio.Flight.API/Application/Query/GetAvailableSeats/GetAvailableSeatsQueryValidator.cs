using FluentValidation;

namespace BookingAppDio.Flight.API.Application.Query.GetAvailableSeats
{
    public class GetAvailableSeatsQueryValidator : AbstractValidator<GetAvailableSeatsQuery>
    {
        public GetAvailableSeatsQueryValidator()
        {
           ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.FlightId).NotNull().WithMessage("FlightId is required!");
        }
    }
}
