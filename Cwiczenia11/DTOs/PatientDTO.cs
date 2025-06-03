namespace Cwiczenia11.DTOs;

public class PatientDTO
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly Birthdate { get; set; }
    public List<PrescriptionsDTO> Prescriptions { get; set; }
}

public class PatientRequestDTO
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly Birthdate { get; set; }
    public List<MedicamentsDTO> medicaments { get; set; }
    public DateOnly Date{get;set;}
    public DateOnly DueDate{get;set;}
}
public class PrescriptionsDTO
{
    public int IdPrescription { get; set; }
    public DateOnly Date{get;set;}
    public DateOnly DueDate{get;set;}
    public List<MedicamentsDTO> Medicaments { get; set; }
    public DoctorDTO Doctor { get; set; }
}

public class MedicamentsDTO
{
    public int IdMedicament { get; set; }
    public string Name { get; set; }
    public int Dose{get;set;}
    public string Description{get;set;}
}

public class DoctorDTO
{
    public int IdDoctor { get; set; }
    public string FirstName { get; set; }
}