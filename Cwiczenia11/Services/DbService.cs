using Cwiczenia11.Data;
using Cwiczenia11.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Cwiczenia11.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }

    public Task<List<PatientDTO>> getPatientInfo(PatientDTO patient)
    {
        var patientInfo = _context.Patients.Select(e => new PatientDTO
        {
            FirstName = e.FirstName,
            IdPatient = patient.IdPatient,
            Prescriptions = e.Prescription.Select(a => new PrescriptionsDTO()
            {
                IdPrescription = a.IdPrescription,
                Date = a.Date,
                DueDate = a.DueDate,
                Doctor = new DoctorDTO
                {
                    FirstName = e.FirstName,
                    IdDoctor = a.IdDoctor,
                },
                Medicaments = _context.Medicaments.Select(m => new MedicamentsDTO()
                {
                    IdMedicament = m.IdMedicament,
                    Name = m.Name,
                    Description = m.Description,
                    Dose = 10
                }).ToList()
                
                
            }).ToList()
        }).ToListAsync();
        return patientInfo;
    }
}