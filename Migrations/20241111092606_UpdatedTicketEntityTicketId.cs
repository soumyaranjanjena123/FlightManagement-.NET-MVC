using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirlineManagement.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedTicketEntityTicketId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DepartureDate", "DepartureTime" },
                values: new object[] { new DateTime(2024, 11, 13, 14, 56, 3, 503, DateTimeKind.Local).AddTicks(2016), new DateTime(2024, 11, 14, 0, 56, 3, 503, DateTimeKind.Local).AddTicks(2045) });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DepartureDate", "DepartureTime" },
                values: new object[] { new DateTime(2024, 11, 14, 14, 56, 3, 503, DateTimeKind.Local).AddTicks(2052), new DateTime(2024, 11, 15, 2, 56, 3, 503, DateTimeKind.Local).AddTicks(2053) });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DepartureDate", "DepartureTime" },
                values: new object[] { new DateTime(2024, 11, 16, 14, 56, 3, 503, DateTimeKind.Local).AddTicks(2058), new DateTime(2024, 11, 17, 4, 56, 3, 503, DateTimeKind.Local).AddTicks(2060) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DepartureDate", "DepartureTime" },
                values: new object[] { new DateTime(2024, 11, 11, 16, 58, 49, 253, DateTimeKind.Local).AddTicks(9477), new DateTime(2024, 11, 12, 2, 58, 49, 253, DateTimeKind.Local).AddTicks(9507) });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DepartureDate", "DepartureTime" },
                values: new object[] { new DateTime(2024, 11, 12, 16, 58, 49, 253, DateTimeKind.Local).AddTicks(9514), new DateTime(2024, 11, 13, 4, 58, 49, 253, DateTimeKind.Local).AddTicks(9516) });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DepartureDate", "DepartureTime" },
                values: new object[] { new DateTime(2024, 11, 14, 16, 58, 49, 253, DateTimeKind.Local).AddTicks(9521), new DateTime(2024, 11, 15, 6, 58, 49, 253, DateTimeKind.Local).AddTicks(9523) });
        }
    }
}
