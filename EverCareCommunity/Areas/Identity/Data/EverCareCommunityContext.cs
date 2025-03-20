using EverCareCommunity.Areas.Identity.Data;
using EverCareCommunity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EverCareCommunity.Data;

public class EverCareCommunityContext : IdentityDbContext<EverCareCommunityUser>
{
    public EverCareCommunityContext(DbContextOptions<EverCareCommunityContext> options)
        : base(options)
    {
    }

    public DbSet<ElderlyResident> ElderlyResidents { get; set; } = default!;
    public DbSet<Address> Addresses { get; set; } = default!;
    public DbSet<Appointment> Appointments { get; set; } = default!;
    public DbSet<Caregiver> Caregivers { get; set; } = default!;
    public DbSet<CaregiverResidentAssignment> CaregiverResidentAssignments { get; set; } = default!;
    public DbSet<Doctor> Doctors { get; set; } = default!;
    public DbSet<EmergencyContact> EmergencyContacts { get; set; } = default!;
    public DbSet<MedicalCondition> MedicalConditions { get; set; } = default!;
    public DbSet<MedicalRecord> MedicalRecords { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Prevent cascade delete in Appointment → ElderlyResident
        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.ElderlyResident)
            .WithMany(er => er.Appointments)
            .HasForeignKey(a => a.ResidentID)
            .OnDelete(DeleteBehavior.NoAction);

        // Prevent cascade delete in CaregiverResidentAssignment → ElderlyResident
        modelBuilder.Entity<CaregiverResidentAssignment>()
            .HasOne(cra => cra.ElderlyResident)
            .WithMany(er => er.CaregiverAssignments)
            .HasForeignKey(cra => cra.ResidentID)
            .OnDelete(DeleteBehavior.NoAction);

        // Prevent cascade delete in MedicalRecord → ElderlyResident
        modelBuilder.Entity<MedicalRecord>()
            .HasOne(mr => mr.ElderlyResident)
            .WithMany(er => er.MedicalRecords)
            .HasForeignKey(mr => mr.ResidentID)
            .OnDelete(DeleteBehavior.NoAction);

        // Prevent cascade delete in EmergencyContact → ElderlyResident
        modelBuilder.Entity<EmergencyContact>()
            .HasOne(ec => ec.ElderlyResident)
            .WithMany(er => er.EmergencyContacts)
            .HasForeignKey(ec => ec.ResidentID)
            .OnDelete(DeleteBehavior.NoAction);

        // Prevent cascade delete in Address → ElderlyResident
        modelBuilder.Entity<Address>()
            .HasOne(a => a.ElderlyResident)
            .WithMany(e => e.Addresses)
            .HasForeignKey(a => a.ResidentID)
            .OnDelete(DeleteBehavior.Cascade);



