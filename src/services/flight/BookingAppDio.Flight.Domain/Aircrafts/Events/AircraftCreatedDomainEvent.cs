namespace BookingAppDio.Flight.Domain.Aircrafts.Events
{
    public record AircraftCreatedDomainEvent(long Id, string Name, string Model) : IDomainEvent;
}