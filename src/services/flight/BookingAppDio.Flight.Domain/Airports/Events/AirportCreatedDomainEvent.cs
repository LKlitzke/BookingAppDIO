using BookingAppDio.Core.Event;

namespace BookingAppDio.Flight.Domain.Airports.Events
{
    public record AirportCreatedDomainEvent(long Id, string Name, string Address, string Code) : IDomainEvent;
}