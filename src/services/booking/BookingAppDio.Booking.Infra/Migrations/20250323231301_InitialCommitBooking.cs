using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingAppDio.Booking.Infra.Migrations
{
    /// <inheritdoc />
    public partial class InitialCommitBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Trip_FlightNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Trip_AircraftId = table.Column<long>(type: "bigint", nullable: false),
                    Trip_DepartureAirportId = table.Column<long>(type: "bigint", nullable: false),
                    Trip_ArriveAirportId = table.Column<long>(type: "bigint", nullable: false),
                    Trip_FlightDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Trip_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Trip_Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Trip_SeatNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassengerInfo_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");
        }
    }
}
