using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DSWI_T1_05.Models;

public partial class Cita
{
    [Key]
    [Column("CitaID")]
    public int CitaId { get; set; }

    public DateOnly? Fecha { get; set; }

    public TimeOnly? Hora { get; set; }

    [StringLength(50)]
    public string? Especialidad { get; set; }

    [StringLength(20)]
    public string? Estado { get; set; }

    [Column("PacienteID")]
    public int? PacienteId { get; set; }

    [ForeignKey("PacienteId")]
    [InverseProperty("Cita")]
    public virtual Paciente? Paciente { get; set; }
}
