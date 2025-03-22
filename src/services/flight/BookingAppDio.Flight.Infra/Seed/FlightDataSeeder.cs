using BookingAppDio.Flight.Domain.Aircrafts.Models;
using BookingAppDio.Flight.Domain.Airports.Models;
using BookingAppDio.Flight.Domain.Flights.Models;
using BookingAppDio.Flight.Domain.Seats;
using BookingAppDio.Flight.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace BookingAppDio.Flight.Infra.Seed
{
    public class FlightDataSeeder : IDataSeeder
    {
        private readonly FlightDbContext _flightDbContext;

        public FlightDataSeeder(FlightDbContext flightDbContext)
        {
            _flightDbContext = flightDbContext;
        }

        public async Task SeedAllAsync()
        {
            await SeedAirportAsync();
            await SeedAircraftAsync();
            await SeedFlightAsync();
            await SeedSeatAsync();
        }

        private async Task SeedAirportAsync()
        {
            if (!await _flightDbContext.Airports.AnyAsync())
            {
                var airports = new List<Airport>
                {
                    Airport.Create(1, "Aeroporto Internacional de São Paulo/Guarulhos", "Rod. Hélio Smidt, s/n - Cumbica, Guarulhos - SP", "GRU"),
                    Airport.Create(2, "Aeroporto Internacional de Brasília", "Lago Sul, Brasília - DF", "BSB"),
                    Airport.Create(3, "Aeroporto Internacional de Congonhas", "Av. Washington Luís, s/n - Vila Congonhas, São Paulo - SP", "CGH"),
                    Airport.Create(4, "Aeroporto Internacional de Belo Horizonte/Confins", "Rod. MG-10, s/n - Confins, Belo Horizonte - MG", "CNF"),
                    Airport.Create(5, "Aeroporto Internacional de Salvador", "Praça Gago Coutinho, s/n - São Cristóvão, Salvador - BA", "SSA"),
                };
                await _flightDbContext.Airports.AddRangeAsync(airports);
                await _flightDbContext.SaveChangesAsync();
            }
        }
        private async Task SeedAircraftAsync()
        {
            if (!await _flightDbContext.Aircrafts.AnyAsync())
            {
                var aircrafts = new List<Aircraft>
                {
                    Aircraft.Create(1, "Boeing 737", "B700"),
                    Aircraft.Create(2, "Boeing 737", "B800"),
                    Aircraft.Create(3, "Airbus 320", "A320"),
                    Aircraft.Create(4, "Airbus 321", "A321"),
                    Aircraft.Create(5, "Embraer 195", "E195"),
                };
                await _flightDbContext.Aircrafts.AddRangeAsync(aircrafts);
                await _flightDbContext.SaveChangesAsync();
            }
        }

        private async Task SeedSeatAsync()
        {
            if (!await _flightDbContext.Seats.AnyAsync())
            {
                var seats = new List<Seat>
                {
                    Seat.Create(1, "1A", SeatType.Window, SeatClass.FirstClass, 1),
                    Seat.Create(2, "1B", SeatType.Window, SeatClass.Business, 1),
                    Seat.Create(3, "1C", SeatType.Window, SeatClass.Economy, 1),
                    Seat.Create(4, "2A", SeatType.Middle, SeatClass.FirstClass, 1),
                    Seat.Create(5, "2B", SeatType.Middle, SeatClass.Economy, 1),
                    Seat.Create(6, "2C", SeatType.Middle, SeatClass.Business, 1),
                    Seat.Create(7, "3A", SeatType.Middle, SeatClass.Business, 1),
                    Seat.Create(8, "3B", SeatType.Aisle, SeatClass.FirstClass, 1),
                    Seat.Create(9, "3C", SeatType.Aisle, SeatClass.Business, 1),
                    Seat.Create(10, "4A", SeatType.Aisle, SeatClass.Economy, 1)
                };

                await _flightDbContext.Seats.AddRangeAsync(seats);
                await _flightDbContext.SaveChangesAsync();
            }
        }

        private async Task SeedFlightAsync()
        {
            if (!await _flightDbContext.Flights.AnyAsync())
            {
                var flights = new List<Domain.Flights.Models.Flight>
                {
                    Domain.Flights.Models.Flight.Create(1, "L17", 2, DateTime.Now.AddDays(-15), 1, DateTime.Now.AddDays(-15).AddHours(2), 2, 120, DateTime.Now.AddDays(-15), FlightStatus.Completed, 5020),
                    Domain.Flights.Models.Flight.Create(1, "D02", 3, DateTime.Now.AddDays(-1), 5, DateTime.Now.AddDays(-1).AddHours(7), 5, 420, DateTime.Now.AddDays(-1), FlightStatus.Delay, 10500),
                    Domain.Flights.Models.Flight.Create(1, "T30", 1, DateTime.Now, 1, DateTime.Now.AddHours(5), 1, 300, DateTime.Now, FlightStatus.Canceled, 13700),
                    Domain.Flights.Models.Flight.Create(1, "K13", 5, DateTime.Now.AddDays(6), 1, DateTime.Now.AddDays(6).AddHours(1), 4, 60, DateTime.Now.AddDays(6), FlightStatus.Canceled, 4100),
                };
                await _flightDbContext.Flights.AddRangeAsync(flights);
                await _flightDbContext.SaveChangesAsync();
            }
        }
    }
}