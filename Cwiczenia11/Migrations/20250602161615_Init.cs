using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cwiczenia11.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    IdDoctor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.IdDoctor);
                });

            migrationBuilder.CreateTable(
                name: "Medicament",
                columns: table => new
                {
                    IdMedicament = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicament", x => x.IdMedicament);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    IdPatient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Birthdate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.IdPatient);
                });

            migrationBuilder.CreateTable(
                name: "Prescription_Medicament",
                columns: table => new
                {
                    IdMedicament = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPrescription = table.Column<int>(type: "int", nullable: false),
                    Dose = table.Column<int>(type: "int", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MedicamentIdMedicament = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescription_Medicament", x => x.IdMedicament);
                    table.ForeignKey(
                        name: "FK_Prescription_Medicament_Medicament_MedicamentIdMedicament",
                        column: x => x.MedicamentIdMedicament,
                        principalTable: "Medicament",
                        principalColumn: "IdMedicament");
                });

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    IdPrescription = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    DueDate = table.Column<DateOnly>(type: "date", nullable: false),
                    IdPatient = table.Column<int>(type: "int", nullable: false),
                    IdDoctor = table.Column<int>(type: "int", nullable: false),
                    DoctorIdDoctor = table.Column<int>(type: "int", nullable: true),
                    PatientIdPatient = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.IdPrescription);
                    table.ForeignKey(
                        name: "FK_Prescriptions_Doctor_DoctorIdDoctor",
                        column: x => x.DoctorIdDoctor,
                        principalTable: "Doctor",
                        principalColumn: "IdDoctor");
                    table.ForeignKey(
                        name: "FK_Prescriptions_Patients_PatientIdPatient",
                        column: x => x.PatientIdPatient,
                        principalTable: "Patients",
                        principalColumn: "IdPatient");
                });

            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "IdDoctor", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "tomek@mail.com", "Tomek", "Nowak" },
                    { 2, "adrian@mail.com", "Adrian", "Nowak" }
                });

            migrationBuilder.InsertData(
                table: "Medicament",
                columns: new[] { "IdMedicament", "Description", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "Anti-Anxiety", "Xanax", "Drug" },
                    { 2, "Improves muscle mass", "Trenbolone", "Anabolic steroid" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "IdPatient", "Birthdate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateOnly(1999, 7, 13), "Maciek", "Nowak" },
                    { 2, new DateOnly(1998, 2, 15), "Ewa", "Nowak" }
                });

            migrationBuilder.InsertData(
                table: "Prescription_Medicament",
                columns: new[] { "IdMedicament", "Details", "Dose", "IdPrescription", "MedicamentIdMedicament" },
                values: new object[,]
                {
                    { 1, "Take twice daily", 100, 1, null },
                    { 2, "After meals", 400, 2, null }
                });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "IdPrescription", "Date", "DoctorIdDoctor", "DueDate", "IdDoctor", "IdPatient", "PatientIdPatient" },
                values: new object[,]
                {
                    { 1, new DateOnly(2024, 9, 17), null, new DateOnly(2024, 2, 26), 1, 1, null },
                    { 2, new DateOnly(2025, 1, 16), null, new DateOnly(2025, 3, 14), 2, 1, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_Medicament_MedicamentIdMedicament",
                table: "Prescription_Medicament",
                column: "MedicamentIdMedicament");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_DoctorIdDoctor",
                table: "Prescriptions",
                column: "DoctorIdDoctor");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_PatientIdPatient",
                table: "Prescriptions",
                column: "PatientIdPatient");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prescription_Medicament");

            migrationBuilder.DropTable(
                name: "Prescriptions");

            migrationBuilder.DropTable(
                name: "Medicament");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
