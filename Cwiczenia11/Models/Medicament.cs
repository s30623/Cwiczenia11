﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Cwiczenia11.DTOs;

namespace Cwiczenia11.Data;
[Table("Medicament")]
public class Medicament
{
    [Key]
    public int IdMedicament { get; set; }
    
    [MaxLength(100)]
    public string Name { get; set; }
    
    [MaxLength(100)]
    public string Description { get; set; }
    
    [MaxLength(100)]
    public string Type { get; set; }
    public ICollection<PrescriptionMedicament> Prescription_Medicament { get; set; }
}