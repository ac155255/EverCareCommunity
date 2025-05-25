using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EverCareCommunity.Migrations
{
    /// <inheritdoc />
    public partial class improvingidentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2025, 6, 2, 11, 49, 32, 210, DateTimeKind.Local).AddTicks(2877));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2025, 5, 12, 11, 49, 32, 210, DateTimeKind.Local).AddTicks(2991));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 3,
                column: "DateTime",
                value: new DateTime(2025, 6, 5, 11, 49, 32, 210, DateTimeKind.Local).AddTicks(2999));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 4,
                column: "DateTime",
                value: new DateTime(2025, 5, 21, 11, 49, 32, 210, DateTimeKind.Local).AddTicks(3004));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 5,
                column: "DateTime",
                value: new DateTime(2025, 5, 29, 11, 49, 32, 210, DateTimeKind.Local).AddTicks(3010));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 6,
                column: "DateTime",
                value: new DateTime(2025, 5, 6, 11, 49, 32, 210, DateTimeKind.Local).AddTicks(3016));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 7,
                column: "DateTime",
                value: new DateTime(2025, 6, 10, 11, 49, 32, 210, DateTimeKind.Local).AddTicks(3021));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 8,
                column: "DateTime",
                value: new DateTime(2025, 5, 27, 11, 49, 32, 210, DateTimeKind.Local).AddTicks(3026));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 9,
                column: "DateTime",
                value: new DateTime(2025, 5, 24, 11, 49, 32, 210, DateTimeKind.Local).AddTicks(3032));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 10,
                column: "DateTime",
                value: new DateTime(2025, 4, 26, 11, 49, 32, 210, DateTimeKind.Local).AddTicks(3037));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2025, 5, 26, 12, 22, 25, 62, DateTimeKind.Local).AddTicks(3168));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2025, 5, 5, 12, 22, 25, 62, DateTimeKind.Local).AddTicks(3290));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 3,
                column: "DateTime",
                value: new DateTime(2025, 5, 29, 12, 22, 25, 62, DateTimeKind.Local).AddTicks(3304));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 4,
                column: "DateTime",
                value: new DateTime(2025, 5, 14, 12, 22, 25, 62, DateTimeKind.Local).AddTicks(3313));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 5,
                column: "DateTime",
                value: new DateTime(2025, 5, 22, 12, 22, 25, 62, DateTimeKind.Local).AddTicks(3322));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 6,
                column: "DateTime",
                value: new DateTime(2025, 4, 29, 12, 22, 25, 62, DateTimeKind.Local).AddTicks(3330));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 7,
                column: "DateTime",
                value: new DateTime(2025, 6, 3, 12, 22, 25, 62, DateTimeKind.Local).AddTicks(3338));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 8,
                column: "DateTime",
                value: new DateTime(2025, 5, 20, 12, 22, 25, 62, DateTimeKind.Local).AddTicks(3345));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 9,
                column: "DateTime",
                value: new DateTime(2025, 5, 17, 12, 22, 25, 62, DateTimeKind.Local).AddTicks(3352));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 10,
                column: "DateTime",
                value: new DateTime(2025, 4, 19, 12, 22, 25, 62, DateTimeKind.Local).AddTicks(3359));
        }
    }
}
