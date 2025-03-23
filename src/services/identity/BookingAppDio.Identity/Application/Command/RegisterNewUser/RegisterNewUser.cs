using BookingAppDio.Core.CQRS;
using BookingAppDio.Identity.Dtos;

namespace BookingAppDio.Identity.Application.Command.RegisterNewUser
{
    public record RegisterNewUserCommand(string FirstName, string LastName, string Username, string Email,
     string Password, string ConfirmPassword, string PassportNumber) : ICommand<RegisterNewUserResponseDto>;

}
