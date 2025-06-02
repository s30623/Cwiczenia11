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
        
         modelBuilder.Entity<Doctor>().HasData(new List<Doctor>()
        {
            new Doctor() { IdDoctor = 1, FirstName = "Tomek", LastName = "Nowak", Email = "tomek@mail.com" },
            new Doctor() { IdDoctor = 2, FirstName = "Adrian", LastName = "Nowak", Email = "adrian@mail.com" },
        });
        
        modelBuilder.Entity<Patient>().HasData(new List<Patient>()
        {
            new Patient(){ IdPatient = 1, FirstName = "Maciek", LastName = "Nowak", Birthdate = DateOnly.Parse("1999-07-13")},
            new Patient(){ IdPatient = 2, FirstName = "Ewa", LastName = "Nowak", Birthdate = DateOnly.Parse("1998-02-15")},
        });

        modelBuilder.Entity<Medicament>().HasData(new List<Medicament>()
        {
            new Medicament(){IdMedicament = 1, Name = "Xanax", Description = "Anti-Anxiety", Type = "Drug"},
            new Medicament(){IdMedicament = 2, Name = "Trenbolone", Description = "Improves muscle mass", Type = "Anabolic steroid"},
        });

        modelBuilder.Entity<Prescription>().HasData(new List<Prescription>()
        {
            new Prescription(){IdPrescription = 1, Date = DateOnly.Parse("2024-09-17"),	DueDate = DateOnly.Parse("2024-02-26"),	IdPatient = 1, IdDoctor	= 1},   
            new Prescription(){IdPrescription = 2, Date = DateOnly.Parse("2025-01-16"),	DueDate = DateOnly.Parse("2025-03-14"),	IdPatient = 1, IdDoctor	= 2},   
        });
        modelBuilder.Entity<PrescriptionMedicament>().HasKey(e => e.IdPrescription);
        modelBuilder.Entity<PrescriptionMedicament>().HasKey(e => e.IdMedicament);
        modelBuilder.Entity<PrescriptionMedicament>().HasData(new List<PrescriptionMedicament>()
        {
          new PrescriptionMedicament(){IdMedicament = 1, IdPrescription = 1, Dose = 100, Details = "Take twice daily" },   
          new PrescriptionMedicament(){IdMedicament = 2, IdPrescription = 2, Dose = 400, Details = "After meals" },   
        });
    
    }
}