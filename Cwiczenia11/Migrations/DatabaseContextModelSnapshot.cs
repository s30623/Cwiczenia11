﻿// <auto-generated />
using System;
using Cwiczenia11.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cwiczenia11.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Cwiczenia11.Data.Doctor", b =>
                {
                    b.Property<int>("IdDoctor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDoctor"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdDoctor");

                    b.ToTable("Doctor");

                    b.HasData(
                        new
                        {
                            IdDoctor = 1,
                            Email = "tomek@mail.com",
                            FirstName = "Tomek",
                            LastName = "Nowak"
                        },
                        new
                        {
                            IdDoctor = 2,
                            Email = "adrian@mail.com",
                            FirstName = "Adrian",
                            LastName = "Nowak"
                        });
                });

            modelBuilder.Entity("Cwiczenia11.Data.Medicament", b =>
                {
                    b.Property<int>("IdMedicament")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMedicament"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdMedicament");

                    b.ToTable("Medicament");

                    b.HasData(
                        new
                        {
                            IdMedicament = 1,
                            Description = "Anti-Anxiety",
                            Name = "Xanax",
                            Type = "Drug"
                        },
                        new
                        {
                            IdMedicament = 2,
                            Description = "Improves muscle mass",
                            Name = "Trenbolone",
                            Type = "Anabolic steroid"
                        });
                });

            modelBuilder.Entity("Cwiczenia11.Data.Patient", b =>
                {
                    b.Property<int>("IdPatient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPatient"));

                    b.Property<DateOnly>("Birthdate")
                        .HasColumnType("date");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdPatient");

                    b.ToTable("Patients");

                    b.HasData(
                        new
                        {
                            IdPatient = 1,
                            Birthdate = new DateOnly(1999, 7, 13),
                            FirstName = "Maciek",
                            LastName = "Nowak"
                        },
                        new
                        {
                            IdPatient = 2,
                            Birthdate = new DateOnly(1998, 2, 15),
                            FirstName = "Ewa",
                            LastName = "Nowak"
                        });
                });

            modelBuilder.Entity("Cwiczenia11.Data.Prescription", b =>
                {
                    b.Property<int>("IdPrescription")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPrescription"));

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<int?>("DoctorIdDoctor")
                        .HasColumnType("int");

                    b.Property<DateOnly>("DueDate")
                        .HasColumnType("date");

                    b.Property<int>("IdDoctor")
                        .HasColumnType("int");

                    b.Property<int>("IdPatient")
                        .HasColumnType("int");

                    b.Property<int?>("PatientIdPatient")
                        .HasColumnType("int");

                    b.HasKey("IdPrescription");

                    b.HasIndex("DoctorIdDoctor");

                    b.HasIndex("PatientIdPatient");

                    b.ToTable("Prescriptions");

                    b.HasData(
                        new
                        {
                            IdPrescription = 1,
                            Date = new DateOnly(2024, 9, 17),
                            DueDate = new DateOnly(2024, 2, 26),
                            IdDoctor = 1,
                            IdPatient = 1
                        },
                        new
                        {
                            IdPrescription = 2,
                            Date = new DateOnly(2025, 1, 16),
                            DueDate = new DateOnly(2025, 3, 14),
                            IdDoctor = 2,
                            IdPatient = 1
                        });
                });

            modelBuilder.Entity("Cwiczenia11.Data.PrescriptionMedicament", b =>
                {
                    b.Property<int>("IdMedicament")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMedicament"));

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("Dose")
                        .HasColumnType("int");

                    b.Property<int>("IdPrescription")
                        .HasColumnType("int");

                    b.Property<int?>("MedicamentIdMedicament")
                        .HasColumnType("int");

                    b.HasKey("IdMedicament");

                    b.HasIndex("MedicamentIdMedicament");

                    b.ToTable("Prescription_Medicament");

                    b.HasData(
                        new
                        {
                            IdMedicament = 1,
                            Details = "Take twice daily",
                            Dose = 100,
                            IdPrescription = 1
                        },
                        new
                        {
                            IdMedicament = 2,
                            Details = "After meals",
                            Dose = 400,
                            IdPrescription = 2
                        });
                });

            modelBuilder.Entity("Cwiczenia11.Data.Prescription", b =>
                {
                    b.HasOne("Cwiczenia11.Data.Doctor", null)
                        .WithMany("Prescription")
                        .HasForeignKey("DoctorIdDoctor");

                    b.HasOne("Cwiczenia11.Data.Patient", null)
                        .WithMany("Prescription")
                        .HasForeignKey("PatientIdPatient");
                });

            modelBuilder.Entity("Cwiczenia11.Data.PrescriptionMedicament", b =>
                {
                    b.HasOne("Cwiczenia11.Data.Medicament", null)
                        .WithMany("Prescription_Medicament")
                        .HasForeignKey("MedicamentIdMedicament");
                });

            modelBuilder.Entity("Cwiczenia11.Data.Doctor", b =>
                {
                    b.Navigation("Prescription");
                });

            modelBuilder.Entity("Cwiczenia11.Data.Medicament", b =>
                {
                    b.Navigation("Prescription_Medicament");
                });

            modelBuilder.Entity("Cwiczenia11.Data.Patient", b =>
                {
                    b.Navigation("Prescription");
                });
#pragma warning restore 612, 618
        }
    }
}
