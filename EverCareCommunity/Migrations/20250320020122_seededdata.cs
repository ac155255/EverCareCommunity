using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EverCareCommunity.Migrations
{
    /// <inheritdoc />
    public partial class seededdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2025, 3, 27, 15, 1, 21, 947, DateTimeKind.Local).AddTicks(4643));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2025, 3, 6, 15, 1, 21, 947, DateTimeKind.Local).AddTicks(4710));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 3,
                column: "DateTime",
                value: new DateTime(2025, 3, 30, 15, 1, 21, 947, DateTimeKind.Local).AddTicks(4715));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 4,
                column: "DateTime",
                value: new DateTime(2025, 3, 15, 15, 1, 21, 947, DateTimeKind.Local).AddTicks(4718));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 5,
                column: "DateTime",
                value: new DateTime(2025, 3, 23, 15, 1, 21, 947, DateTimeKind.Local).AddTicks(4722));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 6,
                column: "DateTime",
                value: new DateTime(2025, 2, 28, 15, 1, 21, 947, DateTimeKind.Local).AddTicks(4725));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 7,
                column: "DateTime",
                value: new DateTime(2025, 4, 4, 15, 1, 21, 947, DateTimeKind.Local).AddTicks(4729));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 8,
                column: "DateTime",
                value: new DateTime(2025, 3, 21, 15, 1, 21, 947, DateTimeKind.Local).AddTicks(4733));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 9,
                column: "DateTime",
                value: new DateTime(2025, 3, 18, 15, 1, 21, 947, DateTimeKind.Local).AddTicks(4736));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 10,
                column: "DateTime",
                value: new DateTime(2025, 2, 18, 15, 1, 21, 947, DateTimeKind.Local).AddTicks(4740));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2025, 3, 27, 14, 44, 39, 59, DateTimeKind.Local).AddTicks(7742));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2025, 3, 6, 14, 44, 39, 59, DateTimeKind.Local).AddTicks(7849));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 3,
                column: "DateTime",
                value: new DateTime(2025, 3, 30, 14, 44, 39, 59, DateTimeKind.Local).AddTicks(7855));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 4,
                column: "DateTime",
                value: new DateTime(2025, 3, 15, 14, 44, 39, 59, DateTimeKind.Local).AddTicks(7859));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 5,
                column: "DateTime",
                value: new DateTime(2025, 3, 23, 14, 44, 39, 59, DateTimeKind.Local).AddTicks(7863));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 6,
                column: "DateTime",
                value: new DateTime(2025, 2, 28, 14, 44, 39, 59, DateTimeKind.Local).AddTicks(7868));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 7,
                column: "DateTime",
                value: new DateTime(2025, 4, 4, 14, 44, 39, 59, DateTimeKind.Local).AddTicks(7872));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 8,
                column: "DateTime",
                value: new DateTime(2025, 3, 21, 14, 44, 39, 59, DateTimeKind.Local).AddTicks(7878));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 9,
                column: "DateTime",
                value: new DateTime(2025, 3, 18, 14, 44, 39, 59, DateTimeKind.Local).AddTicks(7882));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 10,
                column: "DateTime",
                value: new DateTime(2025, 2, 18, 14, 44, 39, 59, DateTimeKind.Local).AddTicks(7886));
        }
    }
}
