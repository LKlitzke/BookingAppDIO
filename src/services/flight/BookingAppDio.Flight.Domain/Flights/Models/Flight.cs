using BookingAppDio.Core.Models;

namespace BookingAppDio.Flight.Domain.Flights.Models
{
    public class Flight : Aggregate<long>
    {
        public string FlightNumber { get; private set; }
        public long AircraftId { get; private set; }
        public DateTime DepartureDate { get; private set; }
        public long DepartureAirportId { get; private set; }
        public DateTime ArrivalDate { get; private set; }
        public long ArrivalAirportId { get; private set; }
        public decimal DurationMinutes { get; private set; }
        public DateTime FlightDate { get; private set; }
        public FlightStatus Status { get; private set; }
        public decimal Price { get; private set; }

        public static Flight Create(long id, string flightNumber, long aircraftId, DateTime departureDate, long departureAirportId, DateTime arrivalDate, long arrivalAirportId, decimal durationMinutes, DateTime flightDate, FlightStatus status, decimal price, bool IsDeleted = false)
        {
            return new Flight
            {
                Id = id,
                FlightNumber = flightNumber,
                AircraftId = aircraftId,
                DepartureDate = departureDate,
                DepartureAirportId = departureAirportId,
                ArrivalDate = arrivalDate,
                ArrivalAirportId = arrivalAirportId,
                DurationMinutes = durationMinutes,
                FlightDate = flightDate,
                Status = status,
                Price = price,
                IsDeleted = IsDeleted
            };
        }
    }
}
