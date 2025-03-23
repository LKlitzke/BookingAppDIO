using BookingAppDio.Booking.Domain.Models.ValueObjects;
using BookingAppDio.Core.Models;

namespace BookingAppDio.Booking.Domain.Models
{
    public class Booking : Aggregate<Guid>
    {
        public Booking()
        {
        }

        public Trip Trip { get; private set; }
        public PassengerInfo PassengerInfo { get; private set; }

        public static Booking Create(Guid id, PassengerInfo passengerInfo, Trip trip, bool isDeleted = false)
        {
            return new Booking()
            {
                Id = id,
                Trip = trip,
                PassengerInfo = passengerInfo,
                IsDeleted = isDeleted
            };
        }
    }
}
