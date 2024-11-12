using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AirlineManagement.Migrations
{
    /// <inheritdoc />
    public partial class SeedFlightData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AvailableSeats", "DepartureDate", "DepartureTime", "Destination", "FlightNumber", "Origin" },
                values: new object[,]
                {
                    { 1, 50, new DateTime(2024, 11, 11, 16, 58, 49, 253, DateTimeKind.Local).AddTicks(9477), new DateTime(2024, 11, 12, 2, 58, 49, 253, DateTimeKind.Local).AddTicks(9507), "Los Angeles", "AB123", "New York" },
                    { 2, 30, new DateTime(2024, 11, 12, 16, 58, 49, 253, DateTimeKind.Local).AddTicks(9514), new DateTime(2024, 11, 13, 4, 58, 49, 253, DateTimeKind.Local).AddTicks(9516), "Chicago", "CD456", "San Francisco" },
                    { 3, 25, new DateTime(2024, 11, 14, 16, 58, 49, 253, DateTimeKind.Local).AddTicks(9521), new DateTime(2024, 11, 15, 6, 58, 49, 253, DateTimeKind.Local).AddTicks(9523), "Dallas", "EF789", "Miami" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
