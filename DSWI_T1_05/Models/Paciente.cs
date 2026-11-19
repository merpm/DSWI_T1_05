using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DSWI_T1_05.Models;

public partial class Paciente
{
    [Key]
    [Column("PacienteID")]
    public int PacienteId { get; set; }

    [StringLength(100)]
    public string? Nombre { get; set; }

    [Column("DNI")]
    [StringLength(20)]
    public string? Dni { get; set; }

    [InverseProperty("Paciente")]
    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();
}
