using BookingAppDio.Flight.Domain.Aircrafts.Models;
using BookingAppDio.Flight.Domain.Airports.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookingAppDio.Flight.Infra.Configurations
{
    public class FlightConfiguration : IEntityTypeConfiguration<Domain.Flights.Models.Flight>
    {
        public void Configure(EntityTypeBuilder<Domain.Flights.Models.Flight> builder)
        {
            builder.ToTable("Flights");

            builder.HasKey(f => f.Id);
            builder.Property(f => f.Id).ValueGeneratedNever();

            builder.HasOne<Aircraft>()
                .WithMany()
                .HasForeignKey(f => f.AircraftId);

            builder.HasOne<Airport>()
                .WithMany()
                .HasForeignKey(f => f.DepartureAirportId)
                .HasForeignKey(a => a.ArrivalAirportId);
        }
    }
}