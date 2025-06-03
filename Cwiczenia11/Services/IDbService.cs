using Cwiczenia11.Data;
using Cwiczenia11.DTOs;

namespace Cwiczenia11.Services;

public interface IDbService
{
    Task<List<PatientDTO>> getPatientInfo(PatientRequestDTO patient);
    Task<Boolean> patientExists(PatientRequestDTO patient);
    Task<Boolean> createPatient(PatientRequestDTO patient);
    Task<Boolean> checkDrugNumber(PatientRequestDTO patient);
    Task<Boolean> checkDrugsExists(PatientRequestDTO patient);
}