using Microsoft.EntityFrameworkCore;

namespace Cwiczenia11.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }

    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Doctor>(a =>
        {
            a.ToTable("Doctor");
            a.HasKey(e => e.IdDoctor);
            a.Property(e => e.FirstName).HasMaxLength(100);
            a.Property(e => e.LastName).HasMaxLength(100);
            a.Property(e => e.Email).HasMaxLength(100);
        });
        modelBuilder.Entity<Doctor>().HasData(new List<Prescription>()
        {
            new Prescription()
            {
                Date = new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day),
                DueDate = new DateOnly(DateTime.Now.Year + 1, DateTime.Now.Month, DateTime.Now.Day),
                IdDoctor = 1, IdPatient = 1, IdPrescription = 1
            },
            new Prescription()
            {
                Date = new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day),
                DueDate = new DateOnly(DateTime.Now.Year + 1, DateTime.Now.Month, DateTime.Now.Day),
                IdDoctor = 2, IdPatient = 1, IdPrescription = 2
            }
        });
    }
}