using Cwiczenia11.Data;
using Cwiczenia11.DTOs;

namespace Cwiczenia11.Services;

public interface IDbService
{
    Task<List<PatientDTO>> getPatientInfo(PatientDTO patient);
    Task<Boolean> patientExists(PatientDTO patient);
    Task<Boolean> createPatient(PatientDTO patient);
}