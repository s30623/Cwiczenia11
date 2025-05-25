using Cwiczenia11.DTOs;

namespace Cwiczenia11.Services;

public interface IDbService
{
    Task<List<PatientDTO>> getPatientInfo();
}