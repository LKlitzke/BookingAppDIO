using BookingAppDio.Flight.Domain.Seats;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookingAppDio.Flight.Infra.Configurations
{
    public class SeatConfiguration : IEntityTypeConfiguration<Seat>
    {
        public void Configure(EntityTypeBuilder<Seat> builder)
        {
            builder.ToTable("Seats");

            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedNever();

            builder.HasOne<Domain.Flights.Models.Flight>()
                .WithMany()
                .HasForeignKey(f => f.FlightId);
        }
    }
}
