using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EverCareCommunity.Migrations
{
    /// <inheritdoc />
    public partial class emegencycontactandaddressdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "AddressID", "City", "PhoneNumber", "Relationship", "ResidentID", "Street", "ZipCode" },
                values: new object[,]
                {
                    { 1, "Springfield", "+1234567890", "Guardian", 11, "123 Elm Street", "12345" },
                    { 2, "Rivertown", "+2345678901", "Child", 12, "456 Oak Avenue", "23456" },
                    { 3, "Lakewood", "+3456789012", "Spouse", 13, "789 Pine Road", "34567" },
                    { 4, "Hillview", "+4567890123", "Sibling", 14, "101 Maple Lane", "45678" },
                    { 5, "Seaside", "+5678901234", "Friend", 15, "202 Birch Court", "56789" }
                });

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

            migrationBuilder.InsertData(
                table: "EmergencyContacts",
                columns: new[] { "EmergencyContactID", "AddressID", "FirstName", "LastName", "PhoneNumber", "Relationship", "ResidentID" },
                values: new object[,]
                {
                    { 1, 1, "John", "Doe", "+1234567890", 4, 11 },
                    { 2, 2, "Emily", "Smith", "+2345678901", 1, 12 },
                    { 3, 3, "Michael", "Johnson", "+3456789012", 2, 13 },
                    { 4, 4, "Sarah", "Williams", "+4567890123", 3, 14 },
                    { 5, 5, "David", "Brown", "+5678901234", 5, 15 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmergencyContacts",
                keyColumn: "EmergencyContactID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EmergencyContacts",
                keyColumn: "EmergencyContactID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EmergencyContacts",
                keyColumn: "EmergencyContactID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EmergencyContacts",
                keyColumn: "EmergencyContactID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "EmergencyContacts",
                keyColumn: "EmergencyContactID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressID",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2025, 3, 27, 14, 26, 50, 6, DateTimeKind.Local).AddTicks(4548));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2025, 3, 6, 14, 26, 50, 6, DateTimeKind.Local).AddTicks(4623));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 3,
                column: "DateTime",
                value: new DateTime(2025, 3, 30, 14, 26, 50, 6, DateTimeKind.Local).AddTicks(4628));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 4,
                column: "DateTime",
                value: new DateTime(2025, 3, 15, 14, 26, 50, 6, DateTimeKind.Local).AddTicks(4631));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 5,
                column: "DateTime",
                value: new DateTime(2025, 3, 23, 14, 26, 50, 6, DateTimeKind.Local).AddTicks(4635));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 6,
                column: "DateTime",
                value: new DateTime(2025, 2, 28, 14, 26, 50, 6, DateTimeKind.Local).AddTicks(4639));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 7,
                column: "DateTime",
                value: new DateTime(2025, 4, 4, 14, 26, 50, 6, DateTimeKind.Local).AddTicks(4642));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 8,
                column: "DateTime",
                value: new DateTime(2025, 3, 21, 14, 26, 50, 6, DateTimeKind.Local).AddTicks(4646));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 9,
                column: "DateTime",
                value: new DateTime(2025, 3, 18, 14, 26, 50, 6, DateTimeKind.Local).AddTicks(4649));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 10,
                column: "DateTime",
                value: new DateTime(2025, 2, 18, 14, 26, 50, 6, DateTimeKind.Local).AddTicks(4653));
        }
    }
}
