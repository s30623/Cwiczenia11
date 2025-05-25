namespace Cwiczenia11.DTOs;

public class PatientDTO
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; }
    public List<Prescriptions> Prescriptions { get; set; }
}

public class Prescriptions
{
    public int IdPrescription { get; set; }
    public DateOnly Date{get;set;}
    public DateOnly DueDate{get;set;}
    public List<Medicaments> Medicaments { get; set; }
    public Doctor Doctor { get; set; }
}

public class Medicaments
{
    public int IdMedicament { get; set; }
    public string Name { get; set; }
    public int Dose{get;set;}
    public string Description{get;set;}
}

public class Doctor
{
    public int IdDoctor { get; set; }
    public string FirstName { get; set; }
}