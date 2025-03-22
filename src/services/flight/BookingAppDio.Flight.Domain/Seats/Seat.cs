using BookingAppDio.Core.Models;

namespace BookingAppDio.Flight.Domain.Seats
{
    public class Seat : Aggregate<long>
    {
        public string SeatNumber { get; private set; }
        public SeatType Type { get; private set; }
        public SeatClass Class { get; private set; }
        public long FlightId { get; private set; }

        public static Seat Create(long id, string seatNumber, SeatType type, SeatClass @class, long flightId)
        {
            return new Seat
            {
                Id = id,
                SeatNumber = seatNumber,
                Type = type,
                Class = @class,
                FlightId = flightId
            };
        }

        public Task<Seat> ReserveSeat(Seat seat)
        {
            seat.IsDeleted = true;
            seat.LastModified = DateTime.Now;
            return Task.FromResult(this);
        }
    }
}
