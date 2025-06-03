using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EverCareCommunity.Migrations
{
    /// <inheritdoc />
    public partial class Doctorroles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2025, 6, 5, 14, 34, 52, 892, DateTimeKind.Local).AddTicks(3363));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2025, 5, 15, 14, 34, 52, 892, DateTimeKind.Local).AddTicks(3485));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 3,
                column: "DateTime",
                value: new DateTime(2025, 6, 8, 14, 34, 52, 892, DateTimeKind.Local).AddTicks(3494));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 4,
                column: "DateTime",
                value: new DateTime(2025, 5, 24, 14, 34, 52, 892, DateTimeKind.Local).AddTicks(3502));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 5,
                column: "DateTime",
                value: new DateTime(2025, 6, 1, 14, 34, 52, 892, DateTimeKind.Local).AddTicks(3509));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 6,
                column: "DateTime",
                value: new DateTime(2025, 5, 9, 14, 34, 52, 892, DateTimeKind.Local).AddTicks(3517));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 7,
                column: "DateTime",
                value: new DateTime(2025, 6, 13, 14, 34, 52, 892, DateTimeKind.Local).AddTicks(3524));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 8,
                column: "DateTime",
                value: new DateTime(2025, 5, 30, 14, 34, 52, 892, DateTimeKind.Local).AddTicks(3532));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 9,
                column: "DateTime",
                value: new DateTime(2025, 5, 27, 14, 34, 52, 892, DateTimeKind.Local).AddTicks(3538));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 10,
                column: "DateTime",
                value: new DateTime(2025, 4, 29, 14, 34, 52, 892, DateTimeKind.Local).AddTicks(3545));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
