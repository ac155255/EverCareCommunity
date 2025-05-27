using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EverCareCommunity.Migrations
{
    /// <inheritdoc />
    public partial class roleerror : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2025, 6, 2, 12, 55, 8, 758, DateTimeKind.Local).AddTicks(6035));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2025, 5, 12, 12, 55, 8, 758, DateTimeKind.Local).AddTicks(6146));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 3,
                column: "DateTime",
                value: new DateTime(2025, 6, 5, 12, 55, 8, 758, DateTimeKind.Local).AddTicks(6153));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 4,
                column: "DateTime",
                value: new DateTime(2025, 5, 21, 12, 55, 8, 758, DateTimeKind.Local).AddTicks(6159));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 5,
                column: "DateTime",
                value: new DateTime(2025, 5, 29, 12, 55, 8, 758, DateTimeKind.Local).AddTicks(6164));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 6,
                column: "DateTime",
                value: new DateTime(2025, 5, 6, 12, 55, 8, 758, DateTimeKind.Local).AddTicks(6170));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 7,
                column: "DateTime",
                value: new DateTime(2025, 6, 10, 12, 55, 8, 758, DateTimeKind.Local).AddTicks(6175));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 8,
                column: "DateTime",
                value: new DateTime(2025, 5, 27, 12, 55, 8, 758, DateTimeKind.Local).AddTicks(6181));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 9,
                column: "DateTime",
                value: new DateTime(2025, 5, 24, 12, 55, 8, 758, DateTimeKind.Local).AddTicks(6186));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 10,
                column: "DateTime",
                value: new DateTime(2025, 4, 26, 12, 55, 8, 758, DateTimeKind.Local).AddTicks(6192));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
