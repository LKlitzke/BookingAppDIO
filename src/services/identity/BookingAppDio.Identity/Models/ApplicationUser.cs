using Microsoft.AspNetCore.Identity;

namespace BookingAppDio.Identity.Models
{
    public class ApplicationUser : IdentityUser<long>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? PassportNumber { get; set; }
    }
}