        modelBuilder.Entity<ElderlyResident>().HasData(
     new ElderlyResident
     {
         ResidentID = 10,
         FirstName = "Trishank",
         LastName = "Jetti",
         Email = "trishankj@example.com",
         DateOfBirth = new DateTime(1995, 5, 20),
         PhoneNumber = "0224359765",
         Gender = GenderType.Other,
         Address = "1523 Great South Road"
     },
     new ElderlyResident
     {
         ResidentID = 11,
         FirstName = "Amara",
         LastName = "Patel",
         Email = "amara.patel@example.com",
         DateOfBirth = new DateTime(1948, 3, 15),
         PhoneNumber = "0213456789",
         Gender = GenderType.Female,
         Address = "423 Oakwood Avenue"
     },
    new ElderlyResident
    {
        ResidentID = 12,
        FirstName = "Robert",
        LastName = "Thompson",
        Email = "robert.thompson@example.com",
        DateOfBirth = new DateTime(1955, 7, 22),
        PhoneNumber = "0279876543",
        Gender = GenderType.Male,
        Address = "182 Pine Hill Road"
    },
    new ElderlyResident
    {
        ResidentID = 13,
        FirstName = "Linda",
        LastName = "Fernandez",
        Email = "linda.fernandez@example.com",
        DateOfBirth = new DateTime(1950, 12, 5),
        PhoneNumber = "0204567891",
        Gender = GenderType.Female,
        Address = "1289 Maple Lane"
    },
    new ElderlyResident
    {
        ResidentID = 14,
        FirstName = "James",
        LastName = "Carter",
        Email = "james.carter@example.com",
        DateOfBirth = new DateTime(1942, 9, 30),
        PhoneNumber = "0287654321",
        Gender = GenderType.Male,
        Address = "305 Birch Street"
    },
    new ElderlyResident
    {
        ResidentID = 15,
        FirstName = "Maria",
        LastName = "Gonzalez",
        Email = "maria.gonzalez@example.com",
        DateOfBirth = new DateTime(1947, 6, 12),
        PhoneNumber = "0298765432",
        Gender = GenderType.Female,
        Address = "1364 Sunset Boulevard"
    },
    new ElderlyResident
    {
        ResidentID = 16,
        FirstName = "William",
        LastName = "Miller",
        Email = "william.miller@example.com",
        DateOfBirth = new DateTime(1953, 2, 18),
        PhoneNumber = "0212345678",
        Gender = GenderType.Other,
        Address = "523 Riverbank Drive"
    },
    new ElderlyResident
    {
        ResidentID = 17,
        FirstName = "Susan",
        LastName = "Anderson",
        Email = "susan.anderson@example.com",
        DateOfBirth = new DateTime(1959, 11, 8),
        PhoneNumber = "0265432109",
        Gender = GenderType.Female,
        Address = "6542 Meadow Lane"
    },
    new ElderlyResident
    {
        ResidentID = 18,
        FirstName = "David",
        LastName = "Wilson",
        Email = "david.wilson@example.com",
        DateOfBirth = new DateTime(1944, 4, 25),
        PhoneNumber = "0209871234",
        Gender = GenderType.Male,
        Address = "196 Cedar Avenue"
    },
    new ElderlyResident
    {
        ResidentID = 19,
        FirstName = "Barbara",
        LastName = "Taylor",
        Email = "barbara.taylor@example.com",
        DateOfBirth = new DateTime(1952, 1, 17),
        PhoneNumber = "0256789012",
        Gender = GenderType.Female,
        Address = "9159 Elmwood Drive"
    },
    new ElderlyResident
    {
        ResidentID = 20,
        FirstName = "Michael",
        LastName = "Martinez",
        Email = "michael.martinez@example.com",
        DateOfBirth = new DateTime(1946, 8, 29),
        PhoneNumber = "0245678901",
        Gender = GenderType.Other,
        Address = "172 Greenway Road"
    });
        modelBuilder.Entity<Caregiver>().HasData(
    new Caregiver { CaregiverID = 1, FirstName = "Samantha", LastName = "Lewis", QualificationType = Qualification.FirstAidAndCPR, Email = "samantha.lewis@example.com", Phone = "0218765432", Experience = 8, Availability = true },
    new Caregiver { CaregiverID = 2, FirstName = "Daniel", LastName = "Smith", QualificationType = Qualification.CaregiverCertification, Email = "daniel.smith@example.com", Phone = "0298654321", Experience = 5, Availability = true },
    new Caregiver { CaregiverID = 3, FirstName = "Aisha", LastName = "Khan", QualificationType = Qualification.HomeHealthAideCertification, Email = "aisha.khan@example.com", Phone = "0276543210", Experience = 6, Availability = false },
    new Caregiver { CaregiverID = 4, FirstName = "Michael", LastName = "Jones", QualificationType = Qualification.FoodHandlingAndNutrition, Email = "michael.jones@example.com", Phone = "0209871234", Experience = 9, Availability = true },
    new Caregiver { CaregiverID = 5, FirstName = "Emma", LastName = "Garcia", QualificationType = Qualification.AlzheimersAndDementiaCare, Email = "emma.garcia@example.com", Phone = "0245678901", Experience = 7, Availability = false },
    new Caregiver { CaregiverID = 6, FirstName = "Ryan", LastName = "Taylor", QualificationType = Qualification.FirstAidAndCPR, Email = "ryan.taylor@example.com", Phone = "0256789012", Experience = 3, Availability = true },
    new Caregiver { CaregiverID = 7, FirstName = "Sophia", LastName = "White", QualificationType = Qualification.CaregiverCertification, Email = "sophia.white@example.com", Phone = "0287654321", Experience = 10, Availability = true },
    new Caregiver { CaregiverID = 8, FirstName = "Ethan", LastName = "Brown", QualificationType = Qualification.HomeHealthAideCertification, Email = "ethan.brown@example.com", Phone = "0223456789", Experience = 4, Availability = false },
    new Caregiver { CaregiverID = 9, FirstName = "Olivia", LastName = "Martinez", QualificationType = Qualification.FoodHandlingAndNutrition, Email = "olivia.martinez@example.com", Phone = "0234567890", Experience = 2, Availability = true },
    new Caregiver { CaregiverID = 10, FirstName = "Noah", LastName = "Harris", QualificationType = Qualification.AlzheimersAndDementiaCare, Email = "noah.harris@example.com", Phone = "0212345678", Experience = 11, Availability = false }
     );
        modelBuilder.Entity<Doctor>().HasData(
    new Doctor { DoctorID = 1, FirstName = "John", LastName = "Miller", Email = "john.miller@example.com", LicenseNumber = "D123456", PhoneNumber = "0211234567", Availability = true },
    new Doctor { DoctorID = 2, FirstName = "Sarah", LastName = "Adams", Email = "sarah.adams@example.com", LicenseNumber = "D234567", PhoneNumber = "0223456789", Availability = false },
    new Doctor { DoctorID = 3, FirstName = "Robert", LastName = "Wilson", Email = "robert.wilson@example.com", LicenseNumber = "D345678", PhoneNumber = "0234567890", Availability = true },
    new Doctor { DoctorID = 4, FirstName = "Emily", LastName = "Johnson", Email = "emily.johnson@example.com", LicenseNumber = "D456789", PhoneNumber = "0245678901", Availability = true },
    new Doctor { DoctorID = 5, FirstName = "Michael", LastName = "Clark", Email = "michael.clark@example.com", LicenseNumber = "D567890", PhoneNumber = "0256789012", Availability = false },
    new Doctor { DoctorID = 6, FirstName = "Jessica", LastName = "Hall", Email = "jessica.hall@example.com", LicenseNumber = "D678901", PhoneNumber = "0267890123", Availability = true },
    new Doctor { DoctorID = 7, FirstName = "Daniel", LastName = "Rodriguez", Email = "daniel.rodriguez@example.com", LicenseNumber = "D789012", PhoneNumber = "0278901234", Availability = true },
    new Doctor { DoctorID = 8, FirstName = "Laura", LastName = "Davis", Email = "laura.davis@example.com", LicenseNumber = "D890123", PhoneNumber = "0289012345", Availability = false },
    new Doctor { DoctorID = 9, FirstName = "James", LastName = "Lopez", Email = "james.lopez@example.com", LicenseNumber = "D901234", PhoneNumber = "0290123456", Availability = true },
    new Doctor { DoctorID = 10, FirstName = "Olivia", LastName = "Perez", Email = "olivia.perez@example.com", LicenseNumber = "D012345", PhoneNumber = "0201234567", Availability = false }
    );
        modelBuilder.Entity<MedicalCondition>().HasData(
    new MedicalCondition { ConditionID = 1, ResidentID = 11, ConditionName = "Hypertension", Description = "High blood pressure requiring daily medication." },
    new MedicalCondition { ConditionID = 2, ResidentID = 12, ConditionName = "Diabetes", Description = "Type 2 diabetes managed with insulin." },
    new MedicalCondition { ConditionID = 3, ResidentID = 13, ConditionName = "Arthritis", Description = "Joint pain and inflammation." },
    new MedicalCondition { ConditionID = 4, ResidentID = 14, ConditionName = "Dementia", Description = "Memory loss and cognitive decline." },
    new MedicalCondition { ConditionID = 5, ResidentID = 15, ConditionName = "Osteoporosis", Description = "Weak and brittle bones." },
    new MedicalCondition { ConditionID = 6, ResidentID = 16, ConditionName = "Parkinson's Disease", Description = "Nerve disorder affecting movement." },
    new MedicalCondition { ConditionID = 7, ResidentID = 17, ConditionName = "Heart Disease", Description = "Coronary artery disease." },
    new MedicalCondition { ConditionID = 8, ResidentID = 18, ConditionName = "Asthma", Description = "Chronic lung disease causing breathing difficulties." },
    new MedicalCondition { ConditionID = 9, ResidentID = 19, ConditionName = "Glaucoma", Description = "Eye condition causing vision loss." },
    new MedicalCondition { ConditionID = 10, ResidentID = 20, ConditionName = "Alzheimer’s", Description = "Progressive mental deterioration." }
    );
        modelBuilder.Entity<Appointment>().HasData(
    new Appointment { AppointmentID = 1, ResidentID = 11, DoctorID = 1, Status = AppointmentStatus.Scheduled, DateTime = DateTime.Now.AddDays(7) },
    new Appointment { AppointmentID = 2, ResidentID = 12, DoctorID = 2, Status = AppointmentStatus.Completed, DateTime = DateTime.Now.AddDays(-14) },
    new Appointment { AppointmentID = 3, ResidentID = 13, DoctorID = 3, Status = AppointmentStatus.Scheduled, DateTime = DateTime.Now.AddDays(10) },
    new Appointment { AppointmentID = 4, ResidentID = 14, DoctorID = 4, Status = AppointmentStatus.Cancelled, DateTime = DateTime.Now.AddDays(-5) },
    new Appointment { AppointmentID = 5, ResidentID = 15, DoctorID = 5, Status = AppointmentStatus.Scheduled, DateTime = DateTime.Now.AddDays(3) },
    new Appointment { AppointmentID = 6, ResidentID = 16, DoctorID = 6, Status = AppointmentStatus.Completed, DateTime = DateTime.Now.AddDays(-20) },
    new Appointment { AppointmentID = 7, ResidentID = 17, DoctorID = 7, Status = AppointmentStatus.Scheduled, DateTime = DateTime.Now.AddDays(15) },
    new Appointment { AppointmentID = 8, ResidentID = 18, DoctorID = 8, Status = AppointmentStatus.Scheduled, DateTime = DateTime.Now.AddDays(1) },
    new Appointment { AppointmentID = 9, ResidentID = 19, DoctorID = 9, Status = AppointmentStatus.Cancelled, DateTime = DateTime.Now.AddDays(-2) },
    new Appointment { AppointmentID = 10, ResidentID = 20, DoctorID = 10, Status = AppointmentStatus.Completed, DateTime = DateTime.Now.AddDays(-30) }
    );
        modelBuilder.Entity<MedicalRecord>().HasData(
      new MedicalRecord { RecordID = 1, ResidentID = 11, DoctorID = 1, Diagnosis = "Hypertension", Prescription = "Lisinopril 10mg daily", DateReported = new DateTime(2024, 3, 10) },
      new MedicalRecord { RecordID = 2, ResidentID = 12, DoctorID = 2, Diagnosis = "Type 2 Diabetes", Prescription = "Metformin 500mg twice daily", DateReported = new DateTime(2024, 3, 5) },
      new MedicalRecord { RecordID = 3, ResidentID = 13, DoctorID = 3, Diagnosis = "Arthritis", Prescription = "Ibuprofen 400mg as needed", DateReported = new DateTime(2024, 2, 28) },
      new MedicalRecord { RecordID = 4, ResidentID = 14, DoctorID = 4, Diagnosis = "Mild Dementia", Prescription = "Donepezil 5mg daily", DateReported = new DateTime(2024, 2, 20) },
      new MedicalRecord { RecordID = 5, ResidentID = 15, DoctorID = 5, Diagnosis = "High Cholesterol", Prescription = "Atorvastatin 20mg daily", DateReported = new DateTime(2024, 2, 15) }
      );
        modelBuilder.Entity<CaregiverResidentAssignment>().HasData(
        new CaregiverResidentAssignment { AssignmentID = 1, CaregiverID = 1, ResidentID = 11, Notes = "Morning care and medication assistance" },
        new CaregiverResidentAssignment { AssignmentID = 2, CaregiverID = 2, ResidentID = 12, Notes = "Daily physiotherapy and companionship" },
        new CaregiverResidentAssignment { AssignmentID = 3, CaregiverID = 3, ResidentID = 13, Notes = "Assistance with mobility and exercise" },
        new CaregiverResidentAssignment { AssignmentID = 4, CaregiverID = 4, ResidentID = 14, Notes = "Memory care support and routine supervision" },
        new CaregiverResidentAssignment { AssignmentID = 5, CaregiverID = 5, ResidentID = 15, Notes = "Diet monitoring and medication reminders" }
        );
        























    }









}
