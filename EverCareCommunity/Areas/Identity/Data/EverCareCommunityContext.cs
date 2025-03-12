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
    }
}
