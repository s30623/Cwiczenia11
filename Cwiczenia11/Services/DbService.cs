using Cwiczenia11.Data;
using Cwiczenia11.DTOs;

namespace Cwiczenia11.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }

    public Task<List<PatientDTO>> getPatientInfo()
    {
        //var patientInfo = await _context.Patients;
        throw new NotImplementedException();
    }
}