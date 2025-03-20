using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EverCareCommunity.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Caregivers",
                columns: table => new
                {
                    CaregiverID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    QualificationType = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Experience = table.Column<int>(type: "int", nullable: false),
                    Availability = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caregivers", x => x.CaregiverID);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    DoctorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LicenseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Availability = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.DoctorID);
                });

            migrationBuilder.CreateTable(
                name: "ElderlyResidents",
                columns: table => new
                {
                    ResidentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElderlyResidents", x => x.ResidentID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResidentID = table.Column<int>(type: "int", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Relationship = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressID);
                    table.ForeignKey(
                        name: "FK_Addresses_ElderlyResidents_ResidentID",
                        column: x => x.ResidentID,
                        principalTable: "ElderlyResidents",
                        principalColumn: "ResidentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    AppointmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResidentID = table.Column<int>(type: "int", nullable: false),
                    DoctorID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.AppointmentID);
                    table.ForeignKey(
                        name: "FK_Appointments_Doctors_DoctorID",
                        column: x => x.DoctorID,
                        principalTable: "Doctors",
                        principalColumn: "DoctorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_ElderlyResidents_ResidentID",
                        column: x => x.ResidentID,
                        principalTable: "ElderlyResidents",
                        principalColumn: "ResidentID");
                });

            migrationBuilder.CreateTable(
                name: "CaregiverResidentAssignments",
                columns: table => new
                {
                    AssignmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaregiverID = table.Column<int>(type: "int", nullable: false),
                    ResidentID = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaregiverResidentAssignments", x => x.AssignmentID);
                    table.ForeignKey(
                        name: "FK_CaregiverResidentAssignments_Caregivers_CaregiverID",
                        column: x => x.CaregiverID,
                        principalTable: "Caregivers",
                        principalColumn: "CaregiverID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CaregiverResidentAssignments_ElderlyResidents_ResidentID",
                        column: x => x.ResidentID,
                        principalTable: "ElderlyResidents",
                        principalColumn: "ResidentID");
                });

            migrationBuilder.CreateTable(
                name: "MedicalConditions",
                columns: table => new
                {
                    ConditionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResidentID = table.Column<int>(type: "int", nullable: false),
                    ConditionName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalConditions", x => x.ConditionID);
                    table.ForeignKey(
                        name: "FK_MedicalConditions_ElderlyResidents_ResidentID",
                        column: x => x.ResidentID,
                        principalTable: "ElderlyResidents",
                        principalColumn: "ResidentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalRecords",
                columns: table => new
                {
                    RecordID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResidentID = table.Column<int>(type: "int", nullable: false),
                    DoctorID = table.Column<int>(type: "int", nullable: false),
                    Diagnosis = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Prescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DateReported = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalRecords", x => x.RecordID);
                    table.ForeignKey(
                        name: "FK_MedicalRecords_Doctors_DoctorID",
                        column: x => x.DoctorID,
                        principalTable: "Doctors",
                        principalColumn: "DoctorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalRecords_ElderlyResidents_ResidentID",
                        column: x => x.ResidentID,
                        principalTable: "ElderlyResidents",
                        principalColumn: "ResidentID");
                });

            migrationBuilder.CreateTable(
                name: "EmergencyContacts",
                columns: table => new
                {
                    EmergencyContactID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResidentID = table.Column<int>(type: "int", nullable: false),
                    AddressID = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Relationship = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmergencyContacts", x => x.EmergencyContactID);
                    table.ForeignKey(
                        name: "FK_EmergencyContacts_Addresses_AddressID",
                        column: x => x.AddressID,
                        principalTable: "Addresses",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmergencyContacts_ElderlyResidents_ResidentID",
                        column: x => x.ResidentID,
                        principalTable: "ElderlyResidents",
                        principalColumn: "ResidentID");
                });

            migrationBuilder.InsertData(
                table: "Caregivers",
                columns: new[] { "CaregiverID", "Availability", "Email", "Experience", "FirstName", "LastName", "Phone", "QualificationType" },
                values: new object[,]
                {
                    { 1, true, "samantha.lewis@example.com", 8, "Samantha", "Lewis", "0218765432", 0 },
                    { 2, true, "daniel.smith@example.com", 5, "Daniel", "Smith", "0298654321", 1 },
                    { 3, false, "aisha.khan@example.com", 6, "Aisha", "Khan", "0276543210", 2 },
                    { 4, true, "michael.jones@example.com", 9, "Michael", "Jones", "0209871234", 3 },
                    { 5, false, "emma.garcia@example.com", 7, "Emma", "Garcia", "0245678901", 4 },
                    { 6, true, "ryan.taylor@example.com", 3, "Ryan", "Taylor", "0256789012", 0 },
                    { 7, true, "sophia.white@example.com", 10, "Sophia", "White", "0287654321", 1 },
                    { 8, false, "ethan.brown@example.com", 4, "Ethan", "Brown", "0223456789", 2 },
                    { 9, true, "olivia.martinez@example.com", 2, "Olivia", "Martinez", "0234567890", 3 },
                    { 10, false, "noah.harris@example.com", 11, "Noah", "Harris", "0212345678", 4 }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "DoctorID", "Availability", "Email", "FirstName", "LastName", "LicenseNumber", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, true, "john.miller@example.com", "John", "Miller", "D123456", "0211234567" },
                    { 2, false, "sarah.adams@example.com", "Sarah", "Adams", "D234567", "0223456789" },
                    { 3, true, "robert.wilson@example.com", "Robert", "Wilson", "D345678", "0234567890" },
                    { 4, true, "emily.johnson@example.com", "Emily", "Johnson", "D456789", "0245678901" },
                    { 5, false, "michael.clark@example.com", "Michael", "Clark", "D567890", "0256789012" },
                    { 6, true, "jessica.hall@example.com", "Jessica", "Hall", "D678901", "0267890123" },
                    { 7, true, "daniel.rodriguez@example.com", "Daniel", "Rodriguez", "D789012", "0278901234" },
                    { 8, false, "laura.davis@example.com", "Laura", "Davis", "D890123", "0289012345" },
                    { 9, true, "james.lopez@example.com", "James", "Lopez", "D901234", "0290123456" },
                    { 10, false, "olivia.perez@example.com", "Olivia", "Perez", "D012345", "0201234567" }
                });

            migrationBuilder.InsertData(
                table: "ElderlyResidents",
                columns: new[] { "ResidentID", "Address", "DateOfBirth", "Email", "FirstName", "Gender", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 10, "1523 Great South Road", new DateTime(1995, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "trishankj@example.com", "Trishank", 2, "Jetti", "0224359765" },
                    { 11, "423 Oakwood Avenue", new DateTime(1948, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "amara.patel@example.com", "Amara", 1, "Patel", "0213456789" },
                    { 12, "182 Pine Hill Road", new DateTime(1955, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "robert.thompson@example.com", "Robert", 0, "Thompson", "0279876543" },
                    { 13, "1289 Maple Lane", new DateTime(1950, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "linda.fernandez@example.com", "Linda", 1, "Fernandez", "0204567891" },
                    { 14, "305 Birch Street", new DateTime(1942, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "james.carter@example.com", "James", 0, "Carter", "0287654321" },
                    { 15, "1364 Sunset Boulevard", new DateTime(1947, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "maria.gonzalez@example.com", "Maria", 1, "Gonzalez", "0298765432" },
                    { 16, "523 Riverbank Drive", new DateTime(1953, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "william.miller@example.com", "William", 2, "Miller", "0212345678" },
                    { 17, "6542 Meadow Lane", new DateTime(1959, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "susan.anderson@example.com", "Susan", 1, "Anderson", "0265432109" },
                    { 18, "196 Cedar Avenue", new DateTime(1944, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "david.wilson@example.com", "David", 0, "Wilson", "0209871234" },
                    { 19, "9159 Elmwood Drive", new DateTime(1952, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "barbara.taylor@example.com", "Barbara", 1, "Taylor", "0256789012" },
                    { 20, "172 Greenway Road", new DateTime(1946, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "michael.martinez@example.com", "Michael", 2, "Martinez", "0245678901" }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "AppointmentID", "DateTime", "DoctorID", "ResidentID", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 27, 14, 26, 50, 6, DateTimeKind.Local).AddTicks(4548), 1, 11, 0 },
                    { 2, new DateTime(2025, 3, 6, 14, 26, 50, 6, DateTimeKind.Local).AddTicks(4623), 2, 12, 1 },
                    { 3, new DateTime(2025, 3, 30, 14, 26, 50, 6, DateTimeKind.Local).AddTicks(4628), 3, 13, 0 },
                    { 4, new DateTime(2025, 3, 15, 14, 26, 50, 6, DateTimeKind.Local).AddTicks(4631), 4, 14, 2 },
                    { 5, new DateTime(2025, 3, 23, 14, 26, 50, 6, DateTimeKind.Local).AddTicks(4635), 5, 15, 0 },
                    { 6, new DateTime(2025, 2, 28, 14, 26, 50, 6, DateTimeKind.Local).AddTicks(4639), 6, 16, 1 },
                    { 7, new DateTime(2025, 4, 4, 14, 26, 50, 6, DateTimeKind.Local).AddTicks(4642), 7, 17, 0 },
                    { 8, new DateTime(2025, 3, 21, 14, 26, 50, 6, DateTimeKind.Local).AddTicks(4646), 8, 18, 0 },
                    { 9, new DateTime(2025, 3, 18, 14, 26, 50, 6, DateTimeKind.Local).AddTicks(4649), 9, 19, 2 },
                    { 10, new DateTime(2025, 2, 18, 14, 26, 50, 6, DateTimeKind.Local).AddTicks(4653), 10, 20, 1 }
                });

            migrationBuilder.InsertData(
                table: "CaregiverResidentAssignments",
                columns: new[] { "AssignmentID", "CaregiverID", "Notes", "ResidentID" },
                values: new object[,]
                {
                    { 1, 1, "Morning care and medication assistance", 11 },
                    { 2, 2, "Daily physiotherapy and companionship", 12 },
                    { 3, 3, "Assistance with mobility and exercise", 13 },
                    { 4, 4, "Memory care support and routine supervision", 14 },
                    { 5, 5, "Diet monitoring and medication reminders", 15 }
                });

            migrationBuilder.InsertData(
                table: "MedicalConditions",
                columns: new[] { "ConditionID", "ConditionName", "Description", "ResidentID" },
                values: new object[,]
                {
                    { 1, "Hypertension", "High blood pressure requiring daily medication.", 11 },
                    { 2, "Diabetes", "Type 2 diabetes managed with insulin.", 12 },
                    { 3, "Arthritis", "Joint pain and inflammation.", 13 },
                    { 4, "Dementia", "Memory loss and cognitive decline.", 14 },
                    { 5, "Osteoporosis", "Weak and brittle bones.", 15 },
                    { 6, "Parkinson's Disease", "Nerve disorder affecting movement.", 16 },
                    { 7, "Heart Disease", "Coronary artery disease.", 17 },
                    { 8, "Asthma", "Chronic lung disease causing breathing difficulties.", 18 },
                    { 9, "Glaucoma", "Eye condition causing vision loss.", 19 },
                    { 10, "Alzheimer’s", "Progressive mental deterioration.", 20 }
                });

            migrationBuilder.InsertData(
                table: "MedicalRecords",
                columns: new[] { "RecordID", "DateReported", "Diagnosis", "DoctorID", "Prescription", "ResidentID" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hypertension", 1, "Lisinopril 10mg daily", 11 },
                    { 2, new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Type 2 Diabetes", 2, "Metformin 500mg twice daily", 12 },
                    { 3, new DateTime(2024, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Arthritis", 3, "Ibuprofen 400mg as needed", 13 },
                    { 4, new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mild Dementia", 4, "Donepezil 5mg daily", 14 },
                    { 5, new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "High Cholesterol", 5, "Atorvastatin 20mg daily", 15 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ResidentID",
                table: "Addresses",
                column: "ResidentID");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorID",
                table: "Appointments",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ResidentID",
                table: "Appointments",
                column: "ResidentID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CaregiverResidentAssignments_CaregiverID",
                table: "CaregiverResidentAssignments",
                column: "CaregiverID");

            migrationBuilder.CreateIndex(
                name: "IX_CaregiverResidentAssignments_ResidentID",
                table: "CaregiverResidentAssignments",
                column: "ResidentID");

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyContacts_AddressID",
                table: "EmergencyContacts",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyContacts_ResidentID",
                table: "EmergencyContacts",
                column: "ResidentID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalConditions_ResidentID",
                table: "MedicalConditions",
                column: "ResidentID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_DoctorID",
                table: "MedicalRecords",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_ResidentID",
                table: "MedicalRecords",
                column: "ResidentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CaregiverResidentAssignments");

            migrationBuilder.DropTable(
                name: "EmergencyContacts");

            migrationBuilder.DropTable(
                name: "MedicalConditions");

            migrationBuilder.DropTable(
                name: "MedicalRecords");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Caregivers");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "ElderlyResidents");
        }
    }
}
