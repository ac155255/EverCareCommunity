using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EverCareCommunity.Migrations
{
    /// <inheritdoc />
    public partial class fixedaddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_ElderlyResident_ElderlyResidentResidentID",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Doctor_DoctorID",
                table: "Appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_ElderlyResident_ResidentID",
                table: "Appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_CaregiverResidentAssignment_Caregiver_CaregiverID",
                table: "CaregiverResidentAssignment");

            migrationBuilder.DropForeignKey(
                name: "FK_CaregiverResidentAssignment_ElderlyResident_ResidentID",
                table: "CaregiverResidentAssignment");

            migrationBuilder.DropForeignKey(
                name: "FK_EmergencyContact_Address_AddressID",
                table: "EmergencyContact");

            migrationBuilder.DropForeignKey(
                name: "FK_EmergencyContact_ElderlyResident_ResidentID",
                table: "EmergencyContact");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalCondition_ElderlyResident_ResidentID",
                table: "MedicalCondition");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalRecord_Doctor_DoctorID",
                table: "MedicalRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalRecord_ElderlyResident_ResidentID",
                table: "MedicalRecord");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicalRecord",
                table: "MedicalRecord");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicalCondition",
                table: "MedicalCondition");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmergencyContact",
                table: "EmergencyContact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ElderlyResident",
                table: "ElderlyResident");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Doctor",
                table: "Doctor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CaregiverResidentAssignment",
                table: "CaregiverResidentAssignment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Caregiver",
                table: "Caregiver");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Appointment",
                table: "Appointment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Address",
                table: "Address");

            migrationBuilder.RenameTable(
                name: "MedicalRecord",
                newName: "MedicalRecords");

            migrationBuilder.RenameTable(
                name: "MedicalCondition",
                newName: "MedicalConditions");

            migrationBuilder.RenameTable(
                name: "EmergencyContact",
                newName: "EmergencyContacts");

            migrationBuilder.RenameTable(
                name: "ElderlyResident",
                newName: "ElderlyResidents");

            migrationBuilder.RenameTable(
                name: "Doctor",
                newName: "Doctors");

            migrationBuilder.RenameTable(
                name: "CaregiverResidentAssignment",
                newName: "CaregiverResidentAssignments");

            migrationBuilder.RenameTable(
                name: "Caregiver",
                newName: "Caregivers");

            migrationBuilder.RenameTable(
                name: "Appointment",
                newName: "Appointments");

            migrationBuilder.RenameTable(
                name: "Address",
                newName: "Addresses");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalRecord_ResidentID",
                table: "MedicalRecords",
                newName: "IX_MedicalRecords_ResidentID");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalRecord_DoctorID",
                table: "MedicalRecords",
                newName: "IX_MedicalRecords_DoctorID");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalCondition_ResidentID",
                table: "MedicalConditions",
                newName: "IX_MedicalConditions_ResidentID");

            migrationBuilder.RenameIndex(
                name: "IX_EmergencyContact_ResidentID",
                table: "EmergencyContacts",
                newName: "IX_EmergencyContacts_ResidentID");

            migrationBuilder.RenameIndex(
                name: "IX_EmergencyContact_AddressID",
                table: "EmergencyContacts",
                newName: "IX_EmergencyContacts_AddressID");

            migrationBuilder.RenameIndex(
                name: "IX_CaregiverResidentAssignment_ResidentID",
                table: "CaregiverResidentAssignments",
                newName: "IX_CaregiverResidentAssignments_ResidentID");

            migrationBuilder.RenameIndex(
                name: "IX_CaregiverResidentAssignment_CaregiverID",
                table: "CaregiverResidentAssignments",
                newName: "IX_CaregiverResidentAssignments_CaregiverID");

            migrationBuilder.RenameIndex(
                name: "IX_Appointment_ResidentID",
                table: "Appointments",
                newName: "IX_Appointments_ResidentID");

            migrationBuilder.RenameIndex(
                name: "IX_Appointment_DoctorID",
                table: "Appointments",
                newName: "IX_Appointments_DoctorID");

            migrationBuilder.RenameColumn(
                name: "ElderlyResidentResidentID",
                table: "Addresses",
                newName: "ResidentID");

            migrationBuilder.RenameIndex(
                name: "IX_Address_ElderlyResidentResidentID",
                table: "Addresses",
                newName: "IX_Addresses_ResidentID");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "ElderlyResidents",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicalRecords",
                table: "MedicalRecords",
                column: "RecordID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicalConditions",
                table: "MedicalConditions",
                column: "ConditionID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmergencyContacts",
                table: "EmergencyContacts",
                column: "EmergencyContactID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ElderlyResidents",
                table: "ElderlyResidents",
                column: "ResidentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Doctors",
                table: "Doctors",
                column: "DoctorID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CaregiverResidentAssignments",
                table: "CaregiverResidentAssignments",
                column: "AssignmentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Caregivers",
                table: "Caregivers",
                column: "CaregiverID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments",
                column: "AppointmentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "AddressID");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_ElderlyResidents_ResidentID",
                table: "Addresses",
                column: "ResidentID",
                principalTable: "ElderlyResidents",
                principalColumn: "ResidentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Doctors_DoctorID",
                table: "Appointments",
                column: "DoctorID",
                principalTable: "Doctors",
                principalColumn: "DoctorID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_ElderlyResidents_ResidentID",
                table: "Appointments",
                column: "ResidentID",
                principalTable: "ElderlyResidents",
                principalColumn: "ResidentID");

            migrationBuilder.AddForeignKey(
                name: "FK_CaregiverResidentAssignments_Caregivers_CaregiverID",
                table: "CaregiverResidentAssignments",
                column: "CaregiverID",
                principalTable: "Caregivers",
                principalColumn: "CaregiverID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CaregiverResidentAssignments_ElderlyResidents_ResidentID",
                table: "CaregiverResidentAssignments",
                column: "ResidentID",
                principalTable: "ElderlyResidents",
                principalColumn: "ResidentID");

            migrationBuilder.AddForeignKey(
                name: "FK_EmergencyContacts_Addresses_AddressID",
                table: "EmergencyContacts",
                column: "AddressID",
                principalTable: "Addresses",
                principalColumn: "AddressID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmergencyContacts_ElderlyResidents_ResidentID",
                table: "EmergencyContacts",
                column: "ResidentID",
                principalTable: "ElderlyResidents",
                principalColumn: "ResidentID");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalConditions_ElderlyResidents_ResidentID",
                table: "MedicalConditions",
                column: "ResidentID",
                principalTable: "ElderlyResidents",
                principalColumn: "ResidentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalRecords_Doctors_DoctorID",
                table: "MedicalRecords",
                column: "DoctorID",
                principalTable: "Doctors",
                principalColumn: "DoctorID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalRecords_ElderlyResidents_ResidentID",
                table: "MedicalRecords",
                column: "ResidentID",
                principalTable: "ElderlyResidents",
                principalColumn: "ResidentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_ElderlyResidents_ResidentID",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Doctors_DoctorID",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_ElderlyResidents_ResidentID",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_CaregiverResidentAssignments_Caregivers_CaregiverID",
                table: "CaregiverResidentAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_CaregiverResidentAssignments_ElderlyResidents_ResidentID",
                table: "CaregiverResidentAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_EmergencyContacts_Addresses_AddressID",
                table: "EmergencyContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_EmergencyContacts_ElderlyResidents_ResidentID",
                table: "EmergencyContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalConditions_ElderlyResidents_ResidentID",
                table: "MedicalConditions");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalRecords_Doctors_DoctorID",
                table: "MedicalRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalRecords_ElderlyResidents_ResidentID",
                table: "MedicalRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicalRecords",
                table: "MedicalRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicalConditions",
                table: "MedicalConditions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmergencyContacts",
                table: "EmergencyContacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ElderlyResidents",
                table: "ElderlyResidents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Doctors",
                table: "Doctors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Caregivers",
                table: "Caregivers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CaregiverResidentAssignments",
                table: "CaregiverResidentAssignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

            migrationBuilder.RenameTable(
                name: "MedicalRecords",
                newName: "MedicalRecord");

            migrationBuilder.RenameTable(
                name: "MedicalConditions",
                newName: "MedicalCondition");

            migrationBuilder.RenameTable(
                name: "EmergencyContacts",
                newName: "EmergencyContact");

            migrationBuilder.RenameTable(
                name: "ElderlyResidents",
                newName: "ElderlyResident");

            migrationBuilder.RenameTable(
                name: "Doctors",
                newName: "Doctor");

            migrationBuilder.RenameTable(
                name: "Caregivers",
                newName: "Caregiver");

            migrationBuilder.RenameTable(
                name: "CaregiverResidentAssignments",
                newName: "CaregiverResidentAssignment");

            migrationBuilder.RenameTable(
                name: "Appointments",
                newName: "Appointment");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "Address");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalRecords_ResidentID",
                table: "MedicalRecord",
                newName: "IX_MedicalRecord_ResidentID");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalRecords_DoctorID",
                table: "MedicalRecord",
                newName: "IX_MedicalRecord_DoctorID");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalConditions_ResidentID",
                table: "MedicalCondition",
                newName: "IX_MedicalCondition_ResidentID");

            migrationBuilder.RenameIndex(
                name: "IX_EmergencyContacts_ResidentID",
                table: "EmergencyContact",
                newName: "IX_EmergencyContact_ResidentID");

            migrationBuilder.RenameIndex(
                name: "IX_EmergencyContacts_AddressID",
                table: "EmergencyContact",
                newName: "IX_EmergencyContact_AddressID");

            migrationBuilder.RenameIndex(
                name: "IX_CaregiverResidentAssignments_ResidentID",
                table: "CaregiverResidentAssignment",
                newName: "IX_CaregiverResidentAssignment_ResidentID");

            migrationBuilder.RenameIndex(
                name: "IX_CaregiverResidentAssignments_CaregiverID",
                table: "CaregiverResidentAssignment",
                newName: "IX_CaregiverResidentAssignment_CaregiverID");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_ResidentID",
                table: "Appointment",
                newName: "IX_Appointment_ResidentID");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_DoctorID",
                table: "Appointment",
                newName: "IX_Appointment_DoctorID");

            migrationBuilder.RenameColumn(
                name: "ResidentID",
                table: "Address",
                newName: "ElderlyResidentResidentID");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_ResidentID",
                table: "Address",
                newName: "IX_Address_ElderlyResidentResidentID");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "ElderlyResident",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicalRecord",
                table: "MedicalRecord",
                column: "RecordID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicalCondition",
                table: "MedicalCondition",
                column: "ConditionID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmergencyContact",
                table: "EmergencyContact",
                column: "EmergencyContactID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ElderlyResident",
                table: "ElderlyResident",
                column: "ResidentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Doctor",
                table: "Doctor",
                column: "DoctorID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Caregiver",
                table: "Caregiver",
                column: "CaregiverID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CaregiverResidentAssignment",
                table: "CaregiverResidentAssignment",
                column: "AssignmentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appointment",
                table: "Appointment",
                column: "AppointmentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Address",
                table: "Address",
                column: "AddressID");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_ElderlyResident_ElderlyResidentResidentID",
                table: "Address",
                column: "ElderlyResidentResidentID",
                principalTable: "ElderlyResident",
                principalColumn: "ResidentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Doctor_DoctorID",
                table: "Appointment",
                column: "DoctorID",
                principalTable: "Doctor",
                principalColumn: "DoctorID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_ElderlyResident_ResidentID",
                table: "Appointment",
                column: "ResidentID",
                principalTable: "ElderlyResident",
                principalColumn: "ResidentID");

            migrationBuilder.AddForeignKey(
                name: "FK_CaregiverResidentAssignment_Caregiver_CaregiverID",
                table: "CaregiverResidentAssignment",
                column: "CaregiverID",
                principalTable: "Caregiver",
                principalColumn: "CaregiverID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CaregiverResidentAssignment_ElderlyResident_ResidentID",
                table: "CaregiverResidentAssignment",
                column: "ResidentID",
                principalTable: "ElderlyResident",
                principalColumn: "ResidentID");

            migrationBuilder.AddForeignKey(
                name: "FK_EmergencyContact_Address_AddressID",
                table: "EmergencyContact",
                column: "AddressID",
                principalTable: "Address",
                principalColumn: "AddressID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmergencyContact_ElderlyResident_ResidentID",
                table: "EmergencyContact",
                column: "ResidentID",
                principalTable: "ElderlyResident",
                principalColumn: "ResidentID");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalCondition_ElderlyResident_ResidentID",
                table: "MedicalCondition",
                column: "ResidentID",
                principalTable: "ElderlyResident",
                principalColumn: "ResidentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalRecord_Doctor_DoctorID",
                table: "MedicalRecord",
                column: "DoctorID",
                principalTable: "Doctor",
                principalColumn: "DoctorID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalRecord_ElderlyResident_ResidentID",
                table: "MedicalRecord",
                column: "ResidentID",
                principalTable: "ElderlyResident",
                principalColumn: "ResidentID");
        }
    }
}
