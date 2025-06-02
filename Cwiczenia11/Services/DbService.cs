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
        var patientInfo = _context.Patients.Where(p => p.IdPatient == patient.IdPatient)
            .Select(e => new PatientDTO
        {
            FirstName = e.FirstName,
            IdPatient = e.IdPatient,
            Prescriptions = e.Prescription.OrderBy(o => o.DueDate)
                .Select(a => new PrescriptionsDTO()
            {
                IdPrescription = a.IdPrescription,
                Date = a.Date,
                DueDate = a.DueDate,
                Doctor = _context.Doctors.Where(d => d.IdDoctor == a.IdDoctor).Select(d => new DoctorDTO
                {
                    IdDoctor = d.IdDoctor,
                    FirstName = d.FirstName
                }).FirstOrDefault(),
                Medicaments = _context.PrescriptionMedicaments.Where(m => m.IdPrescription == a.IdPrescription).Select(m => new MedicamentsDTO
                {
                    IdMedicament = m.IdMedicament,
                    Name = _context.Medicaments.Where(mm => mm.IdMedicament == m.IdMedicament).Select((mm => mm.Name)).FirstOrDefault(),
                    Description = _context.Medicaments.Where(dd => m.IdMedicament == dd.IdMedicament).Select((dd => dd.Description)).FirstOrDefault(),
                    Dose = m.Dose ?? 0
                }).ToList()
                
                
            }).ToList()
        }).ToListAsync();
        return patientInfo;
    }
}