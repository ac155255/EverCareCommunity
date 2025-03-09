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
       
    }
    public DbSet<EverCareCommunity.Models.ElderlyResident> ElderlyResident { get; set; } = default!;

    public DbSet<EverCareCommunity.Models.Address> Address { get; set; } = default!;

    public DbSet<EverCareCommunity.Models.Appointment> Appointment { get; set; } = default!;

    public DbSet<EverCareCommunity.Models.Caregiver> Caregiver { get; set; } = default!;

    public DbSet<EverCareCommunity.Models.CaregiverResidentAssignment> CaregiverResidentAssignment { get; set; } = default!;

    public DbSet<EverCareCommunity.Models.Doctor> Doctor { get; set; } = default!;

    public DbSet<EverCareCommunity.Models.EmergencyContact> EmergencyContact { get; set; } = default!;

    public DbSet<EverCareCommunity.Models.MedicalCondition> MedicalCondition { get; set; } = default!;

    public DbSet<EverCareCommunity.Models.MedicalRecord> MedicalRecord { get; set; } = default!;
}
