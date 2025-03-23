using BookingAppDio.Core.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BookingAppDio.Booking.Infra.Context
{
    public class BookingDbContext(DbContextOptions<BookingDbContext> options) : DbContext(options), IUnitOfWork
    {
        public DbSet<Domain.Models.Booking> Bookings => Set<Domain.Models.Booking>();

        public async Task<bool> Commit()
        {
            var sucess = await base.SaveChangesAsync() > 0;
            return sucess;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
