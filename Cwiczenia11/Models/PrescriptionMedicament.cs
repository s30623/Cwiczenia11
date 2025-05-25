using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Cwiczenia11.Data;

[Table("Prescription_Medicament")]
public class PrescriptionMedicament
{
    [Key]
    [ForeignKey(nameof(Medicament))]
    public int IdMedicament { get; set; }
    
    [Key]
    [ForeignKey(nameof(Prescription))]
    public int IdPrescription { get; set; }
    
    public int? Dose { get; set; }
    
    [MaxLength(100)]
    public string Details { get; set; }
}