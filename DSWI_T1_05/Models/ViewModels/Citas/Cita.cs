using DSWI_T1_05.Models.ViewModels.Pacientes;
using System;
using System.Collections.Generic;

namespace DSWI_T1_05.Models.ViewModels.Citas;

public partial class Cita
{
    public int CitaId { get; set; }

    public DateOnly? Fecha { get; set; }

    public TimeOnly? Hora { get; set; }

    public string? Especialidad { get; set; }

    public string? Estado { get; set; }

    public int? PacienteId { get; set; }

    public virtual Paciente? Paciente { get; set; }
}
