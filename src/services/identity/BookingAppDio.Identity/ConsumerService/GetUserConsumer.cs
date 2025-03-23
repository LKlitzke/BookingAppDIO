using BookingAppDio.Core.Contracts;
using BookingAppDio.Identity.Data.Context;
using MassTransit;

namespace BookingAppDio.Identity.ConsumerService
{
    public class GetUserConsumer : IConsumer<RequestUserByPassportNumber>
    {
        private readonly IdentityContext _context;

        public GetUserConsumer(IdentityContext context)
        {
            _context = context;
        }
        public async Task Consume(ConsumeContext<RequestUserByPassportNumber> request)
        {
            var userEmail = _context.Users.Where(x => x.PassportNumber.Equals(request.Message.passportNumber)).ToList();

            var email = userEmail.Single().Email;
            if (userEmail is null)
            {
                throw new NotImplementedException("Email não encontrado");
            }

            await request.RespondAsync<GetUserResponse>(new GetUserResponse { PassengerEmail = email });
        }
    }
}
