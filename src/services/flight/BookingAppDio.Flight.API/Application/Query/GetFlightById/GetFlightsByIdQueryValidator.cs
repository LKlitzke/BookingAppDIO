using FluentValidation;

namespace BookingAppDio.Flight.API.Application.Query.GetFlightById
{
    public class GetFlightByIdQueryValidator : AbstractValidator<GetFlightByIdQuery>
    {
        public GetFlightByIdQueryValidator()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Id).NotNull().WithMessage("Id is required!");
        }
    }
}
