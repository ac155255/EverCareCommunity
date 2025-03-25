using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EverCareCommunity.Migrations
{
    /// <inheritdoc />
    public partial class datamanagement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressID",
                keyValue: 5);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "ElderlyResidents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2025, 3, 28, 13, 55, 17, 596, DateTimeKind.Local).AddTicks(7123));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2025, 3, 7, 13, 55, 17, 596, DateTimeKind.Local).AddTicks(7222));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 3,
                column: "DateTime",
                value: new DateTime(2025, 3, 31, 13, 55, 17, 596, DateTimeKind.Local).AddTicks(7228));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 4,
                column: "DateTime",
                value: new DateTime(2025, 3, 16, 13, 55, 17, 596, DateTimeKind.Local).AddTicks(7234));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 5,
                column: "DateTime",
                value: new DateTime(2025, 3, 24, 13, 55, 17, 596, DateTimeKind.Local).AddTicks(7240));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 6,
                column: "DateTime",
                value: new DateTime(2025, 3, 1, 13, 55, 17, 596, DateTimeKind.Local).AddTicks(7245));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 7,
                column: "DateTime",
                value: new DateTime(2025, 4, 5, 13, 55, 17, 596, DateTimeKind.Local).AddTicks(7251));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 8,
                column: "DateTime",
                value: new DateTime(2025, 3, 22, 13, 55, 17, 596, DateTimeKind.Local).AddTicks(7256));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 9,
                column: "DateTime",
                value: new DateTime(2025, 3, 19, 13, 55, 17, 596, DateTimeKind.Local).AddTicks(7261));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 10,
                column: "DateTime",
                value: new DateTime(2025, 2, 19, 13, 55, 17, 596, DateTimeKind.Local).AddTicks(7266));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "ElderlyResidents",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "AddressID", "City", "PhoneNumber", "Relationship", "ResidentID", "Street", "ZipCode" },
                values: new object[] { 5, "Seaside", "+5678901234", "Friend", 15, "202 Birch Court", "56789" });

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
    }
}
